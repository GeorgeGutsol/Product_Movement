namespace SQL_product_movement
{
    partial class MilkTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox_Supliers = new System.Windows.Forms.CheckedListBox();
            this.button_Go = new System.Windows.Forms.Button();
            this.checkBox_Period = new System.Windows.Forms.CheckBox();
            this.label_Period = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.checkBox_Date = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label_RowsAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_Median = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SumFactory = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SumSup = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SumDif = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_Date = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Supliers = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.labelDelta = new System.Windows.Forms.Label();
            this.label_MedDelta = new System.Windows.Forms.Label();
            this.textBox_Delta = new System.Windows.Forms.TextBox();
            this.textBox_medDelta = new System.Windows.Forms.TextBox();
            this.button_Analyz = new System.Windows.Forms.Button();
            this.label_max = new System.Windows.Forms.Label();
            this.textBox_max = new System.Windows.Forms.TextBox();
            this.statusStrip_selected = new System.Windows.Forms.StatusStrip();
            this.Label_SelectedRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_selectedMedian = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SelectedFactory = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SelectedSup = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SelectedDiff = new System.Windows.Forms.ToolStripStatusLabel();
            this.своднаяТаблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip_selected.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox_Supliers
            // 
            this.checkedListBox_Supliers.CheckOnClick = true;
            this.checkedListBox_Supliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkedListBox_Supliers.FormattingEnabled = true;
            this.checkedListBox_Supliers.Location = new System.Drawing.Point(370, 56);
            this.checkedListBox_Supliers.Name = "checkedListBox_Supliers";
            this.checkedListBox_Supliers.Size = new System.Drawing.Size(296, 23);
            this.checkedListBox_Supliers.TabIndex = 43;
            this.checkedListBox_Supliers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_Supliers_ItemCheck);
            this.checkedListBox_Supliers.MouseEnter += new System.EventHandler(this.checkedListBox_Supliers_MouseEnter);
            this.checkedListBox_Supliers.MouseLeave += new System.EventHandler(this.checkedListBox_Supliers_MouseLeave);
            // 
            // button_Go
            // 
            this.button_Go.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_Go.Location = new System.Drawing.Point(253, 56);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(96, 25);
            this.button_Go.TabIndex = 41;
            this.button_Go.Text = "Найти";
            this.button_Go.UseVisualStyleBackColor = true;
            this.button_Go.Click += new System.EventHandler(this.button_Go_Click);
            // 
            // checkBox_Period
            // 
            this.checkBox_Period.AutoSize = true;
            this.checkBox_Period.Location = new System.Drawing.Point(117, 35);
            this.checkBox_Period.Name = "checkBox_Period";
            this.checkBox_Period.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Period.TabIndex = 40;
            this.checkBox_Period.UseVisualStyleBackColor = true;
            this.checkBox_Period.Click += new System.EventHandler(this.checkBox_Period_Click);
            // 
            // label_Period
            // 
            this.label_Period.AutoSize = true;
            this.label_Period.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Period.Location = new System.Drawing.Point(138, 32);
            this.label_Period.Name = "label_Period";
            this.label_Period.Size = new System.Drawing.Size(112, 21);
            this.label_Period.TabIndex = 39;
            this.label_Period.Text = "Промежуток";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(142, 56);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(104, 25);
            this.dateTimePicker2.TabIndex = 38;
            this.dateTimePicker2.Value = new System.DateTime(2020, 8, 11, 0, 0, 0, 0);
            // 
            // checkBox_Date
            // 
            this.checkBox_Date.AutoSize = true;
            this.checkBox_Date.Location = new System.Drawing.Point(15, 35);
            this.checkBox_Date.Name = "checkBox_Date";
            this.checkBox_Date.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Date.TabIndex = 37;
            this.checkBox_Date.UseVisualStyleBackColor = true;
            this.checkBox_Date.Click += new System.EventHandler(this.checkBox_Date_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_RowsAmount,
            this.Label_Median,
            this.Label_SumFactory,
            this.Label_SumSup,
            this.Label_SumDif});
            this.statusStrip1.Location = new System.Drawing.Point(0, 361);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1234, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Label_RowsAmount
            // 
            this.Label_RowsAmount.Name = "Label_RowsAmount";
            this.Label_RowsAmount.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_Median
            // 
            this.Label_Median.Name = "Label_Median";
            this.Label_Median.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SumFactory
            // 
            this.Label_SumFactory.Name = "Label_SumFactory";
            this.Label_SumFactory.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SumSup
            // 
            this.Label_SumSup.Name = "Label_SumSup";
            this.Label_SumSup.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SumDif
            // 
            this.Label_SumDif.Name = "Label_SumDif";
            this.Label_SumDif.Size = new System.Drawing.Size(0, 17);
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Date.Location = new System.Drawing.Point(36, 32);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(47, 21);
            this.label_Date.TabIndex = 33;
            this.label_Date.Text = "Дата";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 25);
            this.dateTimePicker1.TabIndex = 32;
            this.dateTimePicker1.Value = new System.DateTime(2020, 8, 11, 0, 0, 0, 0);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(0, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1234, 267);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортToolStripMenuItem,
            this.своднаяТаблицаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // label_Supliers
            // 
            this.label_Supliers.AutoSize = true;
            this.label_Supliers.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Supliers.Location = new System.Drawing.Point(477, 32);
            this.label_Supliers.Name = "label_Supliers";
            this.label_Supliers.Size = new System.Drawing.Size(110, 21);
            this.label_Supliers.TabIndex = 34;
            this.label_Supliers.Text = "Поставщики";
            // 
            // button_Start
            // 
            this.button_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_Start.Location = new System.Drawing.Point(672, 55);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(66, 25);
            this.button_Start.TabIndex = 44;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // labelDelta
            // 
            this.labelDelta.AutoSize = true;
            this.labelDelta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDelta.Location = new System.Drawing.Point(748, 30);
            this.labelDelta.Name = "labelDelta";
            this.labelDelta.Size = new System.Drawing.Size(232, 21);
            this.labelDelta.TabIndex = 46;
            this.labelDelta.Text = "Допустимое отклонение, %";
            // 
            // label_MedDelta
            // 
            this.label_MedDelta.AutoSize = true;
            this.label_MedDelta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MedDelta.Location = new System.Drawing.Point(748, 57);
            this.label_MedDelta.Name = "label_MedDelta";
            this.label_MedDelta.Size = new System.Drawing.Size(231, 21);
            this.label_MedDelta.TabIndex = 47;
            this.label_MedDelta.Text = "Отклонение от медианы, %";
            // 
            // textBox_Delta
            // 
            this.textBox_Delta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.textBox_Delta.Location = new System.Drawing.Point(978, 28);
            this.textBox_Delta.Name = "textBox_Delta";
            this.textBox_Delta.Size = new System.Drawing.Size(45, 24);
            this.textBox_Delta.TabIndex = 49;
            this.textBox_Delta.Text = "0";
            this.textBox_Delta.TextChanged += new System.EventHandler(this.textBox_Delta_TextChanged);
            // 
            // textBox_medDelta
            // 
            this.textBox_medDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.textBox_medDelta.Location = new System.Drawing.Point(978, 55);
            this.textBox_medDelta.Name = "textBox_medDelta";
            this.textBox_medDelta.Size = new System.Drawing.Size(45, 24);
            this.textBox_medDelta.TabIndex = 50;
            this.textBox_medDelta.Text = "0";
            this.textBox_medDelta.TextChanged += new System.EventHandler(this.textBox_medDelta_TextChanged);
            // 
            // button_Analyz
            // 
            this.button_Analyz.Enabled = false;
            this.button_Analyz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_Analyz.Location = new System.Drawing.Point(1027, 55);
            this.button_Analyz.Name = "button_Analyz";
            this.button_Analyz.Size = new System.Drawing.Size(66, 25);
            this.button_Analyz.TabIndex = 51;
            this.button_Analyz.Text = "Анализ";
            this.button_Analyz.UseVisualStyleBackColor = true;
            this.button_Analyz.Click += new System.EventHandler(this.button_Analyz_Click);
            // 
            // label_max
            // 
            this.label_max.AutoSize = true;
            this.label_max.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_max.Location = new System.Drawing.Point(1029, 30);
            this.label_max.Name = "label_max";
            this.label_max.Size = new System.Drawing.Size(69, 21);
            this.label_max.TabIndex = 52;
            this.label_max.Text = "Max, %";
            // 
            // textBox_max
            // 
            this.textBox_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.textBox_max.Location = new System.Drawing.Point(1104, 28);
            this.textBox_max.Name = "textBox_max";
            this.textBox_max.Size = new System.Drawing.Size(45, 24);
            this.textBox_max.TabIndex = 53;
            this.textBox_max.Text = "0";
            this.textBox_max.TextChanged += new System.EventHandler(this.textBox_max_TextChanged);
            // 
            // statusStrip_selected
            // 
            this.statusStrip_selected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_SelectedRows,
            this.Label_selectedMedian,
            this.Label_SelectedFactory,
            this.Label_SelectedSup,
            this.Label_SelectedDiff});
            this.statusStrip_selected.Location = new System.Drawing.Point(0, 339);
            this.statusStrip_selected.Name = "statusStrip_selected";
            this.statusStrip_selected.Size = new System.Drawing.Size(1234, 22);
            this.statusStrip_selected.TabIndex = 54;
            this.statusStrip_selected.Text = "statusStrip2";
            this.statusStrip_selected.Visible = false;
            this.statusStrip_selected.VisibleChanged += new System.EventHandler(this.statusStrip_selected_VisibleChanged);
            // 
            // Label_SelectedRows
            // 
            this.Label_SelectedRows.Name = "Label_SelectedRows";
            this.Label_SelectedRows.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_selectedMedian
            // 
            this.Label_selectedMedian.Name = "Label_selectedMedian";
            this.Label_selectedMedian.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SelectedFactory
            // 
            this.Label_SelectedFactory.Name = "Label_SelectedFactory";
            this.Label_SelectedFactory.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SelectedSup
            // 
            this.Label_SelectedSup.Name = "Label_SelectedSup";
            this.Label_SelectedSup.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SelectedDiff
            // 
            this.Label_SelectedDiff.Name = "Label_SelectedDiff";
            this.Label_SelectedDiff.Size = new System.Drawing.Size(0, 17);
            // 
            // своднаяТаблицаToolStripMenuItem
            // 
            this.своднаяТаблицаToolStripMenuItem.Name = "своднаяТаблицаToolStripMenuItem";
            this.своднаяТаблицаToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.своднаяТаблицаToolStripMenuItem.Text = "Сводная таблица";
            this.своднаяТаблицаToolStripMenuItem.Click += new System.EventHandler(this.своднаяТаблицаToolStripMenuItem_Click);
            // 
            // MilkTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 383);
            this.Controls.Add(this.statusStrip_selected);
            this.Controls.Add(this.textBox_max);
            this.Controls.Add(this.label_max);
            this.Controls.Add(this.button_Analyz);
            this.Controls.Add(this.textBox_medDelta);
            this.Controls.Add(this.textBox_Delta);
            this.Controls.Add(this.label_MedDelta);
            this.Controls.Add(this.labelDelta);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.checkedListBox_Supliers);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.checkBox_Period);
            this.Controls.Add(this.label_Period);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.checkBox_Date);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label_Supliers);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1250, 422);
            this.Name = "MilkTable";
            this.Text = "MilkTable";
            this.Load += new System.EventHandler(this.MilkTable_Load);
            this.ResizeBegin += new System.EventHandler(this.MilkTable_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MilkTable_ResizeEnd);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip_selected.ResumeLayout(false);
            this.statusStrip_selected.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkedListBox_Supliers;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.CheckBox checkBox_Period;
        private System.Windows.Forms.Label label_Period;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox checkBox_Date;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Label_RowsAmount;
        private System.Windows.Forms.ToolStripStatusLabel Label_Median;
        private System.Windows.Forms.ToolStripStatusLabel Label_SumSup;
        private System.Windows.Forms.ToolStripStatusLabel Label_SumFactory;
        private System.Windows.Forms.ToolStripStatusLabel Label_SumDif;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.Label label_Supliers;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label labelDelta;
        private System.Windows.Forms.Label label_MedDelta;
        private System.Windows.Forms.TextBox textBox_Delta;
        private System.Windows.Forms.TextBox textBox_medDelta;
        private System.Windows.Forms.Button button_Analyz;
        private System.Windows.Forms.Label label_max;
        private System.Windows.Forms.TextBox textBox_max;
        private System.Windows.Forms.StatusStrip statusStrip_selected;
        private System.Windows.Forms.ToolStripStatusLabel Label_SelectedRows;
        private System.Windows.Forms.ToolStripStatusLabel Label_selectedMedian;
        private System.Windows.Forms.ToolStripStatusLabel Label_SelectedFactory;
        private System.Windows.Forms.ToolStripStatusLabel Label_SelectedSup;
        private System.Windows.Forms.ToolStripStatusLabel Label_SelectedDiff;
        private System.Windows.Forms.ToolStripMenuItem своднаяТаблицаToolStripMenuItem;
    }
}