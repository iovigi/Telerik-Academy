namespace TaskOneNumberCombination
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CombinationGenerator generator = new CombinationGenerator(2);

            foreach (var buffer in generator.GetCombination())
            {
                Console.WriteLine(string.Join(" ",buffer));
            }
        }
    }
}
