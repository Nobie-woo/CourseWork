using System;
using System.Windows.Forms;

namespace CourseWork
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main_form = new MainForm();
            main_form.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(main_form);
        }
    }
}
