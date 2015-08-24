namespace SimpleMathOperationComparer
{
    using System;
    using System.Diagnostics;

    public class IncrementComparer
    {
        public static void Compare(int countOfTest)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();

            int numberInt = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                numberInt++;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for int of increment:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();

            long numberLong = 1L;

            for (int i = 0; i < countOfTest; i++)
            {
                numberLong++;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for long of increment:{0}", stopwatch.ElapsedMilliseconds);

            float numberSingle = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                numberSingle++;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for float of increment:{0}", stopwatch.ElapsedMilliseconds);

            double numberDouble = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                numberDouble++;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for double of increment:{0}", stopwatch.ElapsedMilliseconds);

            decimal numberDecimal = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                numberDecimal++;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for decimal of increment:{0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
