using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Board
    {
        private int[,] _board = new int[9, 9];

        public bool InsertValue(int row, int col, int value)
        {
            bool result = IsValidMove(row, col, value);
            if(result) _board[row, col] = value;
            return result;
        }

        public bool IsValidMove(int row, int col, int value)
        {
            // Проверка строки и столбца
            for (int i = 0; i < 9; i++)
            {
                if (_board[row, i] == value || _board[i, col] == value)
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
                    if (_board[i, j] == value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void DisplayBoard(int selectedRow, int selectedCol)
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
                        Console.Write($"[{(_board[i, j] != 0 ? _board[i, j].ToString() : ".")}] ");
                    }
                    else
                    {
                        Console.Write(_board[i, j] != 0 ? _board[i, j].ToString() : ". ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
