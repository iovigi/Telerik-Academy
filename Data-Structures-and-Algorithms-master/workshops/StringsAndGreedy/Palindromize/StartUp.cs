namespace Palindromize
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            if (IsPalindrom(text))
            {
                Console.WriteLine(text);

                return;
            }

            for (int i = 0; i < text.Length; i++)
            {
                var array = text.Substring(0, i).ToCharArray();
                Array.Reverse(array);
                var niceTry = text + new string(array);

                if (IsPalindrom(niceTry))
                {
                    Console.WriteLine(niceTry);

                    break;
                }
            }
        }

        private static bool IsPalindrom(string str)
        {
            for (int i = 0; i < str.Length/2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
