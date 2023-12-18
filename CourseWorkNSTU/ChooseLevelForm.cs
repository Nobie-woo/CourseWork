using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class ChooseLevelForm : Form
    {
        public ChooseLevelForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            MainForm main_form = new MainForm();
            main_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            main_form.Show();
        }

        private void level01Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(1);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level02Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(2);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level03Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(3);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level04Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(4);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level05Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(5);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level06Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(6);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level07Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(7);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level08Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(8);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }

        private void level09Button_Click(object sender, EventArgs e)
        {
            LevelForm level_form = new LevelForm(9);
            level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            level_form.Show();
        }
    }
}