namespace Bracket
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var expression = Console.ReadLine();
            var length = expression.Length;

            var matrix = new long[length + 1, length + 2];
            matrix[0, 0] = 1;

            for (var i = 1; i <= length; i++)
            {
                if (expression[i - 1] == '(')
                {
                    matrix[i, 0] = 0;
                }
                else
                {
                    matrix[i, 0] = matrix[i - 1, 1];
                }

                for (var j = 1; j <= length; j++)
                {
                    if (expression[i - 1] == '?')
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + matrix[i - 1, j + 1];
                    }
                    else if(expression[i - 1] == '(')
                    {
                        matrix[i, j] = matrix[i - 1, j - 1];
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j + 1];
                    }
                }
            }

            Console.WriteLine(matrix[length, 0]);
        }
    }
}
