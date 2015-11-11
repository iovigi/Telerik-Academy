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

            var buffer = new int[this.N];
            for (int i = 0; i < this.N; i++)
            {
                buffer[i] = 1;
            }

            this.GetCombination(ref combinations, buffer, 0);

            return combinations;
        }



        private void GetCombination(ref List<int[]> combinations, int[] buffer, int currentIndex)
        {
            if (currentIndex == this.N)
            {
                int[] temp = new int[this.N];
                buffer.CopyTo(temp,0);

                combinations.Add(temp);

                return;
            }

            this.GetCombination(ref combinations, buffer, currentIndex + 1);

            if (buffer[currentIndex] < this.N)
            {
                buffer[currentIndex]++;
                this.GetCombination(ref combinations, buffer, currentIndex);
            }

            buffer[currentIndex] = 1;
        }
    }
}
