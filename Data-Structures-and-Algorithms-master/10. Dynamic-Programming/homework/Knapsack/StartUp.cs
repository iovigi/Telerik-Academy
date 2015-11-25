namespace Knapsack
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
        }

        public static int MaxWeight(int[,] items, bool[] isUsed, int currentWeight, int currentPrice, int maxWeight)
        {
            int maxPrice = currentPrice;

            for (int i = 0; i < items.Length; i++)
            {
                if (!isUsed[i] && items[i, 0] + currentWeight <= maxWeight && maxPrice < currentPrice + items[i, 1])
                {
                    isUsed[i] = true;
                    maxPrice = MaxWeight(items, isUsed, items[i, 0] + currentWeight, maxPrice + items[i, 1], maxWeight);
                    isUsed[i] = false;
                }
            }

            return maxPrice;
        }
    }
}
