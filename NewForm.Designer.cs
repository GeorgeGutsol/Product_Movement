namespace SQL_product_movement
{
    partial class NewForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_NewForm = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label_RowsAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_VolumeSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_ValueSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_RecievedValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SourceValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_diff = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip_selected = new System.Windows.Forms.StatusStrip();
            this.Label_SelectedRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_RecSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SrcSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_difSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_difRelSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NewForm)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.statusStrip_selected.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // импортToolStripMenuItem
            // 
            this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
            this.импортToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.импортToolStripMenuItem.Text = "Экспорт";
            this.импортToolStripMenuItem.Click += new System.EventHandler(this.импортToolStripMenuItem_Click);
            // 
            // dataGridView_NewForm
            // 
            this.dataGridView_NewForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NewForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_NewForm.Location = new System.Drawing.Point(0, 24);
            this.dataGridView_NewForm.Name = "dataGridView_NewForm";
            this.dataGridView_NewForm.Size = new System.Drawing.Size(800, 404);
            this.dataGridView_NewForm.TabIndex = 1;
            this.dataGridView_NewForm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.newDataGrid_CellContentClick);
            this.dataGridView_NewForm.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 10;
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
            // statusStrip_selected
            // 
            this.statusStrip_selected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label_SelectedRows,
            this.Label_RecSel,
            this.Label_SrcSel,
            this.Label_difSel,
            this.Label_difRelSel});
            this.statusStrip_selected.Location = new System.Drawing.Point(0, 409);
            this.statusStrip_selected.Name = "statusStrip_selected";
            this.statusStrip_selected.Size = new System.Drawing.Size(800, 22);
            this.statusStrip_selected.TabIndex = 16;
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
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.statusStrip_selected);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView_NewForm);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NewForm";
            this.Text = "NewForm";
            this.ResizeBegin += new System.EventHandler(this.NewForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.NewForm_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NewForm)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip_selected.ResumeLayout(false);
            this.statusStrip_selected.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView_NewForm;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel Label_RowsAmount;
        public System.Windows.Forms.ToolStripStatusLabel Label_VolumeSum;
        public System.Windows.Forms.ToolStripStatusLabel Label_ValueSelected;
        public System.Windows.Forms.ToolStripStatusLabel Label_RecievedValue;
        public System.Windows.Forms.ToolStripStatusLabel Label_SourceValue;
        public System.Windows.Forms.ToolStripStatusLabel Label_diff;
        private System.Windows.Forms.StatusStrip statusStrip_selected;
        private System.Windows.Forms.ToolStripStatusLabel Label_SelectedRows;
        private System.Windows.Forms.ToolStripStatusLabel Label_RecSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_SrcSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_difSel;
        private System.Windows.Forms.ToolStripStatusLabel Label_difRelSel;
    }
}