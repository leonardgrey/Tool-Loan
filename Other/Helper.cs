using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolLoan.Classes
{
    class Helper
    {
        public string[] GetRow(string[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

    }
}
