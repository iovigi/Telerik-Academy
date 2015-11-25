namespace Tribonachi
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lineItems = Console.ReadLine().Split(' ');

            int n = int.Parse(lineItems[3]);

            int[] array = new int[n + 1];
            array[0] = int.Parse(lineItems[0]);
            array[1] = int.Parse(lineItems[1]);
            array[2] = int.Parse(lineItems[2]);

            for (int i = 3; i < n; i++)
            {
                array[i] = array[i - 1] + array[i - 2] + array[i - 3];
            }

            Console.WriteLine(array[n - 1]);
        }
    }
}
