using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class LevelForm : Form
    {
        private int button_size_ = 30; //размер кнопки
        private int space_ = 10; //расстояние между кнопками
        private int start_X_; //расстояние между кнопками
        private int start_Y_ = 150; //расстояние между кнопками
        private int[,] black_cell_count_in_row_; //массив в индесах которого сколько "черных" ячеек в ряду 
        private int[,] black_cell_count_in_col_; //массив в индесах которого сколько "черных" ячеек в столбце
        public LevelForm(int N)
        {
            DrawLevel(N);
            InitializeComponent();
        }
        private void DrawLevel(int level)
        {
            GameData game_data = new GameData(level);
            Button[,] buttons = new Button[game_data.finished_crossword_.GetLength(0), game_data.finished_crossword_.GetLength(1)];
            black_cell_count_in_row_ = CalculateBlackCellCountInRow(game_data.finished_crossword_);
            black_cell_count_in_col_ = CalculateBlackCellCountInCol(game_data.finished_crossword_);
            start_X_ = 170 > (1024 - ((game_data.finished_crossword_.GetLength(1) * button_size_) + ((game_data.finished_crossword_.GetLength(1) + 1) * space_))) / 2 ? 170 : (1024 - ((game_data.finished_crossword_.GetLength(1) * button_size_) + ((game_data.finished_crossword_.GetLength(1) + 1) * space_))) / 2;
            start_Y_ = 80 > (768 - ((game_data.finished_crossword_.GetLength(0) * button_size_) + (game_data.finished_crossword_.GetLength(0) * space_))) / 2 ? 80 : (768 - ((game_data.finished_crossword_.GetLength(0) * button_size_) + (game_data.finished_crossword_.GetLength(0) * space_))) / 2;
            for (int i = 0; i < game_data.finished_crossword_.GetLength(0); ++i)
            {
                for (int j = 0; j < game_data.finished_crossword_.GetLength(1); ++j)
                {
                    if (i == 0)
                    {
                        ModLabel label = new ModLabel();
                        string text = ArrayColToString(black_cell_count_in_col_, j);
                        label.Width = button_size_;
                        label.Height = button_size_ * ((text.Length / 2) + 1) + 10;
                        label.Text = text;
                        label.Font = new Font("Comic Sans MS", 16);
                        label.Location = new Point(start_X_ + j * (button_size_ + space_), start_Y_ - label.Height - space_);
                        label.ForeColor = ColorTranslator.FromHtml("#063fba");
                        label.BorderStyle = BorderStyle.None;
                        label.BackColor = ColorTranslator.FromHtml("#ba06b4"); ;
                        this.Controls.Add(label);
                    }
                    if (j == 0)
                    {
                        ModLabel label = new ModLabel();
                        string text = ArrayRowToString(black_cell_count_in_row_, i);
                        label.Width = button_size_ * ((text.Length / 2) + 1);
                        label.Height = button_size_;
                        label.Text = text;
                        label.Font = new Font("Comic Sans MS", 16);
                        label.Location = new Point(start_X_ - label.Width - space_, start_Y_ + i * (button_size_ + space_));
                        label.ForeColor = ColorTranslator.FromHtml("#063fba");
                        label.BorderStyle = BorderStyle.None;
                        label.BackColor = ColorTranslator.FromHtml("#ba06b4");
                        this.Controls.Add(label);
                    }
                    Button button = new Button();
                    button.Size = new Size(button_size_, button_size_);
                    button.Location = new Point(start_X_ + j * (button_size_ + space_), start_Y_ + i * (button_size_ + space_));
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Tag = new Point(i, j);
                    button.Click += (sender, e) => Cell_Click(sender, e, game_data.user_field_ ,game_data.finished_crossword_);
                    this.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e, int[,] change_crossword, int[,] finish_crossword)
        {
            Button clicked_button = (Button)sender;
            Point position = (Point)clicked_button.Tag;
            int i = position.X;
            int j = position.Y;
            if (change_crossword[i, j] == 0)
            {
                change_crossword[i, j] = 1;
                Console.WriteLine("Enabled"); 
                clicked_button.BackColor = Color.Black;
            }
            else
            {
                change_crossword[i, j] = 0;
                Console.WriteLine("Disabled");
                clicked_button.BackColor = Color.White;
            }
            if (isSolved(change_crossword, finish_crossword))
            {
                MessageBox.Show("Уровень пройден!");
                DisableButtons();
            }
        }

        private bool isSolved(int[,] change_cross, int[,] finish_cross)
        {
            for (int i = 0; i < change_cross.GetLength(0); i++)
            {
                for (int j = 0; j < change_cross.GetLength(1); j++)
                {
                    if (change_cross[i, j] != finish_cross[i, j]) return false;
                }
            }
            return true;
        }

        private void DisableButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Tag != null && control.Tag is Point)
                {
                    ((Button)control).Enabled = false;
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ChooseLevelForm choose_level_form = new ChooseLevelForm();
            choose_level_form.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            choose_level_form.Show();
        }

        private int[,] CalculateBlackCellCountInRow(int[,] field)
        {
            int row_count = field.GetLength(0);
            int col_count = field.GetLength(1);
            int[,] result = new int[row_count, row_count];
            for (int i = 0; i < row_count; i++)
            {
                int sum = 0;
                int count = 0;
                for (int j = 0; j < col_count; j++)
                {
                    if ((field[i, j] == 0) && (sum != 0))
                    {
                        result[i, count] = sum;
                        sum = 0;
                        count++;
                        
                    }
                    else
                    {
                        sum += field[i, j];
                    }
                    
                }
                result[i, count] = sum;
            }
            return result;
        }
        private int[,] CalculateBlackCellCountInCol(int[,] field)
        {
            int row_count = field.GetLength(0);
            int col_count = field.GetLength(1);
            int[,] result = new int[col_count, col_count];
            for (int j = 0; j < col_count; j++)
            {
                int sum = 0;
                int count = 0;
                for (int i = 0; i < row_count; i++)
                {
                    if ((field[i, j] == 0) && (sum != 0))
                    {
                        result[count, j] = sum;
                        sum = 0;
                        count++;
                    }
                    else
                    {
                        sum += field[i, j];
                    }
                }
                result[count, j] = sum;
            }
            return result;
        }
        private string ArrayRowToString(int[,] array, int i)
        {
            string result = "";
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == 0) break;
                result += (array[i, j].ToString() + " ");
            }
            result = result.Remove(result.Length - 1);
            return result;
        }
        private string ArrayColToString(int[,] array, int j)
        {
            string result = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, j] == 0) break;
                result += array[i, j].ToString() + " ";
            }
            result = result.Remove(result.Length - 1);
            return result;
        }
    }
}
