namespace SimpleMathOperationComparer
{
    using System;
    using System.Diagnostics;

    public static class SubtrackComparer
    {
        public static void Compare(int countOfTest)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();

            int numberInt = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                int result = numberInt - numberInt;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for int of subtracting:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();

            long numberLong = 1L;

            for (int i = 0; i < countOfTest; i++)
            {
                long result = numberLong + numberLong;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for long of subtracting:{0}", stopwatch.ElapsedMilliseconds);

            float numberSingle = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                float result = numberSingle - numberSingle;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for float of subtracting:{0}", stopwatch.ElapsedMilliseconds);

            double numberDouble = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                double result = numberDouble - numberDouble;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for double of subtracting:{0}", stopwatch.ElapsedMilliseconds);

            decimal sumNumberDecimal = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                decimal result = sumNumberDecimal - sumNumberDecimal;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for decimal of subtracting:{0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
