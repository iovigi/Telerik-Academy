namespace RepeatingPattern
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();

            for (int i = 1; i <= str.Length; i++)
            {
                if (str.Length % i != 0)
                {
                    continue;
                }

                var pattern = str.Substring(0, i);
                bool flag = true;

                for (int j = i; j < str.Length; j += i)
                {
                    if (pattern != str.Substring(j, i))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    Console.WriteLine(pattern);
                    break;
                }
            }
        }
    }
}
