using System.Xml.XPath;

namespace TaskSix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static string[] set;

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

            foreach (var result in GetPermutations(set, k))
            {
                Console.WriteLine("({0})", string.Join(" ", result));
            }
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }
    }
}
