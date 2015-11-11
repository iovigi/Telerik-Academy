using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEight
{
    public class Program
    {
        private static char[,] labyrinth;
        private static readonly List<string> path = new List<string>();

        public static void Main(string[] args)
        {
            

            labyrinth = new char[100, 100];

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    labyrinth[i, j] = ' ';
                }
            }

            labyrinth[99, 99] = 'e';
            bool existsPath = false;
            FindExit(0, 0, ref existsPath, string.Empty);
        }

        private static void FindExit(int rowIndex, int colIndex, ref bool existsPath, string direction)
        {
            if ((colIndex < 0) || (rowIndex < 0) || (colIndex >= labyrinth.GetLength(1))
                || (rowIndex >= labyrinth.GetLength(0)) || existsPath)
            {
                return;
            }

            if (labyrinth[rowIndex, colIndex] == 'e')
            {
                existsPath = true;
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

            FindExit(rowIndex, colIndex - 1, ref existsPath, "L");
            FindExit(rowIndex - 1, colIndex, ref existsPath, "U");
            FindExit(rowIndex, colIndex + 1, ref existsPath, "R");
            FindExit(rowIndex + 1, colIndex, ref existsPath, "D");

            labyrinth[rowIndex, colIndex] = ' ';
            if (path.Count > 0)
            {
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
