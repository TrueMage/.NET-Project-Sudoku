namespace Sudoku
{
    internal class Program
    {
        static void Main()
        {
            int[,] board = new int[9, 9];
            int selectedRow = -1;
            int selectedCol = -1;

            while (true)
            {
                Console.Clear();
                DisplayBoard(board, selectedRow, selectedCol);
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Выбрать клетку");
                Console.WriteLine("2. Заполнить ячейку");
                Console.WriteLine("3. Завершить игру");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введите номер строки (1-9): ");
                    selectedRow = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Введите номер столбца (1-9): ");
                    selectedCol = int.Parse(Console.ReadLine()) - 1;
                }
                else if (choice == "2")
                {
                    if (selectedRow != -1 && selectedCol != -1)
                    {
                        Console.Write("Введите значение (1-9): ");
                        int value = int.Parse(Console.ReadLine());

                        if (IsValidMove(board, selectedRow, selectedCol, value))
                        {
                            board[selectedRow, selectedCol] = value;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимый ход. Пожалуйста, проверьте правила судоку.");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пожалуйста, выберите клетку, в которую хотите вставить цифру.");
                        Console.ReadLine();
                    }
                }
                else if (choice == "3")
                {
                    // Завершение игры
                    break;
                }
            }
        }

        static void DisplayBoard(int[,] board, int selectedRow, int selectedCol)
        {
            Console.WriteLine("Доска судоку:");
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("-------------------------------");
                }

                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        Console.Write("| ");
                    }

                    if (i == selectedRow && j == selectedCol)
                    {
                        Console.Write($"[{(board[i, j] != 0 ? board[i, j].ToString() : ".")}] ");
                    }
                    else
                    {
                        Console.Write(board[i, j] != 0 ? board[i, j].ToString() : ". ");
                    }
                }
                Console.WriteLine();
            }
        }

        static bool IsValidMove(int[,] board, int row, int col, int value)
        {
            // Проверка строки и столбца
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == value || board[i, col] == value)
                {
                    return false;
                }
            }

            // Проверка 3x3 квадрата
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (board[i, j] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
