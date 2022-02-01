using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace SQL_product_movement
{
    public partial class DepartmentForm:Form
    {

        private SqlCommand sqlCommand;
        private List<DateTime> eventTime = null, workTimes = null;
        private DataSet dataSet;
        ToolStripStatusLabel[] toolStripLabels = new ToolStripStatusLabel[5];
        Size defaultSize, currentSize, defaultCheckedListSize = new Size(142,23);

        public StreamWriter logWriter;
        public int dateRange;
        public SqlConnection ConnectionToRuntime;
        public SqlDataReader sqlDataReader;
        public SqlDataAdapter sqlDataAdapter;
        public SqlConnection ConnectionToMilk;
        public SqlCommandBuilder sqlBuilder;

        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void LoadSmena(string selectedObject, DateTime nextDate) //Формирование смен
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Update();

                bool addDays = true, firstDate = false, secondDate = false, foundSmen = false ;

                eventTime.Clear();
                workTimes.Clear();

                nextDate = nextDate.AddDays(1.0);

                selectedObject = selectedObject.Trim(' ');

                logWriter.WriteLine("----------Запросы для формирования смен--------------");
                logWriter.WriteLine();

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
                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime <'" + dateTimePicker1.Value.ToShortDateString()
                                              + "' AND  EventTime >= '" + dateTimePicker1.Value.AddDays(-dateRange).ToShortDateString()
                                              + "' and Source_Object = N'" + selectedObject
                                              + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                                " ORDER BY EventTime DESC ", ConnectionToRuntime);
                logWriter.WriteLine(sqlCommand.CommandText);
                logWriter.WriteLine();
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) { eventTime.Add(sqlDataReader.GetDateTime(0)); foundSmen = true; }
                sqlDataReader.Close();

                if (eventTime.Count == 0)
                {
                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime <='" + nextDate.ToShortDateString()
                              + "' AND  EventTime >= '" + dateTimePicker1.Value.ToShortDateString()
                              + "' and Source_Object = N'" + selectedObject
                              + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                " ORDER BY EventTime ASC ", ConnectionToRuntime);
                    logWriter.WriteLine(sqlCommand.CommandText);
                    logWriter.WriteLine();
                    sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read()) { eventTime.Add(sqlDataReader.GetDateTime(0)); foundSmen = true; }
                    sqlDataReader.Close();
                }


                //Расширяем последний промежуток на следущую дату
                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime <='" + nextDate.AddDays(dateRange).ToShortDateString()
                                  + "' AND EventTime >= '" + nextDate.ToShortDateString()
                                  + "' and Source_Object = N'" + selectedObject
                                  + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                    " ORDER BY EventTime ASC ", ConnectionToRuntime);

                logWriter.WriteLine(sqlCommand.CommandText);
                logWriter.WriteLine();
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) { eventTime.Add(sqlDataReader.GetDateTime(0)); addDays = false;}
                sqlDataReader.Close();

                if (addDays)
                {
                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime <='" + nextDate.ToShortDateString()
                              + "' AND  EventTime >= '" + dateTimePicker1.Value.ToShortDateString()
                              + "' and Source_Object = N'" + selectedObject
                              + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                " ORDER BY EventTime DESC ", ConnectionToRuntime);
                    logWriter.WriteLine(sqlCommand.CommandText);
                    logWriter.WriteLine();
                    sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read()) { eventTime.Add(sqlDataReader.GetDateTime(0)); addDays = false; }
                    sqlDataReader.Close();
                }

                if (eventTime.Count == 0)
                {
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
                        }
                        else
                        {
                            DateTime evTime = eventTime[0];
                            eventTime.RemoveAt(0);
                            eventTime.Add(Convert.ToDateTime(dateTimePicker1.Value.AddDays(-dateRange).ToShortDateString()));
                            eventTime.Add(evTime);

                        }
                    }
                }


                if (foundSmen)
                {
                    firstDate = false;
                    secondDate = false;

                    DateTime time = eventTime[0];

                    logWriter.WriteLine("-----------Уточнение смены--------------");



                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + eventTime[1].ToString()
                                            + "' AND  EventTime > '" + eventTime[0].ToString()
                                            + "' and Source_Object = N'" + selectedObject
                                            + "' and [Comment] = N'Состояние' and  ([ValueString] = N'---')" +
                                              " ORDER BY EventTime ASC ", ConnectionToRuntime);
                    logWriter.WriteLine(sqlCommand.CommandText);
                    logWriter.WriteLine();

                    sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read()) { time = sqlDataReader.GetDateTime(0); }
                    sqlDataReader.Close();


                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + eventTime[1].ToString()
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
                        workTimes.Add(eventTime[0]);
                    }

                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime < '" + eventTime[1].ToString()
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
                        workTimes.Add(eventTime[1]);
                    }
                }
                else workTimes = eventTime;

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

 

        private void LoadData(DataGridView dataGridView, ToolStripStatusLabel[] toolStripStatusLabels) //Вывод результирующей таблицы
        {
            try
            {
                double rcvValue = 0, srcValue = 0;
                string sqlQuery = " SET DATEFORMAT dmy;";
                bool inTime = true;

                Loading loading = new Loading();
                loading.Show();

                this.Cursor = Cursors.WaitCursor;
                this.Update();

                foreach(var someObject in checkedListBox_Objects.CheckedItems)
                {
                    inTime = true;
                    if (checkBox_Date.Checked)
                    {
                        LoadSmena(someObject.ToString(), dateTimePicker1.Value);
                        if (workTimes[0] > dateTimePicker1.Value.AddDays(1)) inTime = false;
                    }
                    else if (checkBox_Period.Checked)
                    {
                        LoadSmena(someObject.ToString(), dateTimePicker2.Value);
                        if (workTimes[0] > dateTimePicker2.Value.AddDays(1)) inTime = false;
                    }
                   if (inTime)
                    sqlQuery += " SELECT [№], [Начало], [Конец],'Длительность' AS[OperTime], [Объект], [Шаг], [Источник], [Приемник]" +
                   ",[Объем, л] FROM QueueTable WHERE ([Начало]>= '" + workTimes[0].ToString() + "' AND [Начало]<= '" + workTimes[eventTime.Count - 1].ToString() +
                    "') AND ([Источник] = N'" + someObject.ToString() + "' OR [Приемник] =  N'" + someObject.ToString() + "' ) union\n";
                }

                sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 6);

                
                sqlDataAdapter = new SqlDataAdapter(sqlQuery, ConnectionToMilk);

                logWriter.WriteLine("----------Запросы для формирования результирующей таблицы--------------");
                logWriter.WriteLine();

                logWriter.WriteLine(sqlQuery);
                logWriter.WriteLine();

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataSet.Clear();

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
                        dataGridView[5, i].Value = dataGridView[5, i].Value.ToString().Trim(' ');
                        dataGridView[6, i].Value = dataGridView[6, i].Value.ToString().Trim(' ');
                        dataGridView[7, i].Value = dataGridView[7, i].Value.ToString().Trim(' ');

                        
                        if (dataGridView[6, i].Value.ToString().Substring(0,3) == comboBox_Dep.SelectedItem.ToString().Substring(0,3))
                        {
                            rcvValue += Convert.ToInt32(dataGridView[8, i].Value.ToString().Trim(' '));
                        }
                        else if (dataGridView[7, i].Value.ToString().Substring(0, 3) == comboBox_Dep.SelectedItem.ToString().Substring(0, 3))
                        {
                            srcValue += Convert.ToInt32(dataGridView[8, i].Value.ToString().Trim(' '));
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
                    dataGridView.Update();
                }
                toolStripStatusLabels[0].Text = "Найденных строк " + Convert.ToString(dataGridView.Rows.Count) + " |";
                toolStripStatusLabels[1].Text = "Принятый объем " + Convert.ToString(srcValue) + " л |";
                toolStripStatusLabels[2].Text = "Переданный объем " + Convert.ToString(rcvValue) + " л |";
                toolStripStatusLabels[3].Text = "Разность " + Convert.ToString(srcValue - rcvValue) + " л |";
                toolStripStatusLabels[4].Text = "d " + Math.Round((srcValue - rcvValue) * 100 / srcValue, 2).ToString("#.##") + " % |";
                loading.Close();
                this.Cursor = Cursors.Default;
                this.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (dataGridView1[6, row.Index].Value.ToString().Substring(0, 3) == comboBox_Dep.SelectedItem.ToString().Substring(0, 3))
                    {
                        srcValue += Convert.ToInt32(dataGridView1[8, row.Index].Value.ToString().Trim(' '));
                    }
                    else if (dataGridView1[7, row.Index].Value.ToString().Substring(0, 3) == comboBox_Dep.SelectedItem.ToString().Substring(0, 3))
                    {
                        rcvValue += Convert.ToInt32(dataGridView1[8, row.Index].Value.ToString().Trim(' '));
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
            checkedListBox_Objects.Items.Clear();
            checkedListBox_Objects.Update();

            button_Start.Enabled = false;

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

            checkedListBox_Objects.Items.Clear();
            checkedListBox_Objects.Update();

            button_Start.Enabled = false;

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
            checkedListBox_Objects.Items.Clear();
            checkedListBox_Objects.Update();

            button_Start.Enabled = false;

            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            dateTimePicker2.Update();
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProductMovement\Departments.txt";
                string line;
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path,System.Text.Encoding.Default))
                    {
                        comboBox_Dep.Items.Clear();
                        while ((line = sr.ReadLine()) != null)
                        {
                            comboBox_Dep.Items.Add(line);
                        }
                        comboBox_Dep.Update();
                        sr.Close();
                    }
                }
                eventTime = new List<DateTime>();
                workTimes = new List<DateTime>();
                dataSet = new DataSet();

                label_Date.Enabled = true;
                label_Period.Enabled = false;
                checkBox_Date.Checked = true;
                dateTimePicker2.Enabled = false;

                comboBox_Dep.SelectedIndex = 0;

                button_Start.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Возможна ошибка в файле Departments.txt", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadObject(CheckedListBox checkedListBox, DateTime nextDate) // Формирование списка объектов
        {
            try
            {
                List<String> objects = new List<string>();
                this.Cursor = Cursors.WaitCursor;

                nextDate = nextDate.AddDays(1.0);

                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select [Приемник] from QueueTable where ([Конец]>= '" + dateTimePicker1.Value.ToShortDateString() +
                    "' AND [Конец]<'" + nextDate.ToShortDateString() + "'AND (LEFT([Приемник],3) = N'" + comboBox_Dep.SelectedItem.ToString().Substring(0,3) + "')) group by [Приемник] " +
                    "union " + "select[Источник] from QueueTable where ([Конец]>= '" + dateTimePicker1.Value.ToShortDateString() +
                    "' AND [Конец]<'" + nextDate.ToShortDateString() + "'AND (LEFT([Источник],3) = N'" + comboBox_Dep.SelectedItem.ToString().Substring(0,3) + "')) group by [Источник]"
                    , ConnectionToMilk);

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
                    checkedListBox.Items.AddRange(objects.ToArray());
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

        private void button_Go_Click(object sender, EventArgs e)
        {
            checkedListBox_Objects.Items.Clear();
            if (checkBox_Date.Checked) LoadObject(checkedListBox_Objects, dateTimePicker1.Value);

            else if (checkBox_Period.Checked)
                LoadObject(checkedListBox_Objects, dateTimePicker2.Value);

            if (checkedListBox_Objects.Items.Count == 0)
                button_Start.Enabled = false;
            else
            {
                button_Start.Enabled = true;
                for (int i = 0; i< checkedListBox_Objects.Items.Count; i++)
                {
                    checkedListBox_Objects.SetItemChecked(i, true);
                }
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            toolStripLabels[0] = Label_RowsAmount;
            toolStripLabels[1] = Label_VolumeSum;
            toolStripLabels[2] = Label_RecievedValue;
            toolStripLabels[3] = Label_SourceValue;
            toolStripLabels[4] = Label_diff;

            LoadData(dataGridView1, toolStripLabels);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            currentSize = this.Size;
            dataGridView1.Size = new Size(dataGridView1.Size.Width + currentSize.Width - defaultSize.Width,
                dataGridView1.Size.Height + currentSize.Height - defaultSize.Height);
            dataGridView1.Update();

            comboBox_Dep.Location = new Point(comboBox_Dep.Location.X + (currentSize.Width - defaultSize.Width) / 2, comboBox_Dep.Location.Y);
            checkedListBox_Objects.Location = new Point(checkedListBox_Objects.Location.X + currentSize.Width - defaultSize.Width, checkedListBox_Objects.Location.Y);
            button_Start.Location = new Point(button_Start.Location.X + currentSize.Width - defaultSize.Width, button_Start.Location.Y);
            button_Go.Location = new Point(button_Go.Location.X + (currentSize.Width - defaultSize.Width)/2, button_Go.Location.Y);
            comboBox_Dep.Update();
            checkedListBox_Objects.Update();

            label_Department.Location = new Point(label_Department.Location.X + (currentSize.Width - defaultSize.Width) / 2, label_Department.Location.Y);
            label_Objects.Location = new Point(label_Objects.Location.X + currentSize.Width - defaultSize.Width, label_Objects.Location.Y);
            label_Objects.Update();
            label_Department.Update();

        }

        private void checkedListBox_Objects_MouseEnter(object sender, EventArgs e)
        {
            if (checkedListBox_Objects.Items.Count!=0)
            {
                int height = checkedListBox_Objects.Size.Height * checkedListBox_Objects.Items.Count;
                if (height > this.Size.Height-checkedListBox_Objects.Location.Y)
                checkedListBox_Objects.Size = new Size(checkedListBox_Objects.Size.Width, this.Size.Height - checkedListBox_Objects.Location.Y);
                else checkedListBox_Objects.Size = new Size(checkedListBox_Objects.Size.Width, height);
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            checkedListBox_Objects.Items.Clear();
            checkedListBox_Objects.Update();

            button_Start.Enabled = false;
        }

        private void checkedListBox_Objects_MouseLeave(object sender, EventArgs e)
        {
            checkedListBox_Objects.Size = defaultCheckedListSize;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            defaultSize = this.Size;
        }
    }
}
