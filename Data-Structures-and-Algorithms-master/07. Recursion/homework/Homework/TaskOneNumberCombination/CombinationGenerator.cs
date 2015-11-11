using System.Collections.Generic;

namespace TaskOneNumberCombination
{
    using System;

    public class CombinationGenerator
    {
        public readonly int N;

        public CombinationGenerator(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("invalid n");
            }

            this.N = n;
        }

        public IEnumerable<int[]> GetCombination()
        {
            List<int[]> combinations = new List<int[]>();

            this.GetCombination(ref combinations, new int[this.N], 0);

            return combinations;
        }



        private void GetCombination(ref List<int[]> combinations, int[] buffer, int currentIndex)
        {
            if (currentIndex == this.N)
            {
                combinations.Add(buffer);

                return;
            }

            buffer[currentIndex] = 1;
            this.GetCombination(ref combinations, buffer, currentIndex + 1);
        }
    }
}
