namespace SuperSum
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lineItems = Console.ReadLine().Split(' ');

            int k = int.Parse(lineItems[0]);
            int n = int.Parse(lineItems[1]);

            int[,] buffer = new int[k, n];

            for (int i = 0; i < k; i++)
            {
                buffer[i, 0] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                buffer[0, i] = buffer[0, i - 1] + i + 1;
            }

            for (int i = 1; i < k; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    buffer[i, j] = buffer[i - 1, j] + buffer[i, j - 1];
                }
            }

            Console.WriteLine(buffer[k - 1, n - 1]);
        }
    }
}
