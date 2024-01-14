using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsNew26._09
{
    public partial class MainForm1 : Form
    {
        string alphabet = "abcdefghijklmnoprstuvwxyz ";
        Pl pl = new Pl();
        public MainForm1()
        {
            InitializeComponent();
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
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Поле текст пустое,введите текст для шифрования");
            }
            string keyword = pl.DelDoubleChars(textBox1.Text);
            string newAlphabet = pl.DelKeywordChars(keyword, alphabet);
            char[,] matrix = pl.GetMatrix(keyword, newAlphabet);
            string code = pl.WordN(textBox2.Text);
            List<int> index = pl.GetIndexList(code, matrix);
            string newCode = pl.Encode(index, matrix);
            textBox3.Text = newCode;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Поле текст пустое,введите текст для расшифрования");
            }
            string keyword = pl.DelDoubleChars(textBox1.Text);
            string newAlphabet = pl.DelKeywordChars(keyword, alphabet);
            char[,] matrix = pl.GetMatrix(keyword, newAlphabet);
            string code = pl.WordN(textBox2.Text);
            List<int> index = pl.GetIndexList(code, matrix);
            string newCode = pl.Decode(index, matrix);
            textBox3.Text = newCode;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text Files | *.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0)
            {
                using (StreamWriter SW = new StreamWriter(saveFileDialog.FileName, false))
                {
                    SW.WriteLine(textBox3.Text);
                    SW.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text Files | *.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0)
            {
                using (StreamReader SR = new StreamReader(openFileDialog.FileName))
                {
                    string line = SR.ReadLine();
                    textBox2.Text = line;
                    SR.Close();
                }
            }
        }
    }
}
