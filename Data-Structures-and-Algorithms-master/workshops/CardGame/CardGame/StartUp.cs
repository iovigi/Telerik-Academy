using System.Linq;
using System.Security.Principal;

namespace CardGame
{
    using System;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] dp = new int[n, n];

            for (int j = 3; j <= n; j++)
            {
                for (int i = 0; i <= n - j; i++)
                {
                    for (int k = i + 1; k < i + j - 1; k++)
                    {
                        int curr = dp[i, k] + dp[k, i + j - 1] + numbers[k]*(numbers[i] + numbers[i + j - 1]);

                        if (dp[i, i + j - 1] < curr)
                        {
                            dp[i, i + j - 1] = curr;
                        }
                    }
                }
            }

            Console.WriteLine(dp[0, n - 1]);
        }
    }
}
