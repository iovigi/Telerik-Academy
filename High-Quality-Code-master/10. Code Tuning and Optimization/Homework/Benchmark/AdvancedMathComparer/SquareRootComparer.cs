namespace AdvancedMathComparer
{
    using System;
    using System.Diagnostics;

    public static class SquareRootComparer
    {
        public static void Compare(int countOfTest)
        {
            Stopwatch stopwatch = new Stopwatch();

            float numberSingle = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                float result = (float)Math.Sqrt(numberSingle);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for float of square root:{0}", stopwatch.ElapsedMilliseconds);

            double numberDouble = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                double result = Math.Sqrt(numberDouble);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for double of square root:{0}", stopwatch.ElapsedMilliseconds);

            decimal numberDecimal = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                decimal result = (decimal)Math.Sqrt((double)numberDecimal);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for decimal of square root:{0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
