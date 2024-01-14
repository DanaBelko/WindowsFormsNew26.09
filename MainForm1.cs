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
    public partial class MainForm1 : Form
    {
        private char[] characters = new char[] {'A', 'B', 'C', 'D', 'E', 'F',
            'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
            'R', 'S', 'T', 'U' ,'V', 'W', 'X', 'Y',
            'Z' };
        private int N;
        public MainForm1()
        {
            InitializeComponent();
            N = characters.Length;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            var dialogResultMainForm1 = new LoginForm().ShowDialog();
            if (dialogResultMainForm1 == DialogResult.Cancel)
            {
                Close();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите ключ и текст");
                return;
            }
            string result = Encode(textBox2.Text, textBox1.Text);
            Writer writer = new Writer("Шифровка.txt");
            writer.WriteLine(result);
            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите ключ и текст");
                return;
            }
            string readString = "";
            try
            {
                Reader reader = new Reader("Шифровка.txt");
                readString = reader.ReadLine();
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при чтении файла Шифровка.txt");
                return;
            }
            string result = Decode(readString, textBox1.Text);
            Writer writer = new Writer("Расшифровка.txt");
            writer.WriteLine(result);
            writer.Close();
            MessageBox.Show("Результат сохранен в файл");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form MainForm1 = new MainForm1();
            MainForm1.Show();
            this.Hide();
        }
    }
}
