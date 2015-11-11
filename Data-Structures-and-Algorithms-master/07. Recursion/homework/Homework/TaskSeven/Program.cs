using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSeven
{
    class Program
    {
        private static char[,] labyrinth =
        {
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {'*', '*', '*', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        private static readonly List<string> path = new List<string>();

        static void Main()
        {
            int startingRow = 0;
            int startingCol = 0;

            FindExit(startingRow, startingCol, string.Empty);
        }

        private static void FindExit(int rowIndex, int colIndex, string direction)
        {
            if ((colIndex < 0) || (rowIndex < 0) || (colIndex >= labyrinth.GetLength(1))
                || (rowIndex >= labyrinth.GetLength(0)))
            {
                return;
            }
            if (labyrinth[rowIndex, colIndex] == 'e')
            {
                Console.WriteLine(string.Join(" , ", path));
            }

            if (labyrinth[rowIndex, colIndex] != ' ')
            {
                return;
            }

            labyrinth[rowIndex, colIndex] = 'u';

            if (direction != string.Empty)
            {
                path.Add(direction);
            }

            FindExit(rowIndex, colIndex - 1, "L");
            FindExit(rowIndex - 1, colIndex, "U");
            FindExit(rowIndex, colIndex + 1, "R");
            FindExit(rowIndex + 1, colIndex, "D");

            labyrinth[rowIndex, colIndex] = ' ';
            if (path.Count > 0)
            {
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
