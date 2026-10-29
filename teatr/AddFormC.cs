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
    public partial class AddFormC : Form
    {
        public AddFormC()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                DataRow nRow = main.teatrDataSet.Tables[2].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = TbFullname.Text;
                nRow[2] = TbEmail.Text;
                nRow[3] = TbUserRole.Text;
                main.teatrDataSet.Tables[2].Rows.Add(nRow);
                main.пользователиTableAdapter.Update(main.teatrDataSet.Пользователи);
                main.teatrDataSet.Tables[2].AcceptChanges();
                main.dataGridView1.Refresh();
                TbFullname.Text = "";
                TbEmail.Text = "";
                TbUserRole.Text = "";
            }
        }
    }
}