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
    public partial class AddFormD : Form
    {
        public AddFormD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                DataRow nRow = main.teatrDataSet.Tables[3].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = tbidplay.Text;
                nRow[2] = tbdate.Text;
                nRow[3] = tbtime.Text;
                nRow[4] = tbpriceticket.Text;
                nRow[5] = tbcreatedby.Text;
                main.teatrDataSet.Tables[3].Rows.Add(nRow);
                main.билетыTableAdapter.Update(main.teatrDataSet.Билеты);
                main.teatrDataSet.Tables[3].AcceptChanges();
                main.dataGridView1.Refresh();
                tbidplay.Text = "";
                tbdate.Text = "";
                tbtime.Text = "";
                tbpriceticket.Text = "";
                tbcreatedby.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}