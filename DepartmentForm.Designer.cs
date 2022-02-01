namespace SQL_product_movement
{
    partial class DepartmentForm
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
            this.button_Go = new System.Windows.Forms.Button();
            this.checkBox_Period = new System.Windows.Forms.CheckBox();
            this.label_Period = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.checkBox_Date = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label_RowsAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_VolumeSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_ValueSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_RecievedValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SourceValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_diff = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_Objects = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label_Department = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_Dep = new System.Windows.Forms.ComboBox();
            this.checkedListBox_Objects = new System.Windows.Forms.CheckedListBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.statusStrip_selected = new System.Windows.Forms.StatusStrip();
            this.Label_SelectedRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_RecSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SrcSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_difSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_difRelSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip_selected.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Go
            // 
            this.button_Go.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_Go.Location = new System.Drawing.Point(520, 56);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(96, 25);
            this.button_Go.TabIndex = 26;
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
            this.checkBox_Period.TabIndex = 25;
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
            this.label_Period.TabIndex = 24;
            this.label_Period.Text = "Промежуток";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(142, 56);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(104, 25);
            this.dateTimePicker2.TabIndex = 23;
            this.dateTimePicker2.Value = new System.DateTime(2020, 8, 11, 0, 0, 0, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // checkBox_Date
            // 
            this.checkBox_Date.AutoSize = true;
            this.checkBox_Date.Location = new System.Drawing.Point(15, 35);
            this.checkBox_Date.Name = "checkBox_Date";
            this.checkBox_Date.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Date.TabIndex = 22;
            this.checkBox_Date.UseVisualStyleBackColor = true;
            this.checkBox_Date.Click += new System.EventHandler(this.checkBox_Date_Click);
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
            this.statusStrip1.TabIndex = 21;
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
            // label_Objects
            // 
            this.label_Objects.AutoSize = true;
            this.label_Objects.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Objects.Location = new System.Drawing.Point(727, 32);
            this.label_Objects.Name = "label_Objects";
            this.label_Objects.Size = new System.Drawing.Size(82, 21);
            this.label_Objects.TabIndex = 19;
            this.label_Objects.Text = "Объекты";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Date.Location = new System.Drawing.Point(36, 32);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(47, 21);
            this.label_Date.TabIndex = 18;
            this.label_Date.Text = "Дата";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 25);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.Value = new System.DateTime(2020, 8, 11, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Department.Location = new System.Drawing.Point(394, 32);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(95, 21);
            this.label_Department.TabIndex = 16;
            this.label_Department.Text = "Отделение";
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
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // comboBox_Dep
            // 
            this.comboBox_Dep.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Dep.FormattingEnabled = true;
            this.comboBox_Dep.Location = new System.Drawing.Point(365, 56);
            this.comboBox_Dep.Name = "comboBox_Dep";
            this.comboBox_Dep.Size = new System.Drawing.Size(149, 25);
            this.comboBox_Dep.TabIndex = 27;
            // 
            // checkedListBox_Objects
            // 
            this.checkedListBox_Objects.CheckOnClick = true;
            this.checkedListBox_Objects.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.checkedListBox_Objects.FormattingEnabled = true;
            this.checkedListBox_Objects.Location = new System.Drawing.Point(697, 56);
            this.checkedListBox_Objects.Name = "checkedListBox_Objects";
            this.checkedListBox_Objects.Size = new System.Drawing.Size(142, 23);
            this.checkedListBox_Objects.TabIndex = 28;
            this.checkedListBox_Objects.MouseEnter += new System.EventHandler(this.checkedListBox_Objects_MouseEnter);
            this.checkedListBox_Objects.MouseLeave += new System.EventHandler(this.checkedListBox_Objects_MouseLeave);
            // 
            // button_Start
            // 
            this.button_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button_Start.Location = new System.Drawing.Point(869, 56);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(66, 25);
            this.button_Start.TabIndex = 29;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
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
            this.statusStrip_selected.TabIndex = 30;
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
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 383);
            this.Controls.Add(this.statusStrip_selected);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.checkedListBox_Objects);
            this.Controls.Add(this.comboBox_Dep);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.checkBox_Period);
            this.Controls.Add(this.label_Period);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.checkBox_Date);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label_Objects);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label_Department);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(915, 422);
            this.Name = "DepartmentForm";
            this.Text = "DepartmentForm";
            this.Load += new System.EventHandler(this.DepartmentForm_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
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

        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.CheckBox checkBox_Period;
        private System.Windows.Forms.Label label_Period;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox checkBox_Date;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Label_RowsAmount;
        private System.Windows.Forms.ToolStripStatusLabel Label_VolumeSum;
        private System.Windows.Forms.ToolStripStatusLabel Label_ValueSelected;
        private System.Windows.Forms.ToolStripStatusLabel Label_RecievedValue;
        private System.Windows.Forms.ToolStripStatusLabel Label_SourceValue;
        private System.Windows.Forms.ToolStripStatusLabel Label_diff;
        private System.Windows.Forms.Label label_Objects;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label_Department;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_Dep;
        private System.Windows.Forms.CheckedListBox checkedListBox_Objects;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.StatusStrip statusStrip_selected;
        private System.Windows.Forms.ToolStripStatusLabel Label_SelectedRows;
        private System.Windows.Forms.ToolStripStatusLabel Label_RecSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_SrcSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_difSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_difRelSel;
    }
}