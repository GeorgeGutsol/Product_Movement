using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQL_product_movement
{
    public partial class FormChooseServer : Form
    {
       public string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProductMovement\Config.txt";
        public FormChooseServer()
        {
            InitializeComponent();
        }

        private void FormChooseServer_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(path))
                    using (StreamReader sr = new StreamReader(path))
                    {
                        textBox_Server.Text = sr.ReadLine();
                        string readNumber = sr.ReadLine();
                        sr.Close();
                        if (readNumber == null || readNumber.Trim(' ') == "" || readNumber == "")
                            numericUpDown_dateRange.Value = 2;
                        else numericUpDown_dateRange.Value = Convert.ToDecimal(readNumber);
                        
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\n Возможна ошибка в файле Config.txt", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                if (textBox_Server.Text.Trim(' ') == "" || textBox_Server.Text == "")
                {
                    MessageBox.Show("Укажите корректное имя сервера", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                sw.WriteLine(textBox_Server.Text);
                sw.WriteLine(numericUpDown_dateRange.Value.ToString());
                sw.Close();
            }
            this.Close();
        }

    }
}
