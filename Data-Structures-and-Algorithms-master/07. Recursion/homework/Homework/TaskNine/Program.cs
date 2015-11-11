using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNine
{
    public class Program
    {
        private static char[,] matrix =
        {
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {'*', '*', '*', '*', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', '*'},
        };

        public static void Main(string[] args)
        {
            int bestLength = int.MinValue;

            for (int i = 0; i < matrix.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    var currentLength = 0;

                    DFS(i, j, ref currentLength);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                    }
                }
            }

            Console.WriteLine(bestLength);
        }

        private static void DFS(int rowIndex, int columnIndex, ref int currentLength)
        {
            if (!IsPossible(rowIndex, columnIndex))
            {
                return;
            }

            currentLength++;
            matrix[rowIndex, columnIndex] = 'u';

            DFS(rowIndex, columnIndex - 1, ref currentLength);
            DFS(rowIndex, columnIndex + 1, ref currentLength);
            DFS(rowIndex - 1, columnIndex, ref currentLength);
            DFS(rowIndex + 1, columnIndex, ref currentLength);

            matrix[rowIndex, columnIndex] = ' ';
        }

        private static bool IsPossible(int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrix.GetLength(0))
            {
                return false;
            }

            if (columnIndex < 0 || columnIndex >= matrix.GetLength(0))
            {
                return false;
            }

            return matrix[rowIndex, columnIndex] == ' ';
        }
    }
}
