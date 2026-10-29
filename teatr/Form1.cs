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
        private bool showingOnlyMyTickets = false; // Переключатель режимов
        private TabPage СкрытаяВкладкаПользователи;
        private TabPage СкрытаяВкладкаАктеры;
        public Form1()
        {
            InitializeComponent();
            СкрытаяВкладкаПользователи = tabPage3;
            СкрытаяВкладкаАктеры = tabPage1;
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
            // Проверяем роль, полученную из формы авторизации
            // Сначала скрываем вкладки для обычного пользователя
            if (LoginForm.CurrentUserLogin == "fio@gmail.com")
            {
                this.Text = "Режим: Администратор";
                // 1. Возвращаем вкладки на место, если они были скрыты
                if (!btnBuyTicket.TabPages.Contains(СкрытаяВкладкаПользователи))
                    btnBuyTicket.TabPages.Add(СкрытаяВкладкаПользователи);

                if (!btnBuyTicket.TabPages.Contains(СкрытаяВкладкаАктеры))
                    btnBuyTicket.TabPages.Add(СкрытаяВкладкаАктеры);

                // 2. Делаем кнопки управления снова видимыми
                SaveButtonB.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button16.Visible = true;
                button6.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button18.Visible = true;
                button11.Visible = true;
                button12.Visible = true;
                button13.Visible = true;
                button14.Visible = true;
                button19.Visible = false;
                button20.Visible = false;

                // 3. Разрешаем редактировать главную таблицу
                dataGridView2.ReadOnly = false;
                dataGridView4.ReadOnly = false;
                dataGridView5.ReadOnly = false;
                try
                {
                    this.билетыTableAdapter.Fill(this.teatrDataSet.Билеты);

                    // На всякий случай перепривязываем оригинальный DataSet к вашей таблице,
                    // чтобы стереть отфильтрованную таблицу (DataTable) обычного пользователя
                    dataGridView2.DataSource = this.билетыBindingSource;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка обновления данных для Администратора: " + ex.Message);
                }

                // Ваш стандартный код загрузки ВСЕХ билетов для админа:
                // this.biлетыTableAdapter.Fill(this.театрDataSet.Билеты);

                // Администратор загружает ВСЕ билеты без фильтров
                // Сюда автоматически вставится ваш стандартный код, например:
                // this.билетыTableAdapter.Fill(this.театрDataSet.Билеты);
            }
            else
            {
                this.Text = "Режим: Пользователь";

                // 1. СКРЫВАЕМ ТАБЛИЦЫ «АКТЕРЫ» И «ПОЛЬЗОВАТЕЛИ»
                // (Замените tabPageПользователи и tabPageАктеры на реальные Name ваших вкладок)
                if (btnBuyTicket.TabPages.Contains(СкрытаяВкладкаПользователи))
                    btnBuyTicket.TabPages.Remove(СкрытаяВкладкаПользователи);

                if (btnBuyTicket.TabPages.Contains(СкрытаяВкладкаАктеры))
                    btnBuyTicket.TabPages.Remove(СкрытаяВкладкаАктеры);
                SaveButtonB.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button16.Visible = false;
                button6.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button18.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button19.Visible = true;
                button20.Visible = true;
                // 2. ФИЛЬТРУЕМ БИЛЕТЫ ПО USER_ID ИЗ СКРИНШОТА
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=teatr.accdb;";

                // Запрос ищет билеты, где значение в колонке user_id совпадает с ID вошедшего
                // Безопасный запрос: выбирает билеты пользователя ИЛИ все доступные свободные места
                string query = "SELECT ticket_id, performance_id, seat_number, price, ticket_status, reserved_until, user_id " +
                               "FROM [Билеты] WHERE [user_id] = @userId OR [ticket_status] = 'свободен'";


                using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn))
                        {
                            // Передаем числовой ID текущего пользователя в параметр
                            cmd.Parameters.AddWithValue("@userId", LoginForm.CurrentUserId);

                            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(cmd);
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);

                            // Выводим только его личные билеты в DataGridView
                            // Замените dataGridViewБилеты на имя вашего элемента таблицы билетов
                            dataGridView2.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки билетов пользователя: " + ex.Message);
                    }
                }

                // Делаем таблицу доступной только для чтения для пользователя
                dataGridView2.ReadOnly = true;
                dataGridView4.ReadOnly = true;
                dataGridView5.ReadOnly = true;
            }
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

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            // 1. Прячем текущую главную форму, чтобы она не мешалась
            this.Hide();

            // 2. Сбрасываем старые данные авторизации
            LoginForm.CurrentUserLogin = "";
            LoginForm.CurrentUserId = 0;

            // 3. Создаем и показываем форму входа заново
            LoginForm loginForm = new LoginForm();

            // Если на форме входа успешно ввели новые данные и нажали "Войти"
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Перезапускаем метод загрузки главной формы Form1_Load,
                // чтобы таблицы отфильтровались под НОВОГО пользователя, а кнопки/вкладки снова скрылись или открылись
                Form1_Load(this, EventArgs.Empty);

                // Показываем главную форму обратно, но уже с обновленными правами
                this.Show();
            }
            else
            {
                // Если пользователь закрыл окно авторизации крестиком и не зашел — полностью закрываем программу
                this.Close();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            {
                // 1. Проверяем, выбрана ли строка в таблице билетов
                if (dataGridView2.CurrentRow == null)
                {
                    MessageBox.Show("Пожалуйста, выберите билет из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Получаем ID билета и его текущий статус из выделенной строки
                // Берём данные по индексам колонок: 0 — это первая колонка (ID), 4 — пятая колонка (Статус)
                int selectedTicketId = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                string currentStatus = dataGridView2.CurrentRow.Cells[4].Value.ToString().Trim().ToLower();


                // 3. ПРОВЕРКА ПО СТАТУСУ: Купить можно только свободный (или забронированный) билет
                if (currentStatus == "продан")
                {
                    MessageBox.Show("Этот билет уже кем-то куплен! Выберите другой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (currentStatus != "свободен" && currentStatus != "забронирован")
                {
                    MessageBox.Show("Данный билет недоступен для покупки.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Подтверждение операции пользователем
                DialogResult result = MessageBox.Show($"Вы уверены, что хотите купить билет №{selectedTicketId}?",
                    "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                // 5. Запрос к Access: меняем статус на 'продан' и записываем ID текущего пользователя
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=teatr.accdb;";
                string query = "UPDATE [Билеты] SET [ticket_status] = 'продан', [user_id] = @userId WHERE [ticket_id] = @ticketId";

                using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn))
                        {
                            // Передаем реальный ID вошедшего пользователя (например, 3) и ID билета
                            cmd.Parameters.AddWithValue("@userId", LoginForm.CurrentUserId);
                            cmd.Parameters.AddWithValue("@ticketId", selectedTicketId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Билет успешно оформлен на вас", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 6. Обновляем таблицу на экране, чтобы купленный билет закрепился за пользователем
                                Form1_Load(this, EventArgs.Empty);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении статуса билета в БД: " + ex.Message, "Ошибка СУБД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
            private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, выбрана ли хотя бы одна строка в таблице билетов
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите билет из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Получаем ticket_id из выделенной строки DataGridView
            // Убедитесь, что колонка в вашем DataGridView называется именно "ticket_id" (или укажите её индекс, например, 0)
            int selectedTicketId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ticket_id"].Value);
            string currentStatus = dataGridView2.CurrentRow.Cells["ticket_status"].Value.ToString();

            // 3. Проверяем статус билета (нельзя купить то, что уже продано)
            if (currentStatus == "продан")
            {
                MessageBox.Show("Этот билет уже продан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Подтверждение покупки
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите купить билет №{selectedTicketId}?",
                "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            // 5. Запрос к базе данных Access на обновление статуса и привязку к пользователю
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=teatr.accdb;";
            string query = "UPDATE [Билеты] SET [ticket_status] = 'продан', [user_id] = @userId WHERE [ticket_id] = @ticketId";

            using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn))
                    {
                        // Подставляем ID текущего авторизованного пользователя и ID выбранного билета
                        cmd.Parameters.AddWithValue("@userId", LoginForm.CurrentUserId);
                        cmd.Parameters.AddWithValue("@ticketId", selectedTicketId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Билет успешно куплен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 6. Срочно обновляем таблицу на экране, чтобы пользователь увидел изменения
                            // Вызываем метод Form1_Load, который заново перечитает базу данных
                            Form1_Load(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Не удалось выполнить покупку. Возможно, билет был удален.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при оформлении покупки в БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Меняем режим на противоположный
            showingOnlyMyTickets = !showingOnlyMyTickets;

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=teatr.accdb;";
            string query = "";

            if (showingOnlyMyTickets)
            {
                // РЕЖИМ 1: Показываем ТОЛЬКО купленные билеты этого пользователя
                query = "SELECT ticket_id, performance_id, seat_number, price, ticket_status, reserved_until, user_id " +
                        "FROM [Билеты] WHERE [user_id] = @userId";

                button20.Text = "Показать все доступные билеты"; // Меняем текст на кнопке
            }
            else
            {
                // РЕЖИМ 2: Возвращаем стандартный вид (Свои купленные + Все со статусом 'свободен')
                query = "SELECT ticket_id, performance_id, seat_number, price, ticket_status, reserved_until, user_id " +
                        "FROM [Билеты] WHERE [user_id] = @userId OR [ticket_status] = 'свободен'";

                button20.Text = "Показать мои билеты"; // Возвращаем исходный текст
            }

            // Выполняем запрос к базе данных Access
            using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn))
                    {
                        // Передаем ID текущего авторизованного пользователя
                        cmd.Parameters.AddWithValue("@userId", LoginForm.CurrentUserId);

                        System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(cmd);
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);

                        // Обновляем таблицу на экране
                        dataGridView2.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при фильтрации билетов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
