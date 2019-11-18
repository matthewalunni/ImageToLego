using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageToLego.Helper
{
    public static class TwoDimensionalArrayHelper
    {
        public static T[] Column<T>(this T[,] array, int col)
        {
            return Enumerable.Range(0, array.GetLength(1))
                .Select(x => array[col, x])
                .ToArray();
        }

        public static T[] Row<T>(this T[,] array, int row)
        {
            return Enumerable.Range(0, array.GetLength(0))
                .Select(x => array[x, row])
                .ToArray();
        }

    }
}
