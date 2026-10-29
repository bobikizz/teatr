using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teatr
{
    public partial class AddFormE : Form
    {
        public AddFormE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                DataRow nRow = main.teatrDataSet.Tables[4].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = tbtitle.Text;
                main.teatrDataSet.Tables[4].Rows.Add(nRow);
                main.спектаклиTableAdapter.Update(main.teatrDataSet.Спектакли);
                main.teatrDataSet.Tables[4].AcceptChanges();
                main.dataGridView1.Refresh();
                tbtitle.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
