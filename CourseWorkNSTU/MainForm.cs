using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void levelsButton_Click(object sender, EventArgs e)
        {
            ChooseLevelForm choose_level_form = new ChooseLevelForm();
            choose_level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            choose_level_form.Show();
        }
    }
}
