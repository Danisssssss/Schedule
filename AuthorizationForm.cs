using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void sendAuthorizationBtn_Click(object sender, EventArgs e)
        {
            string cLogin = "user";
            string cPsw = "ghjuhfvvbhjdfybt";
            string login, psw;

            if (loginInput.Text == "" || passwordInput.Text == "")
            {
                MessageBox.Show("Пустые поля недопустимы!", "ОШИБКА ВВОДА ДАННЫХ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                login = loginInput.Text.Trim();
                psw = passwordInput.Text.Trim();
                if (login == cLogin && psw == cPsw)
                {
                    this.Hide();
                    MainForm newMainFrom = new MainForm();
                    newMainFrom.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильные логин или пароль!", "ОШИБКА ВВОДА ДАННЫХ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
