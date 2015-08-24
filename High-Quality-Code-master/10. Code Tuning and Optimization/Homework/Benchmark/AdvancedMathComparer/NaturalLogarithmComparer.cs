namespace AdvancedMathComparer
{
    using System;
    using System.Diagnostics;

    public  static class NaturalLogarithmComparer
    {
        public static void Compare(int countOfTest)
        {
            Stopwatch stopwatch = new Stopwatch();

            float numberSingle = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                float result = (float)Math.Log(numberSingle);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for float of natural logarithm:{0}", stopwatch.ElapsedMilliseconds);

            double numberDouble = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                double result = Math.Log(numberDouble);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for double of natural logarithm:{0}", stopwatch.ElapsedMilliseconds);

            decimal numberDecimal = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                decimal result = (decimal)Math.Log((double)numberDecimal);
            }

            stopwatch.Stop();

            Console.WriteLine("Result for decimal of natural logarithm:{0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
