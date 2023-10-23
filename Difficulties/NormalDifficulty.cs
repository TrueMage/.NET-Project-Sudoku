using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Difficulties
{
    internal class NormalDifficulty : FillStrategy
    {
        public NormalDifficulty()
        {
            RemoveNumbers = 35;
        }
    }
}
