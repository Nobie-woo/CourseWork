using System;
using System.IO;

namespace CourseWork
{
    public class GameData
    {
        //--------------Задаем Переменные--------------------
        public int level_number_ { get; set; }
        public int[,] user_field_ { get; set; }
        public int[,] finished_crossword_ { get; set; } //матрица заполненная 1 и 0



        public GameData(int level_number) //Конструктор на создание
        {
            level_number_ = level_number;
            finished_crossword_ = ReadCrosswordDataFromFile(level_number_);
            user_field_ = CreateEmptyUserField(finished_crossword_.GetLength(0), finished_crossword_.GetLength(1));
        }
        private static int[,] ReadCrosswordDataFromFile(int level_number) //функция возвращает двумерный массив и является приватной (используется только в самом классе) и статической используется для класса а не объекта класса
        {
            string file_name = $"Crossword{level_number}.txt"; //генерируем имя файла на основе номера уровня
            string currentDirectory = Directory.GetCurrentDirectory();
            string file_path = Path.Combine(currentDirectory, "Crosswords", file_name); // комбинируем путь до папки с уровнями и имя файла
            if (File.Exists(file_path)) // проверяем существование файла
            {
                string[] lines = File.ReadAllLines(file_path); //считываем что в файле построчно
                int row_count = lines.Length; //сколько строк -> столько рядов
                int[,] crossword_data = new int[row_count, lines[0].Split(' ').Length]; //инициализация двумерного массива

                for (int i = 0; i < row_count; i++) //проход по строчно i номер строки
                {
                    string[] values = lines[i].Split(' '); //сплитим строку по пробелам
                    for (int j = 0; j < crossword_data.GetLength(1); j++) //идем столько раз сколько столбцов в двумерном массиве
                    {
                        crossword_data[i, j] = Convert.ToInt32(values[j]); //ставим в i j интовое значение j элемент строки
                    }
                }
                return crossword_data; //возвращаем массив
            }
            else
            {
                // обработка ситуации, если файл не найден
                throw new FileNotFoundException("Уровень не найден.", file_name);
            }
        }
        private static int[,] CreateEmptyUserField(int row_count, int col_count) //создание пустого пользовательского массива
        {
            return new int[row_count, col_count];
        }
    }
}
