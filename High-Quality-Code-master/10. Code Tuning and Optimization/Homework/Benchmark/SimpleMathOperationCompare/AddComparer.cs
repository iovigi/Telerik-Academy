namespace SimpleMathOperationComparer
{
    using System;
    using System.Diagnostics;

    public  static class AddComparer
    {
        public static void Compare(int countOfTest)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();

            int sumNumberInt = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                int sum = sumNumberInt + sumNumberInt;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for int of adding:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();

            long sumNumberLong = 1L;

            for (int i = 0; i < countOfTest; i++)
            {
                long sum = sumNumberLong + sumNumberLong;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for long of adding:{0}", stopwatch.ElapsedMilliseconds);

            float sumNumberSingle = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                float sum = sumNumberSingle + sumNumberSingle;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for float of adding:{0}", stopwatch.ElapsedMilliseconds);

            double sumNumberDouble = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                double sum = sumNumberDouble + sumNumberDouble;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for double of adding:{0}", stopwatch.ElapsedMilliseconds);

            decimal sumNumberDecimal = 1;

            for (int i = 0; i < countOfTest; i++)
            {
                decimal sum = sumNumberDecimal + sumNumberDecimal;
            }

            stopwatch.Stop();

            Console.WriteLine("Result for decimal of adding:{0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
