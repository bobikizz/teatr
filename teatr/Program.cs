using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teatr
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Создаем форму логина
            LoginForm loginForm = new LoginForm();

            // Показываем форму входа как модальное окно.
            // Если пользователь успешно вошел (нажата кнопка и сработал DialogResult.OK)
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Запускаем главную форму программы. 
                // ВНИМАНИЕ: Если ваша главная форма называется иначе (например, MainForm), замените Form1 на ваше название
                Application.Run(new Form1());
            }
        }
    }
}