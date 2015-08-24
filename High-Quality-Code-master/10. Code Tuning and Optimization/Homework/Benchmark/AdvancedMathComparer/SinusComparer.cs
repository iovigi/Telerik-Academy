namespace AdvancedMathComparer
{
    using System;
    using System.Diagnostics;

    public static class SinusComparer
    {
        public static void Compare(int countOfTest)
        {
            Stopwatch stopwatch = new Stopwatch();

            float numberSingle = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                float result = (float)Math.Sin(numberSingle);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for float of sinus:{0}", stopwatch.ElapsedMilliseconds);

            double numberDouble = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                double result = Math.Sin(numberDouble);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for double of sinus:{0}", stopwatch.ElapsedMilliseconds);

            decimal numberDecimal = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                decimal result = (decimal)Math.Sin((double)numberDecimal);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for decimal of sinus:{0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
