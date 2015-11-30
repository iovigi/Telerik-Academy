namespace Rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int[] answers = text.Split(' ')
                .Select(int.Parse)
                .Where(x => x != -1)
                .ToArray();

            Console.WriteLine(MinRabbitsCount(answers));
        }

        public static int MinRabbitsCount(int[] answers)
        {
            var rabbits = new Dictionary<int, int>();

            foreach (var answer in answers)
            {
                if (!rabbits.ContainsKey(answer + 1))
                {
                    rabbits.Add(answer + 1, 0);
                }

                rabbits[answer + 1]++;
            }

            var rabbitsCount = 0;

            foreach (var kv in rabbits)
            {
                int size = kv.Key;
                int count = kv.Value;

                if (count <= size)
                {
                    rabbitsCount += size;
                }
                else
                {
                    var groupCount = (int)Math.Ceiling(count / (decimal)size);

                    rabbitsCount += groupCount * size;
                }
            }

            return rabbitsCount;
        }
    }
}
