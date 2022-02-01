using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_product_movement
{
    public partial class CommInfoMilk : Form
    {
        Size defaultSize, currentSize;

        public CommInfoMilk()
        {
            InitializeComponent();
        }

        private void CommInfoMilk_ResizeBegin(object sender, EventArgs e)
        {
            defaultSize = this.Size;
        }

        private void CommInfoMilk_ResizeEnd(object sender, EventArgs e)
        {
            currentSize = this.Size;
            dataGridView1.Size = new Size(dataGridView1.Size.Width,
                dataGridView1.Size.Height + currentSize.Height - defaultSize.Height);
            dataGridView1.Update();
        }
    }
}
