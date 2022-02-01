using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml.Schema;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SQL_product_movement
{
    public partial class Form1 : Form
    {
        private List<DateTime> eventTime = null, workTimes = null;
        private SqlConnection ConnectionToMilk = null;
        private SqlConnection ConnectionToRuntime = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommand sqlCommand = null;
        private SqlDataReader sqlDataReader = null;
        private DateTime newObjectFirstDate, newObjectLastDate, datePlusRange;
        private int number, dateRange;
        private string someObject, selectedObject;
        private string Server;
        ToolStripStatusLabel[] toolStripLabels = new ToolStripStatusLabel[5];
        FormChooseServer chooseServer = new FormChooseServer();
        NewForm newForm;
        Size defaultSize, currentSize, defaultLCB = new Size(316, 23);
        StreamWriter logWriter = null;
        public Form1()
        {
            InitializeComponent();
        }

        //------------------------------------------Методы для загрузки данных в комбобоксы объекта и времени, а также в датагрид----------
        //---------------------------------------------------------------------------------------------------------------------------------

        private void LoadObject (ComboBox comboBox, DateTime nextDate) // Формирование списка объектов
        {
            try
            {
                List<String> objects = new List<string>();
                this.Cursor = Cursors.WaitCursor;
                this.Update();

                nextDate = nextDate.AddDays(1.0);

                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select [Приемник] from QueueTable where ([Конец]>= '" + dateTimePicker1.Value.ToShortDateString()+ 
                    "' AND [Конец]<'" + nextDate.ToShortDateString()+"') group by [Приемник] " +
                    "union " + "select[Источник] from QueueTable where ([Конец]>= '" + dateTimePicker1.Value.ToShortDateString() +
                    "' AND [Конец]<'" + nextDate.ToShortDateString() + "') group by [Источник]" 
                    + "union " + "select [Объект] from QueueTable where ([Конец]>= '" + dateTimePicker1.Value.ToShortDateString() +
                    "' AND [Конец]<'" + nextDate.ToShortDateString() + "') group by [Объект]", ConnectionToMilk);

                logWriter.WriteLine("----------Запросы для формирования списка объектов--------------");
                logWriter.WriteLine();
                logWriter.WriteLine(sqlCommand.CommandText);
                logWriter.WriteLine();

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) { objects.Add(sqlDataReader.GetString(0).Trim(' ')); }
                sqlDataReader.Close();

                if (objects.Count != 0)
                {
                    objects.Sort();
                    comboBox.Items.AddRange(objects.ToArray());
                }

                objects.Clear();
               
                this.Cursor = Cursors.Default;
                this.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LoadData(DataGridView dataGridView, DateTime[] firstDate, DateTime[] lastDate, ToolStripStatusLabel[] toolStripStatusLabels) //Вывод результирующей таблицы
        {
            Loading loading = new Loading();
            try
            {
                double rcvValue = 0, srcValue = 0;
                this.Cursor = Cursors.WaitCursor;
                this.Update();
                
                loading.Show();

                string query = " SET DATEFORMAT dmy; ";

                for (int i = 0; i<firstDate.Length; i++)
                {
                    query += "SELECT [№], [Начало], [Конец],'Длительность' AS[Время], [Объект], [Шаг],'<----' AS[< ----], [Источник], [Приемник],'---->' AS[---->]" +
                    ",[Объем, л] FROM QueueTable WHERE ([Начало]>= '" +
                    firstDate[i].ToString() + "' AND [Начало]<= '" + lastDate[i].ToString()
                    + "') AND ([Источник] = N'" + someObject + "' OR [Приемник] =  N'"
                    + someObject + "' ) union\n";
                }

                query = query.Substring(0, query.Length - 6);

                sqlDataAdapter = new SqlDataAdapter(query, ConnectionToMilk);

                logWriter.WriteLine("----------Запросы для формирования результирующей таблицы--------------");
                logWriter.WriteLine();

                logWriter.WriteLine(query);
                logWriter.WriteLine();

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "QueueTable");

                dataGridView.DataSource = dataSet.Tables["QueueTable"];
                

                if (dataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("Записи за выбранный промежуток времени не найдены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView[6, i] = linkCell;
                        linkCell = new DataGridViewLinkCell();
                        dataGridView[9, i] = linkCell;
                        dataGridView[5, i].Value = dataGridView[5, i].Value.ToString().Trim(' ');
                        dataGridView[7, i].Value = dataGridView[7, i].Value.ToString().Trim(' ');
                        dataGridView[8, i].Value = dataGridView[8, i].Value.ToString().Trim(' ');
                        if (dataGridView[7,i].Value.ToString() == someObject)
                        {
                            rcvValue += Convert.ToInt32(dataGridView[10, i].Value.ToString().Trim(' '));
                        }
                        else if (dataGridView[8,i].Value.ToString() == someObject)
                        {
                            srcValue += Convert.ToInt32(dataGridView[10, i].Value.ToString().Trim(' '));
                        }
                        dataGridView[3, i].Value = (Convert.ToDateTime(dataGridView[2, i].Value.ToString())
                                                   - Convert.ToDateTime(dataGridView[1, i].Value.ToString())).Duration().ToString();
                    }
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Update();
                }
                toolStripStatusLabels[0].Text = "Найденных строк " + Convert.ToString(dataGridView.Rows.Count) + " |";
                toolStripStatusLabels[1].Text = "Принятый объем " + Convert.ToString(srcValue) + " л |";
                toolStripStatusLabels[2].Text = "Переданный объем " + Convert.ToString(rcvValue) + " л |";
                toolStripStatusLabels[3].Text = "Разность " + Convert.ToString(srcValue - rcvValue) + " л |";
                toolStripStatusLabels[4].Text = "d " + Math.Round((srcValue - rcvValue)*100 / srcValue, 2).ToString("#.##") + " % |";

                loading.Close();
                this.Cursor = Cursors.Default;
                this.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                loading.Close();
                this.Cursor = Cursors.Default;
                this.Update();
            }
        }

        private void LoadSmena(CheckedListBox checkedLB, DateTime nextDate) //Формирование смен
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Update();
                bool addDays = true, firstDate, secondDate, foundSmen = false; 
                logWriter.WriteLine("----------Запросы для формирования смен--------------");
                logWriter.WriteLine();
                eventTime = new List<DateTime>();


                nextDate = nextDate.AddDays(1.0);

                selectedObject = comboBox_Object.SelectedItem.ToString().Trim(' ');
                switch (selectedObject)
                {
                    case "Пастеризатор 05":
                        selectedObject = "081L140108";
                        break;
                    case "Пастеризатор 20":
                        selectedObject = "071L030107";
                        break;
                    case "Пастеризатор 15":
                        selectedObject = "071L320107";
                        break;
                    case "Пастеризатор 10":
                        selectedObject = "071L330107";
                        break;
                    default: break;
                }

                //-------------------------------------------Формирование промжутков смен------------------------------------------
                
                //Расширяем первый промежуток на предыдущую дату
                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + dateTimePicker1.Value.ToShortDateString()
                                              + "' AND  EventTime >= '" + dateTimePicker1.Value.AddDays(-dateRange).ToShortDateString()
                                              + "' and Source_Object = N'" + selectedObject
                                              + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                                " ORDER BY EventTime DESC ", ConnectionToRuntime) ;
                logWriter.WriteLine(sqlCommand.CommandText);
                logWriter.WriteLine();
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) { eventTime.Add(sqlDataReader.GetDateTime(0)); foundSmen = true; }
                sqlDataReader.Close();

                //Основные смены в этот день
                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select [EventTime] from Events where (EventTime >= '" + dateTimePicker1.Value.ToShortDateString()
                                                        + "' and EventTime <= '" + nextDate.ToShortDateString() + "') and Source_Object = N'" +
                                                            selectedObject
                + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') ", ConnectionToRuntime);

                logWriter.WriteLine(sqlCommand.CommandText);
                logWriter.WriteLine();
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) { eventTime.Add(sqlDataReader.GetDateTime(0)); foundSmen = true; }
                sqlDataReader.Close();

                //Расширяем последний промежуток на следущую дату
                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime > '" + nextDate.ToShortDateString()
                                  + "' AND EventTime <= '" + nextDate.AddDays(dateRange).ToShortDateString()
                                  + "' and Source_Object = N'" + selectedObject
                                  + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                    " ORDER BY EventTime ASC ", ConnectionToRuntime) ;
                
                logWriter.WriteLine(sqlCommand.CommandText);
                logWriter.WriteLine();
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) { eventTime.Add(sqlDataReader.GetDateTime(0)); addDays = false; }
                sqlDataReader.Close();
                if (eventTime.Count == 0)
                {
                    MessageBox.Show("Не обнаружено ни начала ни конца смены, показаны данные за выбранное число", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    eventTime.Add(dateTimePicker1.Value);
                    eventTime.Add(nextDate);
                }
                else
                {
                    if (eventTime.Count == 1)
                    {
                        if (addDays)
                        {
                            eventTime.Add(Convert.ToDateTime(nextDate.AddDays(dateRange).ToShortDateString()));
                            MessageBox.Show("Не обнаружен конец для одной из смен, показаны ограниченные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DateTime evTime = eventTime[0];
                            eventTime.RemoveAt(0);
                            eventTime.Add(Convert.ToDateTime(dateTimePicker1.Value.AddDays(-dateRange).ToShortDateString()));
                            eventTime.Add(evTime);

                            MessageBox.Show("Не обнаружено начало для одной из смен, показаны ограниченные данные", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                workTimes.Clear();

                if (foundSmen)
                {
                    for (int i = 0; i < eventTime.Count - 1; i++)
                    {


                        firstDate = false;
                        secondDate = false;

                        DateTime time = eventTime[i];

                        logWriter.WriteLine("-----------Уточнение смены--------------");

                        sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + eventTime[i + 1].ToString()
                                                + "' AND  EventTime > '" + eventTime[i].ToString()
                                                + "' and Source_Object = N'" + selectedObject
                                                + "' and [Comment] = N'Состояние' and  ([ValueString] = N'---')" +
                                                  " ORDER BY EventTime ASC ", ConnectionToRuntime);
                        logWriter.WriteLine(sqlCommand.CommandText);
                        logWriter.WriteLine();

                        sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read()) { time = sqlDataReader.GetDateTime(0); }
                        sqlDataReader.Close();

                        if (time > nextDate) break;

                        sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + eventTime[i + 1].ToString()
                                                + "' AND  EventTime > '" + time.ToString()
                                                + "' and Source_Object = N'" + selectedObject
                                                + "' and [Comment] = N'Состояние' and  ([ValueString] != N'---')" +
                                                  " ORDER BY EventTime ASC ", ConnectionToRuntime);
                        logWriter.WriteLine(sqlCommand.CommandText);
                        logWriter.WriteLine();
                        sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read()) { workTimes.Add(sqlDataReader.GetDateTime(0)); firstDate = true; }
                        sqlDataReader.Close();



                        if (!firstDate)
                        {
                            workTimes.Add(eventTime[i]);
                        }

                        if (workTimes[i * 2] > nextDate)
                        {
                            workTimes.RemoveAt(2 * i);
                            break;
                        }

                        sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + eventTime[i + 1].ToString()
                                                + "' AND  EventTime > '" + time.ToString()
                                                + "' and Source_Object = N'" + selectedObject
                                                + "' and [Comment] = N'Состояние' and  [ValueString] = N'---' " +
                                                  " ORDER BY EventTime DESC ", ConnectionToRuntime);
                        logWriter.WriteLine(sqlCommand.CommandText);
                        logWriter.WriteLine();
                        sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read()) { workTimes.Add(sqlDataReader.GetDateTime(0)); secondDate = true; }
                        sqlDataReader.Close();

                        if (!secondDate)
                        {
                            workTimes.Add(eventTime[i + 1]);
                        }

                        checkedLB.Items.Add(workTimes[2 * i].ToString() + " - " + workTimes[2 * i + 1].ToString());
                    }
                }
                else
                {
                    workTimes = eventTime;
                    for (int i = 0; i < workTimes.Count - 1; i++)
                    {
                        checkedLB.Items.Add(workTimes[i].ToString() + " - " + workTimes[ i + 1].ToString());
                    }
                }
                this.Cursor = Cursors.Default;
                this.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Cursor = Cursors.Default;
                this.Update();
            }

        }



        private void Init ()
        {
            try
            {
                dateTimePicker1.Value = DateTime.Today;
                if (!File.Exists(chooseServer.path))
                {
                    chooseServer.ShowDialog();
                }
                else
                {
                    using (StreamReader sr = new StreamReader(chooseServer.path))
                    {
                        Server = sr.ReadLine();
                        string readNumber = sr.ReadLine();
                        sr.Close();
                        if (Server == null)
                        {
                            chooseServer.ShowDialog();
                        }
                        else if (Server.Trim(' ') == "" || Server == "")
                        {
                            chooseServer.ShowDialog();
                        }
                        if (readNumber == null || readNumber.Trim(' ') == "" || readNumber == "")
                            dateRange = 2;
                        else dateRange = Convert.ToInt32(readNumber);


                    }
                }

                ConnectionToMilk = new SqlConnection(@"Data Source=" + Server + ";Initial Catalog=MilkInfo;Integrated Security=True");

                ConnectionToMilk.Open();

                ConnectionToRuntime = new SqlConnection(@"Data Source=" + Server + ";Initial Catalog=Runtime;Integrated Security=True");

                ConnectionToRuntime.Open();

                comboBox_Object.SelectedIndex = -1;
                comboBox_Object.Items.Clear();
                comboBox_Object.Update();

                checkedListBox_Time.SelectedIndex = -1;
                checkedListBox_Time.Items.Clear();
                checkedListBox_Time.Update();

                if (dataSet != null)
                {
                    dataSet.Clear();
                    dataGridView1.Update();
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -----------------------------Начальная загрузка главной формы-----------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            this.Update();
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\ProductMovement"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ProductMovement");
            }
            
            logWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProductMovement\log.txt");
            label_Date.Enabled = true;
            label_Period.Enabled = false;
            checkBox_Date.Checked = true;
            dateTimePicker2.Enabled = false;

            button_Find.Enabled = false;
            Init();

            workTimes = new List<DateTime>();


            this.Cursor = Cursors.Default;
            this.Update();
        }

        //-----------------------------Создание нового окна--------------------------------
        private void CreateNewForm()
        {
            newForm = new NewForm();
            newForm.MaximizeBox = false;
            newForm.MinimumSize = new System.Drawing.Size(this.Width,newForm.Height);
            newForm.Text =someObject + "  " + newObjectFirstDate.ToString() + " - " + newObjectLastDate.ToString();

            newForm.logWriter = logWriter;
            newForm.dateRange = dateRange;
            newForm.ConnectionToRuntime = ConnectionToRuntime;
            newForm.sqlDataReader = sqlDataReader;
            newForm.sqlDataAdapter = sqlDataAdapter;
            newForm.ConnectionToMilk = ConnectionToMilk;
            newForm.sqlBuilder = sqlBuilder;
            newForm.thisObject = someObject;
            

            newForm.dataGridView_NewForm.ReadOnly = true;
            newForm.dataGridView_NewForm.AllowUserToAddRows = false;
            newForm.dataGridView_NewForm.AllowUserToDeleteRows = false;
            newForm.dataGridView_NewForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            newForm.dataGridView_NewForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            newForm.dataGridView_NewForm.TabIndex = 0;

            toolStripLabels[0] = newForm.Label_RowsAmount;
            toolStripLabels[1] = newForm.Label_VolumeSum;
            toolStripLabels[2] = newForm.Label_RecievedValue;
            toolStripLabels[3] = newForm.Label_SourceValue;
            toolStripLabels[4] = newForm.Label_diff;

            DateTime[] dTStart = { newObjectFirstDate }, dTStop = { newObjectLastDate };
            

            LoadData(newForm.dataGridView_NewForm,dTStart,dTStop, toolStripLabels);
            newForm.Show();
            for (int i = 0; i < newForm.dataGridView_NewForm.Rows.Count; i++)
            {
                if (Convert.ToInt32(newForm.dataGridView_NewForm[0, i].Value) == number)
                {
                    newForm.dataGridView_NewForm.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    break;
                }
            }
            newForm.dataGridView_NewForm.Update();

        }

   

        //------------------------------События--------------------------------------------------
        //--------------------------------------------------------------------------------------
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConnectionToMilk != null && ConnectionToMilk.State != ConnectionState.Closed)
                ConnectionToMilk.Close();

            if (ConnectionToRuntime != null && ConnectionToRuntime.State != ConnectionState.Closed)
                ConnectionToRuntime.Close();

            if (logWriter != null)
            logWriter.Close();
        }

        //-------------------------------------Действие при выборе объекта-----------------------------------------------
        private void comboBox_Object_SelectionChangeCommitted(object sender, EventArgs e) 
        {

            button_Find.Enabled = false;

            checkedListBox_Time.Items.Clear();
            checkedListBox_Time.Update();

            dataGridView1.DataSource = null;
            dataGridView1.Update();

            if (checkBox_Date.Checked) LoadSmena(checkedListBox_Time, dateTimePicker1.Value);
            else if (checkBox_Period.Checked) LoadSmena(checkedListBox_Time, dateTimePicker2.Value);


        }


        private void buttonGo_Click(object sender, EventArgs e)
        {
            comboBox_Object.SelectedIndex = -1;
            comboBox_Object.Items.Clear();
            comboBox_Object.Update();

            checkedListBox_Time.Items.Clear();
            checkedListBox_Time.Update();

            button_Find.Enabled = false;

            dataGridView1.DataSource = null;
            dataGridView1.Update();


            if (checkBox_Date.Checked)
            {
                LoadObject(comboBox_Object, dateTimePicker1.Value);
            }
            else if (checkBox_Period.Checked)
            {
                if (dateTimePicker2.Value <= dateTimePicker1.Value)
                {
                    MessageBox.Show("Выберите дату большую начальной даты промежутка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
                else
                {
                    LoadObject(comboBox_Object, dateTimePicker2.Value);
                }

            }    
        }

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToCSV(dataGridView1);
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                int selectedRows = 0;
                double rcvValue = 0, srcValue = 0;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    selectedRows += 1;
                    if (dataGridView1[7, row.Index].Value.ToString() == selectedObject)
                    {
                        
                        srcValue += Convert.ToInt32(dataGridView1[10, row.Index].Value.ToString().Trim(' '));
                    }
                    else if (dataGridView1[8, row.Index].Value.ToString() == selectedObject)
                    {
                        rcvValue += Convert.ToInt32(dataGridView1[10, row.Index].Value.ToString().Trim(' '));
                    }
                }
                if (selectedRows != 0)
                {
                    
                    statusStrip_selected.Visible = true;
                    Label_SelectedRows.Text = "Выделенных записей " + selectedRows + " |";
                    Label_RecSel.Text = "Принятый объем " + Convert.ToString(rcvValue) + " л |";
                    Label_SrcSel.Text = "Переданный объем " + Convert.ToString(srcValue) + " л |";
                    Label_difSel.Text = "Разность " + Convert.ToString(rcvValue - srcValue) + " л |";
                    Label_difRelSel.Text = "d " + Math.Round((rcvValue - srcValue) * 100 / rcvValue, 2).ToString("#.##") + " % |";

                }
                else
                {
                    statusStrip_selected.Visible = false;
                }
            }

        }

        private void checkBox_Date_Click(object sender, EventArgs e)
        {
            comboBox_Object.SelectedIndex = -1;
            comboBox_Object.Items.Clear();
            comboBox_Object.Update();

            checkedListBox_Time.SelectedIndex = -1;
            checkedListBox_Time.Items.Clear();
            checkedListBox_Time.Update();

            if (checkBox_Date.Checked)
            {
                label_Date.Enabled = true;
                checkBox_Period.Checked = false;
                dateTimePicker2.Enabled = false;
                label_Period.Enabled = false;
            }
            else
            {
                label_Date.Enabled = false;
                label_Period.Enabled = true;
                checkBox_Period.Checked = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void checkBox_Period_Click(object sender, EventArgs e)
        {

            comboBox_Object.SelectedIndex = -1;
            comboBox_Object.Items.Clear();
            comboBox_Object.Update();

            checkedListBox_Time.SelectedIndex = -1;
            checkedListBox_Time.Items.Clear();
            checkedListBox_Time.Update();

            if (checkBox_Period.Checked)
            {
                label_Date.Enabled = false;
                checkBox_Date.Checked = false;
                dateTimePicker2.Enabled = true;
                label_Period.Enabled = true;
            }
            else
            {
                label_Date.Enabled = true;
                label_Period.Enabled = false;
                checkBox_Date.Checked = true;
                dateTimePicker2.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox_Object.SelectedIndex = -1;
            comboBox_Object.Items.Clear();
            comboBox_Object.Update();

            checkedListBox_Time.Items.Clear();
            checkedListBox_Time.Update();

            button_Find.Enabled = false;

            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            dateTimePicker2.Update();
        }

        private void отделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentForm = new DepartmentForm();

            departmentForm.logWriter = logWriter;
            departmentForm.dateRange = dateRange;
            departmentForm.ConnectionToRuntime = ConnectionToRuntime;
            departmentForm.sqlDataReader = sqlDataReader;
            departmentForm.sqlDataAdapter = sqlDataAdapter;
            departmentForm.ConnectionToMilk = ConnectionToMilk;
            departmentForm.sqlBuilder = sqlBuilder;

            departmentForm.Show();
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MilkTable milkForm = new MilkTable();

            milkForm.logWriter = logWriter;
            milkForm.dateRange = dateRange;
            milkForm.ConnectionToRuntime = ConnectionToRuntime;
            milkForm.sqlDataReader = sqlDataReader;
            milkForm.sqlDataAdapter = sqlDataAdapter;
            milkForm.ConnectionToMilk = ConnectionToMilk;
            milkForm.sqlBuilder = sqlBuilder;

            milkForm.Show();
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Открытие документа
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "pdf (*.pdf)|*.pdf";
            sfd.FileName = "Output.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Невозможно записать файл на диск" + ex.Message);
                    }
                }

                var doc = new Document();

                string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);


                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                doc.SetPageSize(PageSize.A4.Rotate());

                doc.Open();



                PdfPTable pTable = new PdfPTable(9) { WidthPercentage = 100 };

                var colWidthPercentages = new[] { 7f, 9f, 9f, 8f, 11f, 27f, 11f, 11f, 7f };
                pTable.SetWidths(colWidthPercentages);

                Phrase element;

                for (int i = -1; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j <= 10; j++)
                    {

                        if (j != 6 && j != 9)
                        {
                            if (i == -1)
                            {
                                element = new Phrase(@dataGridView1.Columns[j].HeaderCell.Value.ToString(), font);
                            }
                            else
                            {
                                element = new Phrase(dataGridView1[j, i].Value.ToString(), font);
                            }
                            pTable.AddCell(element);

                        }
                    }
                }

                doc.Add(pTable);
                doc.Close();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            comboBox_Object.SelectedIndex = -1;
            comboBox_Object.Items.Clear();
            comboBox_Object.Update();

            checkedListBox_Time.SelectedIndex = -1;
            checkedListBox_Time.Items.Clear();
            checkedListBox_Time.Update();

            button_Find.Enabled = false;
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Update();

            toolStripLabels[0] = Label_RowsAmount;
            toolStripLabels[1] = Label_VolumeSum;
            toolStripLabels[2] = Label_RecievedValue;
            toolStripLabels[3] = Label_SourceValue;
            toolStripLabels[4] = Label_diff;

            someObject = comboBox_Object.SelectedItem.ToString().Trim(' ');

            DateTime[] dTStart = new DateTime[checkedListBox_Time.CheckedItems.Count];
            DateTime[] dTStop = new DateTime[checkedListBox_Time.CheckedItems.Count];

            for (int i = 0; i < checkedListBox_Time.CheckedItems.Count; i++)
            {
                dTStart[i] = workTimes[checkedListBox_Time.CheckedIndices[i] * 2];
                dTStop[i] = workTimes[checkedListBox_Time.CheckedIndices[i] * 2 + 1];

            }

            LoadData(dataGridView1, dTStart, dTStop, toolStripLabels);
        }

        private void checkedListBox_Time_MouseLeave(object sender, EventArgs e)
        {
            checkedListBox_Time.Size = defaultLCB;

            if (checkedListBox_Time.CheckedItems.Count != 0) button_Find.Enabled = true;
            else button_Find.Enabled = false;
        }


        private void checkedListBox_Time_MouseEnter(object sender, EventArgs e)
        {
            if (checkedListBox_Time.Items.Count != 0)
            {
                int height = checkedListBox_Time.Size.Height * checkedListBox_Time.Items.Count;
                if (height > this.Size.Height - checkedListBox_Time.Location.Y - statusStrip1.Size.Height)
                    checkedListBox_Time.Size = new Size(checkedListBox_Time.Size.Width, this.Size.Height - checkedListBox_Time.Location.Y - statusStrip1.Size.Height);
                else checkedListBox_Time.Size = new Size(checkedListBox_Time.Size.Width, height);
            }
        }

        private void statusStrip_selected_VisibleChanged(object sender, EventArgs e)
        {
            if (statusStrip_selected.Visible)
            {
                dataGridView1.Size = new Size(dataGridView1.Width, dataGridView1.Height - 22);
            }
            else
                dataGridView1.Size = new Size(dataGridView1.Width, dataGridView1.Height + 22);
        }

        private void SaveToCSV(DataGridView DGV)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Невозможно записать файл на диск" + ex.Message);
                    }
                }
                int columnCount = DGV.ColumnCount;
                string columnNames = "";
                string[] output = new string[DGV.RowCount + 3];
                output[0] += comboBox_Object.SelectedItem + " " + checkedListBox_Time.SelectedItem;
                output[1] += " ";
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += DGV.Columns[i].Name.ToString() + ",";
                }
                output[2] += columnNames;
                for (int i = 3; i < DGV.RowCount + 3; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += DGV.Rows[i - 3].Cells[j].Value.ToString() + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Файл сгенерирован");
            }
        }

            private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            currentSize = this.Size;
            dataGridView1.Size = new Size(dataGridView1.Size.Width + currentSize.Width - defaultSize.Width,
                dataGridView1.Size.Height + currentSize.Height - defaultSize.Height);
            dataGridView1.Update();

            comboBox_Object.Location = new Point(comboBox_Object.Location.X + (currentSize.Width - defaultSize.Width)/2, comboBox_Object.Location.Y);
            checkedListBox_Time.Location = new Point(checkedListBox_Time.Location.X + currentSize.Width - defaultSize.Width, checkedListBox_Time.Location.Y);
            comboBox_Object.Update();
            checkedListBox_Time.Update();

            label_Object.Location = new Point(label_Object.Location.X + (currentSize.Width - defaultSize.Width) / 2, label_Object.Location.Y);
            label_Time.Location = new Point(label_Time.Location.X + currentSize.Width - defaultSize.Width, label_Time.Location.Y);
            label_Object.Update();
            label_Time.Update();

            button_Find.Location = new Point(button_Find.Location.X + currentSize.Width - defaultSize.Width, button_Find.Location.Y);

        }

        private void выборСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseServer.ShowDialog();

            Init();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            defaultSize = this.Size;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 6 || e.ColumnIndex == 9) && e.RowIndex != -1)
                { 
                    logWriter.WriteLine("----------Запросы для формирования нового окна--------------");
                    logWriter.WriteLine();

                    bool noFirstDateSmen = true, noLastDateSmen = true, firstDate = false, secondDate = false;
                    datePlusRange = Convert.ToDateTime(dataGridView1[1, e.RowIndex].Value.ToString());
                    DateTime time, first = datePlusRange, last = datePlusRange.AddDays(1.0) ;


                    if (e.ColumnIndex == 6)
                    {
                        someObject = dataGridView1[7, e.RowIndex].Value.ToString().Trim(' ');

                    }
                    else if (e.ColumnIndex == 9)
                    {
                        someObject = dataGridView1[8, e.RowIndex].Value.ToString().Trim(' ');

                    }


                    number = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime <= '" + dataGridView1[1, e.RowIndex].Value.ToString()
                                                 + "' AND EventTime >='" + datePlusRange.AddDays(-dateRange).ToShortDateString()
                                                 + "' and Source_Object = N'" + someObject
                                                 + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                                   " ORDER BY EventTime DESC ", ConnectionToRuntime);
                    logWriter.WriteLine(sqlCommand.CommandText);
                    logWriter.WriteLine();
                    sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.Read()) { first = sqlDataReader.GetDateTime(0); noFirstDateSmen = false; }
                    sqlDataReader.Close();

                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime > '" + dataGridView1[1, e.RowIndex].Value.ToString()
                                                 + "' AND EventTime <='" + datePlusRange.AddDays(dateRange+1).ToShortDateString()
                                                 + "' and Source_Object = N'" + someObject
                                                 + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                                     " ORDER BY EventTime ASC ", ConnectionToRuntime);

                    logWriter.WriteLine(sqlCommand.CommandText);
                    logWriter.WriteLine();
                    sqlDataReader = sqlCommand.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        last = sqlDataReader.GetDateTime(0);
                        noLastDateSmen = false;
                        if (noFirstDateSmen)
                        {
                            newObjectFirstDate = Convert.ToDateTime(datePlusRange.AddDays(-dateRange).ToShortDateString());
                        }
                    }
                    else if (!noFirstDateSmen)
                    {
                        last = Convert.ToDateTime(datePlusRange.AddDays(dateRange+1).ToShortDateString());
                        noLastDateSmen = false;
                    }
                    sqlDataReader.Close();

                    if (noFirstDateSmen && noLastDateSmen)
                    {
                        MessageBox.Show("Не обнаружено ни начала ни конца смены, показаны данные за дату начала операции", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        newObjectFirstDate = Convert.ToDateTime(dataGridView1[1, e.RowIndex].Value.ToString());
                        newObjectFirstDate = Convert.ToDateTime(newObjectFirstDate.ToShortDateString());
                        newObjectLastDate = newObjectFirstDate.AddDays(1);
                        CreateNewForm();
                    }
                    else if (!noFirstDateSmen)
                    {
                        time = first;
                        logWriter.WriteLine("-----------Уточнение смены--------------");

                        sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + last.ToString()
                                               + "' AND  EventTime > '" + first.ToString()
                                               + "' and Source_Object = N'" + someObject
                                               + "' and [Comment] = N'Состояние' and  ([ValueString] = N'---')" +
                                                 " ORDER BY EventTime ASC ", ConnectionToRuntime);
                        logWriter.WriteLine(sqlCommand.CommandText);
                        logWriter.WriteLine();

                        sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read()) { time = sqlDataReader.GetDateTime(0); }
                        sqlDataReader.Close();





                        sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + last.ToString()
                                                + "' AND  EventTime > '" + time.ToString()
                                                + "' and Source_Object = N'" + someObject
                                                + "' and [Comment] = N'Состояние' and  ([ValueString] != N'---')" +
                                                  " ORDER BY EventTime ASC ", ConnectionToRuntime);
                        logWriter.WriteLine(sqlCommand.CommandText);
                        logWriter.WriteLine();
                        sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read()) { newObjectFirstDate = sqlDataReader.GetDateTime(0); firstDate = true; }
                        sqlDataReader.Close();

                        if (!firstDate)
                        {
                            newObjectFirstDate = first;
                        }


                        sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + last.ToString()
                                                + "' AND  EventTime > '" + time.ToString()
                                                + "' and Source_Object = N'" + someObject
                                                + "' and [Comment] = N'Состояние' and  [ValueString] = N'---' " +
                                                  " ORDER BY EventTime DESC ", ConnectionToRuntime);
                        logWriter.WriteLine(sqlCommand.CommandText);
                        logWriter.WriteLine();
                        sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read()) { newObjectLastDate = sqlDataReader.GetDateTime(0); secondDate = true; }
                        sqlDataReader.Close();

                        if (!secondDate)
                        {
                            newObjectLastDate = last;
                        }

                        if (firstDate == true || secondDate == true)
                        {
                            CreateNewForm();
                        }

                        else
                        {
                            MessageBox.Show("Не обнаружено ни начала ни конца смены, показаны данные за дату начала операции", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            newObjectFirstDate = Convert.ToDateTime(dataGridView1[1, e.RowIndex].Value.ToString());
                            newObjectFirstDate = Convert.ToDateTime(newObjectFirstDate.ToShortDateString());
                            newObjectLastDate = newObjectFirstDate.AddDays(1);
                            CreateNewForm();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не обнаружено начала смены, показаны ограниченные данные", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CreateNewForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
