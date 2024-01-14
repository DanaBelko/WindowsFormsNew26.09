using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsNew26._09
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 50);

            loginField.Text = "Введите логин";
            loginField.ForeColor = Color.Gray;

            passField.Text = "Введите пароль";
            passField.UseSystemPasswordChar = false;
            passField.ForeColor = Color.Gray;
        }

      

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            Close.ForeColor = Color.White;
        }


        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private string userName;
        private void Login_Click_1(object sender, EventArgs e)
        {
            if (userAuthSucceess())
            {
                userName = loginField.Text;
                MessageBox.Show("Вход выполнен!");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private bool userAuthSucceess()
        {
            if (incorrectFiledsOnForm())
            {
                MessageBox.Show("Некорректные поля на форме");
                return false;
            }
            if (hasUser(loginField.Text, passField.Text))
                return true;
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                return false;
            }
        }

        private bool incorrectFiledsOnForm()
        {
            if (isUnCorrectField(loginField.Text) || isUnCorrectField(passField.Text))
                return true;

            return false;
        }
        private bool isUnCorrectField(string field)
        {
            if (String.IsNullOrWhiteSpace(field))
                return true;
            return false;
        }

        private bool hasUser(string login, string password)
        {
            User user = new User(login, password);

            return user.IsCorrect();
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите логин")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите логин";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите пароль")
            {
                passField.Text = "";
                passField.UseSystemPasswordChar = true;
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "Введите пароль";
                passField.UseSystemPasswordChar = false;
                passField.ForeColor = Color.Gray;
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            var dialogResultMainForm1 = new RegisterForm1().ShowDialog();
            if (dialogResultMainForm1 == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
