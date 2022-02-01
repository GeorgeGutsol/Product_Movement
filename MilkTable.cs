using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using iTextSharp;

namespace SQL_product_movement
{
    public partial class MilkTable : Form
    {
        private SqlCommand sqlCommand;
        Size defaultCheckedListSize = new Size(296, 23), defaultSize, currentSize;
        DataSet dataSet;
        ToolStripStatusLabel[] toolStripLabels = new ToolStripStatusLabel[5];
        List<double> diffValues = new List<double>();
        double median = 0, delta = 0, deltaMedian = 0, max = 0;
        bool recountMedian = true;

        public StreamWriter logWriter;
        public int dateRange;
        public SqlConnection ConnectionToRuntime;
        public SqlDataReader sqlDataReader;
        public SqlDataAdapter sqlDataAdapter;
        public SqlConnection ConnectionToMilk;
        public SqlCommandBuilder sqlBuilder;

        public MilkTable()
        {
            InitializeComponent();
        }

        private void Load_Suppliers(CheckedListBox checkedListBox, DateTime nextDate)
        {
            try
            {
                List<String> objects = new List<string>();
                this.Cursor = Cursors.WaitCursor;
                this.Update();

                nextDate = nextDate.AddDays(1.0);

                sqlCommand = new SqlCommand("SET DATEFORMAT dmy; select [Поставщик] from MilkTable where ([Конец]>= '" + dateTimePicker1.Value.ToShortDateString() +
                    "' AND [Конец]<'" + nextDate.ToShortDateString() + "') group by [Поставщик] ", ConnectionToMilk);

                logWriter.WriteLine("----------Запросы для формирования списка поставщиков--------------");
                logWriter.WriteLine();
                logWriter.WriteLine(sqlCommand.CommandText);
                logWriter.WriteLine();

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) { objects.Add(sqlDataReader.GetString(0).Trim(' ')); }
                sqlDataReader.Close();

                if (objects.Count != 0)
                {
                    objects.Sort();
                    checkedListBox.Items.Add("Выделить все");
                    checkedListBox.Items.AddRange(objects.ToArray());
                }

                objects.Clear();

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

        private void LoadData(DataGridView dataGridView,DateTime nextDate, ToolStripStatusLabel[] toolStripStatusLabels) //Вывод результирующей таблицы
        {
            Loading loading = new Loading();
            try
            {
                int sumSup = 0, sumFact = 0;
                double diff = 0;
                median = 0;

                diffValues.Clear();

                nextDate = nextDate.AddDays(1);

                string sqlQuery = "SET DATEFORMAT dmy;SELECT[№], [Начало], [Конец],'Длительность' AS[OperTime], [Поставщик], [С1],[С2], [С3], [З: л],[З: плотн., г/см3]" +
                   ",[П: плотн., г/см3],[З: кг],[П: кг], 'd' AS [d, кг], 'd' AS [d, %] FROM MilkTable WHERE ([Начало]>= '" +
                   dateTimePicker1.Value.ToShortDateString() + "' AND [Начало]<= '" + nextDate.ToShortDateString()
                   + "') AND  ( ";

                this.Cursor = Cursors.WaitCursor;
                this.Update();

                loading.Show();

                for (int i = 1; i<checkedListBox_Supliers.Items.Count;i++)
                {
                    if (checkedListBox_Supliers.GetItemChecked(i))
                    {
                        sqlQuery += "[Поставщик] = N'" + checkedListBox_Supliers.Items[i].ToString() + "' OR\n";
                    }
                }

                sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 3)+")";

                sqlDataAdapter = new SqlDataAdapter(sqlQuery, ConnectionToMilk);

                logWriter.WriteLine("----------Запросы для формирования результирующей таблицы--------------");
                logWriter.WriteLine();
                logWriter.WriteLine(sqlQuery);
                logWriter.WriteLine();

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "MilkTable");

                dataGridView.DataSource = dataSet.Tables["MilkTable"];


                if (dataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("Записи за выбранный промежуток времени не найдены", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   

                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {

                        dataGridView[3, i].Value = (Convert.ToDateTime(dataGridView[2, i].Value.ToString())
                                                   - Convert.ToDateTime(dataGridView[1, i].Value.ToString())).Duration().ToString();

                        dataGridView[13, i].Value = Convert.ToInt32(dataGridView[11, i].Value) - Convert.ToInt32(dataGridView[12, i].Value);
                        diff = 100 * Math.Abs(Convert.ToDouble(dataGridView[13, i].Value)) / Convert.ToDouble(dataGridView[11, i].Value);

                        sumFact += Convert.ToInt32(dataGridView[11, i].Value);
                        sumSup += Convert.ToInt32(dataGridView[12, i].Value);

                        dataGridView[14, i].Value = Math.Round(diff, 2);

                    }



                    dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);

                    CheckData(dataGridView);

                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView.Update();
                }
                toolStripStatusLabels[0].Text = "Найденных строк " + Convert.ToString(dataGridView.Rows.Count) + " |";
                toolStripStatusLabels[2].Text = "Суммарно З, " + Convert.ToString(sumFact) + " кг |";
                toolStripStatusLabels[3].Text = "Суммарно П, " + Convert.ToString(sumSup) + " кг |";
                toolStripStatusLabels[4].Text = "d " + Convert.ToString(sumFact-sumSup) + " кг |";

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

        private void CheckData (DataGridView data)
        {
         
                if (recountMedian) 
                {
                    diffValues.Clear();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToDouble(dataGridView1[14, i].Value) <= max)
                            diffValues.Add(Math.Round(Convert.ToDouble(dataGridView1[14, i].Value), 2));

                    }

                    if (diffValues.Count != 0)
                    {
                        diffValues.Sort();

                        Math.DivRem(diffValues.Count, 2, out int rem);
                        if (rem == 1)
                        {
                            median = diffValues[(diffValues.Count - 1) / 2];

                        }
                        else
                        {
                            median =
                            (diffValues[diffValues.Count / 2] + diffValues[diffValues.Count / 2 - 1]) / 2;
                        }
                        Label_Median.Text = "Медиана " + Convert.ToString(Math.Round(median,2)) + " % |";
                        recountMedian = false;
                    }
                    else
                    {
                        MessageBox.Show("Не удалось рассчитать медиану, повысте максимальное значение для выборки данных", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Label_Median.Text = "Медиана -- % |";
                        recountMedian = true;
                    }
                }


                for (int i = 0; i < data.Rows.Count; i++)
                {

                    if (Convert.ToDouble(data[14, i].Value) > delta)
                    {
                        data.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (Convert.ToDouble(data[14, i].Value) > (deltaMedian + median))
                    {
                        data.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        data.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            
           
        }

        private void MilkTable_Load(object sender, EventArgs e)
        {
            toolStripLabels[0] = Label_RowsAmount ;
            toolStripLabels[1] = Label_Median;
            toolStripLabels[2] = Label_SumFactory;
            toolStripLabels[3] = Label_SumSup;
            toolStripLabels[4] = Label_SumDif;

            label_Date.Enabled = true;
            label_Period.Enabled = false;
            checkBox_Date.Checked = true;
            dateTimePicker2.Enabled = false;

            button_Start.Enabled = false;
        }

        private void button_Go_Click(object sender, EventArgs e)
        {
            checkedListBox_Supliers.Items.Clear();

            dataGridView1.DataSource = null;

            button_Analyz.Enabled = false;

            button_Start.Enabled = false;

            if (checkBox_Date.Checked)
            {
                Load_Suppliers(checkedListBox_Supliers, dateTimePicker1.Value);
            }
            else if (checkBox_Period.Checked)
            {
                Load_Suppliers(checkedListBox_Supliers, dateTimePicker2.Value);
            }

        }

        private void checkedListBox_Supliers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {

                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < checkedListBox_Supliers.Items.Count; i++)
                    {
                        checkedListBox_Supliers.SetItemChecked(i, true);
                    }
                }
                else
                {
                    for (int i = 1; i < checkedListBox_Supliers.Items.Count; i++)
                    {
                        checkedListBox_Supliers.SetItemChecked(i, false);
                    }
                }
               
            }

        }

        private void checkedListBox_Supliers_MouseEnter(object sender, EventArgs e)
        {
            if (checkedListBox_Supliers.Items.Count != 0)
            {
                int height = checkedListBox_Supliers.Size.Height * checkedListBox_Supliers.Items.Count;
                if (height > this.Size.Height - checkedListBox_Supliers.Location.Y)
                    checkedListBox_Supliers.Size = new Size(checkedListBox_Supliers.Size.Width, this.Size.Height - checkedListBox_Supliers.Location.Y-statusStrip1.Size.Height);
                else checkedListBox_Supliers.Size = new Size(checkedListBox_Supliers.Size.Width, height);
            }

        }

        private void checkedListBox_Supliers_MouseLeave(object sender, EventArgs e)
        {
            checkedListBox_Supliers.Size = defaultCheckedListSize;
            if (checkedListBox_Supliers.CheckedItems.Count == 0 || (checkedListBox_Supliers.CheckedItems.Count == 1 && checkedListBox_Supliers.GetItemChecked(0)))
            {
                button_Start.Enabled = false;
            }
            else
            {
                button_Start.Enabled = true;
            }
        }

        private void MilkTable_ResizeBegin(object sender, EventArgs e)
        {
            defaultSize = this.Size;
        }

        private void MilkTable_ResizeEnd(object sender, EventArgs e)
        {
            currentSize = this.Size;
            dataGridView1.Size = new Size(dataGridView1.Size.Width + currentSize.Width - defaultSize.Width,
                dataGridView1.Size.Height + currentSize.Height - defaultSize.Height);
            dataGridView1.Update();

            checkedListBox_Supliers.Location = new Point(checkedListBox_Supliers.Location.X + (currentSize.Width - defaultSize.Width)/2, checkedListBox_Supliers.Location.Y);
            button_Start.Location = new Point(button_Start.Location.X + (currentSize.Width - defaultSize.Width)/2, button_Start.Location.Y);
            checkedListBox_Supliers.Update();

            label_Supliers.Location = new Point(label_Supliers.Location.X + (currentSize.Width - defaultSize.Width)/2, label_Supliers.Location.Y);
            label_Supliers.Update();

            labelDelta.Location = new Point(labelDelta.Location.X + (currentSize.Width - defaultSize.Width), labelDelta.Location.Y);
            label_MedDelta.Location = new Point(label_MedDelta.Location.X + (currentSize.Width - defaultSize.Width), label_MedDelta.Location.Y);

            textBox_Delta.Location = new Point(textBox_Delta.Location.X + (currentSize.Width - defaultSize.Width), textBox_Delta.Location.Y);
            textBox_medDelta.Location = new Point(textBox_medDelta.Location.X + (currentSize.Width - defaultSize.Width), textBox_medDelta.Location.Y);

            button_Analyz.Location = new Point (button_Analyz.Location.X + (currentSize.Width - defaultSize.Width), button_Analyz.Location.Y);

            textBox_max.Location = new Point(textBox_max.Location.X + (currentSize.Width - defaultSize.Width), textBox_max.Location.Y);
            label_max.Location = new Point(label_max.Location.X + (currentSize.Width - defaultSize.Width), label_max.Location.Y);
        }

        private void textBox_medDelta_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(textBox_medDelta.Text, out deltaMedian) && textBox_medDelta.Text != "")
            {
                MessageBox.Show("Введите рациональное положительное число, разделитель целой и дробной части - запятая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_medDelta.Text = "0";
            }
            else if (deltaMedian > 100)
            {
                deltaMedian = 100;
                textBox_medDelta.Text = "100";
                MessageBox.Show("Верхний предел значения - 100%", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (deltaMedian < 0)
            {
                deltaMedian = Math.Round(Math.Abs(delta), 2);
                textBox_medDelta.Text = deltaMedian.ToString();
                MessageBox.Show("Допустимы только положительные значения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                deltaMedian = Math.Round(deltaMedian, 2);
            }

        }

        private void button_Analyz_Click(object sender, EventArgs e)
        {
            CheckData(dataGridView1);
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                List<double> deltas = new List<double>();

                int selectedRows = 0, selFac = 0, selSup = 0; ;
                double med = 0;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    selectedRows += 1;
                    selFac += Convert.ToInt32(dataGridView1[11,row.Index].Value);
                    selSup += Convert.ToInt32(dataGridView1[12, row.Index].Value);

                    deltas.Add(Convert.ToDouble(dataGridView1[14, row.Index].Value));
                }

                if (selectedRows != 0)
                {
                    if (deltas.Count != 0)
                    {
                        deltas.Sort();
                        Math.DivRem(deltas.Count, 2, out int rem);
                        if (rem == 1)
                        {
                            med = deltas[(deltas.Count - 1) / 2];

                        }
                        else
                        {
                            med =
                            (deltas[deltas.Count / 2] + deltas[deltas.Count / 2 - 1]) / 2;
                        }
                        Label_selectedMedian.Text = "Медиана " + Convert.ToString(Math.Round(med,2)) + " % |";

                    }
                    else Label_selectedMedian.Text  = "Медиана -- % |";

                    statusStrip_selected.Visible = true;
                    Label_SelectedRows.Text = "Выделенные: записей " + selectedRows + " |";
                    Label_SelectedFactory.Text = "Суммарно З, " + Convert.ToString(selFac) + " кг |";
                    Label_SelectedSup.Text = "Суммарно П, " + Convert.ToString(selSup) + " кг |";
                    Label_SelectedDiff.Text = " d " + Convert.ToString(selFac - selSup) + " кг |";

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
                dataGridView1.Size = new Size(dataGridView1.Width, dataGridView1.Height - 22);
            }
            else
                dataGridView1.Size = new Size(dataGridView1.Width, dataGridView1.Height + 22);
        }

        private void своднаяТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommInfoMilk formCommInfo = new CommInfoMilk();
            int sumFac = 0, sumSup = 0, rowInd = 0, kolvo = 0;
            List<double> meds = new List<double>();
            bool found = false;

            formCommInfo.Text = "Сводная таблица";

            formCommInfo.dataGridView1.ColumnCount = 7;
            formCommInfo.dataGridView1.Columns[0].HeaderCell.Value = "Поставщик";
            formCommInfo.dataGridView1.Columns[1].HeaderCell.Value = "Записей";
            formCommInfo.dataGridView1.Columns[2].HeaderCell.Value = "З: кг";
            formCommInfo.dataGridView1.Columns[3].HeaderCell.Value = "П: кг";
            formCommInfo.dataGridView1.Columns[4].HeaderCell.Value = "D: кг";
            formCommInfo.dataGridView1.Columns[5].HeaderCell.Value = "Среднее";
            formCommInfo.dataGridView1.Columns[6].HeaderCell.Value = "Медиана";

            for (int i = 0; i< checkedListBox_Supliers.CheckedItems.Count; i++)
            {
                meds.Clear();
                sumFac = 0;
                sumSup = 0;
                rowInd = 0;
                found = false;
                kolvo = 0;

                for (int j = 0; j<dataGridView1.Rows.Count; j++)
                {
                    if (checkedListBox_Supliers.CheckedItems[i].ToString().Trim(' ') == dataGridView1[4,j].Value.ToString().Trim(' '))
                    {
                        sumFac += Convert.ToInt32(dataGridView1[11, j].Value);
                        sumSup += Convert.ToInt32(dataGridView1[12, j].Value);
                        if (Convert.ToDouble(dataGridView1[14, j].Value) <= max)
                        meds.Add(Convert.ToDouble(dataGridView1[14, j].Value));
                        kolvo += 1;
                        found = true;
                    }
                }
                if (found)
                {
                    rowInd = formCommInfo.dataGridView1.Rows.Add();

                    formCommInfo.dataGridView1[0, rowInd].Value = checkedListBox_Supliers.CheckedItems[i].ToString().Trim(' ');
                    formCommInfo.dataGridView1[1, rowInd].Value = kolvo;
                    formCommInfo.dataGridView1[2, rowInd].Value = sumFac;
                    formCommInfo.dataGridView1[3, rowInd].Value = sumSup;
                    formCommInfo.dataGridView1[4, rowInd].Value = sumFac- sumSup;
                    formCommInfo.dataGridView1[5, rowInd].Value = Math.Round(Convert.ToDouble(sumFac - sumSup) * 100 / Convert.ToDouble(sumFac),2);

                    if (meds.Count == 0)
                    {
                        formCommInfo.dataGridView1[6, rowInd].Value = "--";
                    }
                    else
                    {
                        meds.Sort();
                        Math.DivRem(meds.Count, 2, out int rem);
                        if (rem == 1)
                        {
                            formCommInfo.dataGridView1[6, rowInd].Value = meds[(meds.Count - 1) / 2].ToString();

                        }
                        else
                        {
                            formCommInfo.dataGridView1[6, rowInd].Value =
                            ((meds[meds.Count / 2] + meds[meds.Count / 2 - 1]) / 2).ToString();
                        }

                        if (Convert.ToDouble(formCommInfo.dataGridView1[6, rowInd].Value) > delta)
                        {
                            formCommInfo.dataGridView1.Rows[rowInd].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (Convert.ToDouble(formCommInfo.dataGridView1[6, rowInd].Value) > (deltaMedian + median))
                        {
                            formCommInfo.dataGridView1.Rows[rowInd].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else
                        {
                            formCommInfo.dataGridView1.Rows[rowInd].DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }

   


            }

            formCommInfo.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            formCommInfo.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            formCommInfo.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            formCommInfo.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            formCommInfo.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            formCommInfo.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView1.Update();
            formCommInfo.Show();

        }

        private void textBox_max_TextChanged(object sender, EventArgs e)
        {
            if (!Double.TryParse(textBox_max.Text, out max) && textBox_max.Text != "")
            {
                MessageBox.Show("Введите рациональное положительное число, разделитель целой и дробной части - запятая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_max.Text = "0";
            }
            else if (max > 100)
            {
                max = 100;
                textBox_max.Text = "100";
                MessageBox.Show("Верхний предел значения - 100%", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (max < 0)
            {
                max = Math.Round(Math.Abs(delta), 2);
                textBox_max.Text = max.ToString();
                MessageBox.Show("Допустимы только положительные значения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                max = Math.Round(max, 2);
            }
            recountMedian = true;


        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            recountMedian = true;

            if (checkBox_Date.Checked)
            {
                LoadData(dataGridView1, dateTimePicker1.Value, toolStripLabels);
            }
            else if (checkBox_Period.Checked)
            {
                LoadData(dataGridView1, dateTimePicker2.Value, toolStripLabels);
            }

            if (dataGridView1.Rows.Count !=0)
            {
                button_Analyz.Enabled = true;
            }
            else button_Analyz.Enabled = false;
        }

        private void textBox_Delta_TextChanged(object sender, EventArgs e)
        {
           if (!Double.TryParse(textBox_Delta.Text, out delta)&&textBox_Delta.Text !="")
            {
                MessageBox.Show("Введите рациональное положительное число, разделитель целой и дробной части - запятая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Delta.Text = "0";
            }
           else if (delta > 100)
            {
                delta = 100;
                textBox_Delta.Text = "100";
                MessageBox.Show("Верхний предел значения - 100%", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else if (delta<0)
            {
                delta = Math.Round(Math.Abs(delta),2);
                textBox_Delta.Text = delta.ToString();
                MessageBox.Show("Допустимы только положительные значения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else
            {
                delta = Math.Round(delta, 2);
            }
            
            

        }

        private void checkBox_Date_Click(object sender, EventArgs e)
        {
            checkedListBox_Supliers.Items.Clear();
            checkedListBox_Supliers.Update();

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

            checkedListBox_Supliers.Items.Clear();
            checkedListBox_Supliers.Update();

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

    }
}




        
