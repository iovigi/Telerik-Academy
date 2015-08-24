namespace _2.ArrayStatisticsPrinter
{
    using System;

    public class ArrayStatisticsPrinter
    {
        public void PrintStatistics(double[] array, int count)
        {
            double max = 0;
            for (int i = 0; i < count; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            this.PrintMax(max);

            double min = 0;
            for (int i = 0; i < count; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            this.PrintMin(max);

            double averange = 0;
            for (int i = 0; i < count; i++)
            {
                averange += array[i];
            }

            this.PrintAvg(averange / count);
        }

        private void PrintMax(double max)
        {
            throw new NotImplementedException();
        }

        private void PrintMin(double max)
        {
            throw new NotImplementedException();
        }

        private void PrintAvg(double p)
        {
            throw new NotImplementedException();
        }
    }
}
