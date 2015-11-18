namespace TaskTwoColorfulRabbits
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int countOfRabbits = int.Parse(Console.ReadLine());

            int[] rabbits = new int[1000002];
            int result = 0;
            for (int i = 0; i < countOfRabbits; i++)
            {
                int rabbitAnswer = int.Parse(Console.ReadLine()) + 1;
                rabbits[rabbitAnswer]++;
            }

            for (int i = 0; i < rabbits.Length; i++)
            {
                if (rabbits[i] == 0)
                {
                    continue;
                }

                if (rabbits[i] <= i)
                {
                    result += i;
                }
                else
                {
                    result += (int)Math.Ceiling((double)rabbits[i] / i) * i;
                }
            }

            Console.WriteLine(result);
        }
    }
}
