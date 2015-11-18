namespace TaskOneBinaryPassword
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var password = Console.ReadLine();

            int countOfUknown = 0;

            foreach (var letter in password)
            {
                if (letter == '*')
                {
                    countOfUknown++;
                }
            }

            long result = 1;

            for (int i = 0; i < countOfUknown; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}
