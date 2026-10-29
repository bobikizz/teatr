using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace teatr
{
    public partial class AddFormB : Form
    {
        public AddFormB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBtnB_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                DataRow nRow = main.teatrDataSet.Tables[1].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = tbPerformance_id.Text;
                nRow[2] = tbSeat_number.Text;
                nRow[3] = tbPrice.Text;
                nRow[4] = tbTicketStatus.Text;
                nRow[5] = tbReservedUntil.Text;
                nRow[6] = TbUserId.Text;
                main.teatrDataSet.Tables[1].Rows.Add(nRow);
                main.билетыTableAdapter.Update(main.teatrDataSet.Билеты);
                main.teatrDataSet.Tables[1].AcceptChanges();
                main.dataGridView1.Refresh();
                tbPerformance_id.Text = "";
                tbSeat_number.Text = "";
                tbPrice.Text = "";
                tbTicketStatus.Text = "";
                tbReservedUntil.Text = "";
                TbUserId.Text = "";
            }
        }
    }
}
