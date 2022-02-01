namespace SQL_product_movement
{
    partial class FormChooseServer
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
            this.label_Server = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_dateRange = new System.Windows.Forms.Label();
            this.numericUpDown_dateRange = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dateRange)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Server.Location = new System.Drawing.Point(30, 23);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(68, 21);
            this.label_Server.TabIndex = 4;
            this.label_Server.Text = "Сервер";
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(34, 105);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(121, 30);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "ОК";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(291, 105);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(121, 30);
            this.button_Cancel.TabIndex = 7;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // textBox_Server
            // 
            this.textBox_Server.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Server.Location = new System.Drawing.Point(121, 20);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(291, 26);
            this.textBox_Server.TabIndex = 8;
            // 
            // label_dateRange
            // 
            this.label_dateRange.AutoSize = true;
            this.label_dateRange.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dateRange.Location = new System.Drawing.Point(30, 64);
            this.label_dateRange.Name = "label_dateRange";
            this.label_dateRange.Size = new System.Drawing.Size(185, 21);
            this.label_dateRange.TabIndex = 9;
            this.label_dateRange.Text = "Область поиска (дни)";
            // 
            // numericUpDown_dateRange
            // 
            this.numericUpDown_dateRange.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_dateRange.Location = new System.Drawing.Point(232, 61);
            this.numericUpDown_dateRange.Name = "numericUpDown_dateRange";
            this.numericUpDown_dateRange.Size = new System.Drawing.Size(69, 26);
            this.numericUpDown_dateRange.TabIndex = 10;
            this.numericUpDown_dateRange.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // FormChooseServer
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(439, 147);
            this.Controls.Add(this.numericUpDown_dateRange);
            this.Controls.Add(this.label_dateRange);
            this.Controls.Add(this.textBox_Server);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_Server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChooseServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormChooseServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dateRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label_dateRange;
        private System.Windows.Forms.NumericUpDown numericUpDown_dateRange;
    }
}