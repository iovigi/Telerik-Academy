namespace _3.ArrayManager
{
    using System;

    public class Manager
    {
        public void ChechAndPrintArray(int[] array, int expectedValue)
        {
            bool isFoundExpectedValue = false;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);

                if (i % 10 == 0 && array[i] == expectedValue)
                {
                    isFoundExpectedValue = true;

                    break;
                }
            }

            // More code here
            if (isFoundExpectedValue)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
