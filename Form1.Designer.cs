namespace SQL_product_movement
{
    public partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_Object = new System.Windows.Forms.ComboBox();
            this.label_Object = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label_Date = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выборСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отделенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label_RowsAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_VolumeSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_ValueSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_RecievedValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SourceValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_diff = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBox_Date = new System.Windows.Forms.CheckBox();
            this.checkBox_Period = new System.Windows.Forms.CheckBox();
            this.label_Period = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button_Go = new System.Windows.Forms.Button();
            this.statusStrip_selected = new System.Windows.Forms.StatusStrip();
            this.Label_SelectedRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_RecSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SrcSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_difSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_difRelSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkedListBox_Time = new System.Windows.Forms.CheckedListBox();
            this.button_Find = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip_selected.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(979, 267);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // comboBox_Object
            // 
            this.comboBox_Object.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Object.FormattingEnabled = true;
            this.comboBox_Object.Location = new System.Drawing.Point(345, 56);
            this.comboBox_Object.Name = "comboBox_Object";
            this.comboBox_Object.Size = new System.Drawing.Size(149, 25);
            this.comboBox_Object.TabIndex = 2;
            this.comboBox_Object.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Object_SelectionChangeCommitted);
            // 
            // label_Object
            // 
            this.label_Object.AutoSize = true;
            this.label_Object.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Object.Location = new System.Drawing.Point(394, 32);
            this.label_Object.Name = "label_Object";
            this.label_Object.Size = new System.Drawing.Size(69, 21);
            this.label_Object.TabIndex = 3;
            this.label_Object.Text = "Объект";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 25);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2020, 8, 11, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Date.Location = new System.Drawing.Point(36, 32);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(47, 21);
            this.label_Date.TabIndex = 5;
            this.label_Date.Text = "Дата";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Time.Location = new System.Drawing.Point(664, 32);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(61, 21);
            this.label_Time.TabIndex = 7;
            this.label_Time.Text = "Время";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборСервераToolStripMenuItem,
            this.экспортToolStripMenuItem,
            this.отделенияToolStripMenuItem,
            this.поставщикиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выборСервераToolStripMenuItem
            // 
            this.выборСервераToolStripMenuItem.Name = "выборСервераToolStripMenuItem";
            this.выборСервераToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.выборСервераToolStripMenuItem.Text = "Настройка";
            this.выборСервераToolStripMenuItem.Click += new System.EventHandler(this.выборСервераToolStripMenuItem_Click);
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFToolStripMenuItem,
            this.cSVToolStripMenuItem});
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.pDFToolStripMenuItem.Text = "PDF";
            this.pDFToolStripMenuItem.Click += new System.EventHandler(this.pDFToolStripMenuItem_Click);
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.cSVToolStripMenuItem.Text = "CSV";
            this.cSVToolStripMenuItem.Click += new System.EventHandler(this.экспортToolStripMenuItem_Click);
            // 
            // отделенияToolStripMenuItem
            // 
            this.отделенияToolStripMenuItem.Name = "отделенияToolStripMenuItem";
            this.отделенияToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.отделенияToolStripMenuItem.Text = "Отделения";
            this.отделенияToolStripMenuItem.Click += new System.EventHandler(this.отделенияToolStripMenuItem_Click);
            // 
            // поставщикиToolStripMenuItem
            // 
            this.поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
            this.поставщикиToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.поставщикиToolStripMenuItem.Text = "Поставщики";
            this.поставщикиToolStripMenuItem.Click += new System.EventHandler(this.поставщикиToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_RowsAmount,
            this.Label_VolumeSum,
            this.Label_ValueSelected,
            this.Label_RecievedValue,
            this.Label_SourceValue,
            this.Label_diff});
            this.statusStrip1.Location = new System.Drawing.Point(0, 361);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(979, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Label_RowsAmount
            // 
            this.Label_RowsAmount.Name = "Label_RowsAmount";
            this.Label_RowsAmount.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_VolumeSum
            // 
            this.Label_VolumeSum.Name = "Label_VolumeSum";
            this.Label_VolumeSum.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_ValueSelected
            // 
            this.Label_ValueSelected.Name = "Label_ValueSelected";
            this.Label_ValueSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_RecievedValue
            // 
            this.Label_RecievedValue.Name = "Label_RecievedValue";
            this.Label_RecievedValue.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SourceValue
            // 
            this.Label_SourceValue.Name = "Label_SourceValue";
            this.Label_SourceValue.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_diff
            // 
            this.Label_diff.Name = "Label_diff";
            this.Label_diff.Size = new System.Drawing.Size(0, 17);
            // 
            // checkBox_Date
            // 
            this.checkBox_Date.AutoSize = true;
            this.checkBox_Date.Location = new System.Drawing.Point(15, 35);
            this.checkBox_Date.Name = "checkBox_Date";
            this.checkBox_Date.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Date.TabIndex = 10;
            this.checkBox_Date.UseVisualStyleBackColor = true;
            this.checkBox_Date.Click += new System.EventHandler(this.checkBox_Date_Click);
            // 
            // checkBox_Period
            // 
            this.checkBox_Period.AutoSize = true;
            this.checkBox_Period.Location = new System.Drawing.Point(117, 35);
            this.checkBox_Period.Name = "checkBox_Period";
            this.checkBox_Period.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Period.TabIndex = 13;
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
            this.label_Period.TabIndex = 12;
            this.label_Period.Text = "Промежуток";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(142, 56);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(104, 25);
            this.dateTimePicker2.TabIndex = 11;
            this.dateTimePicker2.Value = new System.DateTime(2020, 8, 11, 0, 0, 0, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // button_Go
            // 
            this.button_Go.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_Go.Location = new System.Drawing.Point(263, 56);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(41, 25);
            this.button_Go.TabIndex = 14;
            this.button_Go.Text = "Go";
            this.button_Go.UseVisualStyleBackColor = true;
            this.button_Go.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // statusStrip_selected
            // 
            this.statusStrip_selected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_SelectedRows,
            this.Label_RecSel,
            this.Label_SrcSel,
            this.Label_difSel,
            this.Label_difRelSel});
            this.statusStrip_selected.Location = new System.Drawing.Point(0, 339);
            this.statusStrip_selected.Name = "statusStrip_selected";
            this.statusStrip_selected.Size = new System.Drawing.Size(979, 22);
            this.statusStrip_selected.TabIndex = 15;
            this.statusStrip_selected.Text = "statusStrip_selected";
            this.statusStrip_selected.Visible = false;
            this.statusStrip_selected.VisibleChanged += new System.EventHandler(this.statusStrip_selected_VisibleChanged);
            // 
            // Label_SelectedRows
            // 
            this.Label_SelectedRows.Name = "Label_SelectedRows";
            this.Label_SelectedRows.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_RecSel
            // 
            this.Label_RecSel.Name = "Label_RecSel";
            this.Label_RecSel.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_SrcSel
            // 
            this.Label_SrcSel.Name = "Label_SrcSel";
            this.Label_SrcSel.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_difSel
            // 
            this.Label_difSel.Name = "Label_difSel";
            this.Label_difSel.Size = new System.Drawing.Size(0, 17);
            // 
            // Label_difRelSel
            // 
            this.Label_difRelSel.Name = "Label_difRelSel";
            this.Label_difRelSel.Size = new System.Drawing.Size(0, 17);
            // 
            // checkedListBox_Time
            // 
            this.checkedListBox_Time.CheckOnClick = true;
            this.checkedListBox_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkedListBox_Time.FormattingEnabled = true;
            this.checkedListBox_Time.Location = new System.Drawing.Point(535, 57);
            this.checkedListBox_Time.Name = "checkedListBox_Time";
            this.checkedListBox_Time.Size = new System.Drawing.Size(316, 23);
            this.checkedListBox_Time.TabIndex = 16;
            this.checkedListBox_Time.MouseEnter += new System.EventHandler(this.checkedListBox_Time_MouseEnter);
            this.checkedListBox_Time.MouseLeave += new System.EventHandler(this.checkedListBox_Time_MouseLeave);
            // 
            // button_Find
            // 
            this.button_Find.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_Find.Location = new System.Drawing.Point(875, 56);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(80, 25);
            this.button_Find.TabIndex = 17;
            this.button_Find.Text = "Вывести";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 383);
            this.Controls.Add(this.button_Find);
            this.Controls.Add(this.checkedListBox_Time);
            this.Controls.Add(this.statusStrip_selected);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.checkBox_Period);
            this.Controls.Add(this.label_Period);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.checkBox_Date);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label_Object);
            this.Controls.Add(this.comboBox_Object);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(915, 422);
            this.Name = "Form1";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip_selected.ResumeLayout(false);
            this.statusStrip_selected.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_Object;
        private System.Windows.Forms.Label label_Object;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выборСервераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Label_RowsAmount;
        private System.Windows.Forms.ToolStripStatusLabel Label_VolumeSum;
        private System.Windows.Forms.ToolStripStatusLabel Label_RecievedValue;
        private System.Windows.Forms.ToolStripStatusLabel Label_SourceValue;
        private System.Windows.Forms.ToolStripStatusLabel Label_diff;
        private System.Windows.Forms.CheckBox checkBox_Date;
        private System.Windows.Forms.CheckBox checkBox_Period;
        private System.Windows.Forms.Label label_Period;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.ToolStripMenuItem отделенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip_selected;
        private System.Windows.Forms.ToolStripStatusLabel Label_ValueSelected;
        private System.Windows.Forms.ToolStripStatusLabel Label_SelectedRows;
        private System.Windows.Forms.ToolStripStatusLabel Label_RecSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_SrcSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_difSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_difRelSel;
        private System.Windows.Forms.CheckedListBox checkedListBox_Time;
        private System.Windows.Forms.Button button_Find;
    }
}

