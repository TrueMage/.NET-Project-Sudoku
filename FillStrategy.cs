using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    abstract class FillStrategy
    {
        Random rand = new Random();
        private int _removeNumbers;
        private Board _board;

        public int RemoveNumbers
        {
            get
            {
                return _removeNumbers;
            }
            set
            {
                _removeNumbers = value;
            }
        }

        public virtual void Fill(Board board)
        {
            _board = board;

            // Fill Diagonal
            for (int i = 0; i < 9; i += 3)
                FillSmallBox(i, i);

            FillRemaining(0, 3);

            // Remove numbers from the board
            while (_removeNumbers != 0)
            {
                int boxRow = rand.Next(0, 9);
                int boxCol = rand.Next(0, 9);

                if (_board[boxRow, boxCol] != 0)
                {
                    _removeNumbers--;
                    _board[boxRow, boxCol] = 0;
                }
            }
        }

        #region Private Methods
        private void FillSmallBox(int row, int col)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    List<int> temp = new List<int>();

                    for (int k = 1; k < 10; k++)
                    {
                        temp.Add(k);
                    }

                    for (int k = 0; k < 9; k++)
                    {
                        int randomNum = temp[rand.Next(0, temp.Count())];
                        _board.InsertValue(row + i, col + j, randomNum);
                        temp.Remove(randomNum);
                    }
                }
            }
        }

        private bool FillRemaining(int i, int j)
        {
            if (j >= 9 && i < 8)
            {
                i = i + 1;
                j = 0;
            }
            if (i >= 9 && j >= 9)
                return true;

            if (i < 3)
            {
                if (j < 3)
                    j = 3;
            }
            else if (i < 6)
            {
                if (j == (int)(i / 3) * 3)
                    j = j + 3;
            }
            else
            {
                if (j == 6)
                {
                    i = i + 1;
                    j = 0;
                    if (i >= 9)
                        return true;
                }
            }

            for (int num = 1; num <= 9; num++)
            {
                if (_board.IsValidMove(i, j, num))
                {
                    _board[i, j] = num;
                    if (FillRemaining(i, j + 1))
                        return true;

                    _board[i, j] = 0;
                }
            }
            return false;
        }

        #endregion
    }
}
