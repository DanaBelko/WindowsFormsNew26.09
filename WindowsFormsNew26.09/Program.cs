using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsNew26._09
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
            string currentDirectoryPath = Path.GetDirectoryName(Application.ExecutablePath);

            if (!File.Exists($"{currentDirectoryPath}\\DataB1.db"))
            {
                new DataB1("Data Source=DataB1.db;Version=3;").InitializeDatabase();
            }
            Application.Run(new MainForm1());
        }
    }
}
