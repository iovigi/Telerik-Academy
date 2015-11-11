namespace TaskTwoCombinationWithDublicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int[]> combinations = new List<int[]>();

            GetCombination(ref combinations, new int[] { 0, 0, 0 }, 0, 1, 4);

            Console.WriteLine(string.Join(",", combinations.Select(x => string.Format("({0})", string.Join(" ", x)))));
        }

        private static void GetCombination(ref List<int[]> combinations, int[] buffer, int currentIndex, int value, int max)
        {
            if (currentIndex == buffer.Length)
            {
                int[] temp = new int[buffer.Length];
                buffer.CopyTo(temp, 0);

                combinations.Add(temp);

                return;
            }

            buffer[currentIndex] = value;
            GetCombination(ref combinations, buffer, currentIndex + 1, value, max);

            if (value < max)
            {
                GetCombination(ref combinations, buffer, currentIndex, value + 1, max);
            }
        }
    }
}
