namespace SQL_product_movement
{
    partial class CommInfoMilk
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Label_RowsAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_VolumeSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_ValueSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_RecievedValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_SourceValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Label_diff = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.импортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 13;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 404);
            this.dataGridView1.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // импортToolStripMenuItem
            // 
            this.импортToolStripMenuItem.Name = "импортToolStripMenuItem";
            this.импортToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.импортToolStripMenuItem.Text = "Экспорт";
            // 
            // CommInfoMilk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MinimizeBox = false;
            this.Name = "CommInfoMilk";
            this.Text = "CommInfoMilk";
            this.ResizeBegin += new System.EventHandler(this.CommInfoMilk_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.CommInfoMilk_ResizeEnd);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel Label_RowsAmount;
        public System.Windows.Forms.ToolStripStatusLabel Label_VolumeSum;
        public System.Windows.Forms.ToolStripStatusLabel Label_ValueSelected;
        public System.Windows.Forms.ToolStripStatusLabel Label_RecievedValue;
        public System.Windows.Forms.ToolStripStatusLabel Label_SourceValue;
        public System.Windows.Forms.ToolStripStatusLabel Label_diff;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem импортToolStripMenuItem;
    }
}