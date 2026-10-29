using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teatr
{
    public partial class LoginForm : Form
    {
        // Статическая переменная, в которую мы сохраним введенный логин.
        // Главная форма прочитает его, чтобы понять, кто зашел.
        public static string CurrentUserLogin = "";
        public static int CurrentUserId = 0; // Добавьте эту строчку

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtUsername.Text.Trim().ToLower();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Словарь: Email -> (Пароль, user_id из базы данных)
            // Заполните строго по вашей таблице "Пользователи"
            var credentials = new Dictionary<string, (string Password, int UserId)>()
    {
        { "fio@gmail.com",  ("admin123", 2) }, // Администратор (id = 2)
        { "urod@gmail.com", ("user123",  3) }, // Пользователь (id = 3)
        { "hors1@gmail.com",("user456",  4) }, // Пользователь (id = 4)
        { "jjjo@gmail.com", ("user789",  5) }  // Пользователь (id = 5)
    };

            if (credentials.ContainsKey(login) && credentials[login].Password == password)
            {
                // Запоминаем глобально логин и ID вошедшего пользователя
                LoginForm.CurrentUserLogin = login;
                LoginForm.CurrentUserId = credentials[login].UserId; // Эту переменную нужно создать вверху класса

                MessageBox.Show("Вход успешно выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный Email или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}