using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_product_movement
{
    public partial class NewForm : Form
    {
        private DateTime datePlusRange, newObjectFirstDate, newObjectLastDate;
        private string someObject;
        private int number;
        private SqlCommand sqlCommand;
        private DataSet dataSet;

        public string thisObject;
        public StreamWriter logWriter;
        public int dateRange;
        public SqlConnection ConnectionToRuntime;
        public SqlDataReader sqlDataReader;
        public SqlDataAdapter sqlDataAdapter;
        public SqlConnection ConnectionToMilk;
        public SqlCommandBuilder sqlBuilder;
        

        NewForm newForm;
        ToolStripStatusLabel[] toolStripLabels = new ToolStripStatusLabel[5];
        Size defaultSize, currentSize;

        public NewForm()
        {
            InitializeComponent();
        }

        private void импортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToCSV(dataGridView_NewForm);
        }

        void SaveDataGridViewToCSV(string filename)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView_NewForm.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            dataGridView_NewForm.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = dataGridView_NewForm.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
            dataGridView_NewForm.Update();
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
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                int columnCount = DGV.ColumnCount;
                string columnNames = "";
                string[] output = new string[DGV.RowCount + 3];
                output[0] += this.Text;
                output[1] += " ";
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += DGV.Columns[i].Name.ToString() + ",";
                }
                output[2] += columnNames;
                for (int i = 3; i < DGV.RowCount+3; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += DGV.Rows[i - 3].Cells[j].Value.ToString() + ",";
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, output, System.Text.Encoding.UTF8);
                MessageBox.Show("Your file was generated and its ready for use.");
            }
        }

        private void NewForm_ResizeBegin(object sender, EventArgs e)
        {
            defaultSize = this.Size;
        }

        private void NewForm_ResizeEnd(object sender, EventArgs e)
        {
            currentSize = this.Size;
            dataGridView_NewForm.Size = new Size(dataGridView_NewForm.Size.Width,
                dataGridView_NewForm.Size.Height + currentSize.Height - defaultSize.Height);
            dataGridView_NewForm.Update();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                int selectedRows = 0;
                double rcvValue = 0, srcValue = 0;
                foreach (DataGridViewRow row in dataGridView_NewForm.SelectedRows)
                {
                    selectedRows += 1;
                    if (dataGridView_NewForm[7, row.Index].Value.ToString() == thisObject)
                    {

                        srcValue += Convert.ToInt32(dataGridView_NewForm[10, row.Index].Value.ToString().Trim(' '));
                    }
                    else if (dataGridView_NewForm[8, row.Index].Value.ToString() == thisObject)
                    {
                        rcvValue += Convert.ToInt32(dataGridView_NewForm[10, row.Index].Value.ToString().Trim(' '));
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

        private void statusStrip_selected_VisibleChanged(object sender, EventArgs e)
        {
            if (statusStrip_selected.Visible)
            {
                dataGridView_NewForm.Size = new Size(dataGridView_NewForm.Width, dataGridView_NewForm.Height - 22);
            }
            else
                dataGridView_NewForm.Size = new Size(dataGridView_NewForm.Width, dataGridView_NewForm.Height + 22);
        }

        private void newDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 6 || e.ColumnIndex == 9) && e.RowIndex != -1)
                {
                    logWriter.WriteLine("----------Запросы для формирования нового окна--------------");
                    logWriter.WriteLine();

                    bool noFirstDateSmen = true, noLastDateSmen = true, firstDate = false, secondDate = false;
                    datePlusRange = Convert.ToDateTime(dataGridView_NewForm[1, e.RowIndex].Value.ToString());
                    DateTime time, first = datePlusRange, last = datePlusRange.AddDays(1.0);


                    if (e.ColumnIndex == 6)
                    {
                        someObject = dataGridView_NewForm[7, e.RowIndex].Value.ToString().Trim(' ');

                    }
                    else if (e.ColumnIndex == 9)
                    {
                        someObject = dataGridView_NewForm[8, e.RowIndex].Value.ToString().Trim(' ');

                    }


                    number = Convert.ToInt32(dataGridView_NewForm[0, e.RowIndex].Value);
                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime <= '" + dataGridView_NewForm[1, e.RowIndex].Value.ToString()
                                                 + "' AND EventTime >='" + datePlusRange.AddDays(-dateRange).ToShortDateString()
                                                 + "' and Source_Object = N'" + someObject
                                                 + "' and [Comment] = N'Состояние' and  (LEFT([ValueString],6) = N'Мойка:' OR LEFT([ValueString],12) = N'Мойка танка:') " +
                                                   " ORDER BY EventTime DESC ", ConnectionToRuntime);
                    logWriter.WriteLine(sqlCommand.CommandText);
                    logWriter.WriteLine();
                    sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.Read()) { first = sqlDataReader.GetDateTime(0); noFirstDateSmen = false; }
                    sqlDataReader.Close();

                    sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select TOP 1 [EventTime] from Events where EventTime > '" + dataGridView_NewForm[1, e.RowIndex].Value.ToString()
                                                 + "' AND EventTime <='" + datePlusRange.AddDays(dateRange + 1).ToShortDateString()
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
                        last = Convert.ToDateTime(datePlusRange.AddDays(dateRange + 1).ToShortDateString());
                        noLastDateSmen = false;
                    }
                    sqlDataReader.Close();

                    if (noFirstDateSmen && noLastDateSmen)
                    {
                        MessageBox.Show("Не обнаружено ни начала ни конца смены, показаны данные за дату начала операции", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        newObjectFirstDate = Convert.ToDateTime(dataGridView_NewForm[1, e.RowIndex].Value.ToString());
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
                            newObjectFirstDate = Convert.ToDateTime(dataGridView_NewForm[1, e.RowIndex].Value.ToString());
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

        private void CreateNewForm()
        {
            newForm = new NewForm();
            newForm.MaximizeBox = false;
            newForm.MinimumSize = new System.Drawing.Size(this.Width, newForm.Height);
            newForm.Text = someObject + "  " + newObjectFirstDate.ToString() + " - " + newObjectLastDate.ToString();

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

            LoadData(newForm.dataGridView_NewForm, newObjectFirstDate, newObjectLastDate, toolStripLabels);
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

        private void LoadData(DataGridView dataGridView, DateTime firstDate, DateTime lastDate, ToolStripStatusLabel[] toolStripStatusLabels) //Вывод результирующей таблицы
        {
            try
            {
                double rcvValue = 0, srcValue = 0;
                this.Cursor = Cursors.WaitCursor;
                this.Update();
                Loading loading = new Loading();
                loading.Show();
                sqlDataAdapter = new SqlDataAdapter(" SET DATEFORMAT dmy; SELECT [№], [Начало], [Конец],'Длительность' AS [OperTime], [Объект], [Шаг],'<----' AS [<----], [Источник], [Приемник],'---->' AS [---->]" +
                   ",[Объем, л] FROM QueueTable WHERE ([Начало]>= '" +
                   firstDate.ToString() + "' AND [Начало]<= '" + lastDate.ToString()
                   + "') AND ([Источник] = N'" + someObject + "' OR [Приемник] =  N'"
                   + someObject + "' )"
                   , ConnectionToMilk);

                logWriter.WriteLine("----------Запросы для формирования результирующей таблицы--------------");
                logWriter.WriteLine();
                logWriter.WriteLine(" SET DATEFORMAT dmy; SELECT [№], [Начало], [Конец], [Объект], [Шаг],'<----' AS [<----], [Источник], [Приемник],'---->' AS [---->]" +
                   ",[Объем, л] FROM QueueTable WHERE ([Начало]>= '" +
                   firstDate.ToString() + "' AND [Начало]<= '" + lastDate.ToString()
                   + "') AND ([Источник] = N'" + someObject + "' OR [Приемник] =  N'"
                   + someObject + "' )");
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

                        if (dataGridView[7, i].Value.ToString() == someObject)
                        {
                            rcvValue += Convert.ToInt32(dataGridView[10, i].Value.ToString().Trim(' '));
                        }
                        else if (dataGridView[8, i].Value.ToString() == someObject)
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
    }
}
