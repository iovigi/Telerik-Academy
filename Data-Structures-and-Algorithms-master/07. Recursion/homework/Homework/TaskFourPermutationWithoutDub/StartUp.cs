namespace TaskThreePermutationWithoutDub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int[]> permutation = new List<int[]>();

            GeneratePermutation(ref permutation, new int[] {0, 0, 0}, new bool[3], 0);

            Console.WriteLine(string.Join(",", permutation.Select(x => string.Format("({0})", string.Join(" ", x)))));
        }

        public static void GeneratePermutation(ref List<int[]> permutations ,int[] buffer, bool[] isUsed,int currentIndex)
        {
            if (currentIndex == buffer.Length)
            {
               permutations.Add(buffer.ToArray());

                return;
            }

            for (int i = 0; i < buffer.Length; i++)
            {
                if (isUsed[i])
                {
                    continue;
                }

                isUsed[i] = true;
                buffer[currentIndex] = i + 1;
                GeneratePermutation(ref permutations, buffer, isUsed, currentIndex + 1);
                isUsed[i] = false;
            }
        }
    }
}
