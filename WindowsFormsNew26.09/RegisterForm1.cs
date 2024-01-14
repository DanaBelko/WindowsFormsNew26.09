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
    public partial class RegisterForm1 : Form
    {
        public RegisterForm1()
        {
            InitializeComponent();

            loginField.Text = "Введите логин";
            loginField.ForeColor = Color.Gray;

            passField.Text = "Введите пароль";
            passField.UseSystemPasswordChar = false;
            passField.ForeColor = Color.Gray;

            passField2.Text = "Повторите пароль";
            passField2.UseSystemPasswordChar = false;
            passField2.ForeColor = Color.Gray;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastPoint;
      
        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
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
                passField.UseSystemPasswordChar= false;
                passField.ForeColor = Color.Gray;
            }
        }

        private void passField2_Enter(object sender, EventArgs e)
        {
            if (passField2.Text == "Повторите пароль")
            {
                passField2.Text = "";
                passField2.UseSystemPasswordChar = true;
                passField2.ForeColor = Color.Black;
            }
        }

        private void passField2_Leave(object sender, EventArgs e)
        {
            if (passField2.Text == "")
            {
                passField2.Text = "Повторите пароль";
                passField2.UseSystemPasswordChar = false;
                passField2.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            bool hasCif = false; //есть ли цифры
            bool hasAlp = false; //есть ли латинские буквы
            for (int i = 0; i < passField.Text.Length; i++)
            {
                hasCif = hasCif || ((passField.Text[i] >= '0') && (passField.Text[i] <= '9'));
                hasAlp = hasAlp || ((passField.Text[i] >= 'a') && (passField.Text[i] <= 'z')) || ((passField.Text[i] >= 'A') && (passField.Text[i] <= 'Z'));
            }
            //Получили: есть или нет в пароле цифры, есть или нет в пароле латинские буквы(отдельными 2 - мя переменными)
            if (loginField.Text == "" || loginField.Text == null || loginField.Text == "Введите логин") 
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (loginField.Text.Trim() != loginField.Text)
            {
                MessageBox.Show("Есть неверные (пустые?) поля");
                return;
            }
            if (passField.Text.Trim() != passField2.Text)
            {
                MessageBox.Show("Есть неверные (пустые?) поля");
                return;
            }
            else if (passField.Text.Length < 8)
            {
                MessageBox.Show("Пароль менее 8 символов");
                return;
            }
            else if (!(hasCif & hasAlp))
            {
                MessageBox.Show("В пароле требуются латинские буквы и цифры");
                return;
            }
            else if (passField.Text != passField2.Text)
            {
                MessageBox.Show("Два пароля не совпадают");
                return;
            }
            DataB1 db = new DataB1("Data Source=DataB1.db;Version=3;");
            if (passField.Text == passField2.Text && isCorrect())
            {
                if (db.createUser(loginField.Text, passField.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                return;
            }
            else
            {
                MessageBox.Show("Ошибка ввода данных");
            }
        }

        private bool isCorrect()
        {
            return !(String.IsNullOrWhiteSpace(passField.Text)
                && String.IsNullOrWhiteSpace(passField2.Text)
                && String.IsNullOrWhiteSpace(loginField.Text));
                this.Hide();
                var dialogResultMainForm1 = new MainForm1().ShowDialog();
                if (dialogResultMainForm1 == DialogResult.Cancel)
                {
                    Close();
                }
        }

      
    }
}
