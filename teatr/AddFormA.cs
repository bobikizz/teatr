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
    public partial class AddFormA : Form
    {
        public AddFormA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                DataRow nRow = main.teatrDataSet.Tables[0].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = tbperfotmance_id.Text;
                nRow[2] = tbactor_name.Text;
                nRow[3] = tbcharacter_role.Text;
                main.teatrDataSet.Tables[0].Rows.Add(nRow);
                main.актерыTableAdapter.Update(main.teatrDataSet.Актеры);
                main.teatrDataSet.Tables[0].AcceptChanges();
                main.dataGridView1.Refresh();
                tbperfotmance_id.Text = "";
                tbactor_name.Text = "";
                tbcharacter_role.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
