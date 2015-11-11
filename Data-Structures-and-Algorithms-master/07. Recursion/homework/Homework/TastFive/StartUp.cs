namespace TastFive
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static string[] set;

        public static int[] variation;

        public static void Main(string[] args)
        {
            Console.WriteLine("Input n");
            int n = int.Parse(Console.ReadLine());
            set = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Input word {0}", i + 1);
                set[i] = Console.ReadLine();
            }

            Console.WriteLine("Input k");
            int k = int.Parse(Console.ReadLine());
            variation = new int[k];

            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index == variation.Length)
            {
                PrintVariation();

                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                variation[index] = i;
                GenerateVariationsWithRepetitions(index + 1);
            }
        }

        private static void PrintVariation()
        {
            Console.WriteLine("({0})", string.Join(" ", variation.Select(x => set[x])));
        }
    }
}
