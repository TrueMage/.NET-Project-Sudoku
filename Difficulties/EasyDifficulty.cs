using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Difficulties
{
    internal class EasyDifficulty : FillStrategy
    {
        public EasyDifficulty()
        {
            RemoveNumbers = 25;
        }
    }
}


