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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "teatrDataSet.Спектакли". При необходимости она может быть перемещена или удалена.
            this.спектаклиTableAdapter.Fill(this.teatrDataSet.Спектакли);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "teatrDataSet.Представления". При необходимости она может быть перемещена или удалена.
            this.представленияTableAdapter.Fill(this.teatrDataSet.Представления);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "teatrDataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.teatrDataSet.Пользователи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "teatrDataSet.Билеты". При необходимости она может быть перемещена или удалена.
            this.билетыTableAdapter.Fill(this.teatrDataSet.Билеты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "teatrDataSet.Актеры". При необходимости она может быть перемещена или удалена.
            this.актерыTableAdapter.Fill(this.teatrDataSet.Актеры);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            актерыTableAdapter.Update(teatrDataSet);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView4_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView5_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddFormA af = new AddFormA();
            af.Owner = this;
            af.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchFormA sf = new SearchFormA();
            sf.Owner = this;
            sf.Show();
        }

        private void SaveButtonB_Click(object sender, EventArgs e)
        {
            билетыTableAdapter.Update(teatrDataSet);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddFormB af = new AddFormB();
            af.Owner = this;
            af.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchFormB sf = new SearchFormB();
            sf.Owner = this;
            sf.Show();
        }

        private void SaveButtonC_Click(object sender, EventArgs e)
        {
            пользователиTableAdapter.Update(teatrDataSet);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddFormC af = new AddFormC();
            af.Owner = this;
            af.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SearchFormC sf = new SearchFormC();
            sf.Owner = this;
            sf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            представленияTableAdapter.Update(teatrDataSet);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddFormD af = new AddFormD();
            af.Owner = this;
            af.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            спектаклиTableAdapter.Update(teatrDataSet);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddFormE af = new AddFormE();
            af.Owner = this;
            af.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SearchFormD sf = new SearchFormD();
            sf.Owner = this;
            sf.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SearchFormE sf = new SearchFormE();
            sf.Owner = this;
            sf.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
