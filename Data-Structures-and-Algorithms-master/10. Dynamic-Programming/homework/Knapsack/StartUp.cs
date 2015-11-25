namespace Knapsack
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxWeight = int.Parse(Console.ReadLine());

            int[,] items = new int[n, 2];

            for (int i = 0; i < n; i++)
            {
                int weight = int.Parse(Console.ReadLine());
                int cost = int.Parse(Console.ReadLine());

                items[i, 0] = weight;
                items[i, 1] = cost;
            }

            int max = DinamicMaxPrice(items, maxWeight);

            Console.WriteLine(max);
        }

        private static int DinamicMaxPrice(int[,] items, int maxWeight)
        {
            int i, w;
            int[,] K = new int[items.GetLength(0) + 1, maxWeight + 1];

            for (i = 0; i <= items.GetLength(0); i++)
            {
                for (w = 0; w <= maxWeight; w++)
                {
                    if (i == 0 || w == 0)
                    { 
                        K[i, w] = 0;
                    }
                    else if (items[i - 1, 0] <= w)
                    {
                        K[i, w] = Max(items[i - 1, 1] + K[i - 1, w - items[i - 1, 0]], K[i - 1, w]);
                    }
                    else
                    { 
                        K[i, w] = K[i - 1, w];
                    }
                }
            }

            return K[items.GetLength(0), maxWeight];
        }

        private static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}
