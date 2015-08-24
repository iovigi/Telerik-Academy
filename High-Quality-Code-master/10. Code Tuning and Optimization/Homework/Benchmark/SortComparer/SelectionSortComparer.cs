namespace SortComparer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class SelectionSortComparer
    {
        public static void RandomCompare(int countOfElementInArray)
        {
            int[] intArray = new int[countOfElementInArray];
            double[] doubleArray = new double[countOfElementInArray];
            string[] stringArray = new string[countOfElementInArray];

            Random rand = new Random();

            for (int i = 0; i < countOfElementInArray; i++)
            {
                int randNumber = rand.Next();

                intArray[i] = randNumber;
                doubleArray[i] = randNumber;
                stringArray[i] = randNumber.ToString();
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();
            SelectionSort<int>.Sort(intArray, Comparer<int>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for random int is:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            SelectionSort<double>.Sort(doubleArray, Comparer<double>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for random double is:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            SelectionSort<string>.Sort(stringArray, Comparer<string>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for random string is:{0}", stopwatch.ElapsedMilliseconds);
        }

        public static void SequentialCompare(int countOfElementInArray)
        {
            int[] intArray = new int[countOfElementInArray];
            double[] doubleArray = new double[countOfElementInArray];
            string[] stringArray = new string[countOfElementInArray];

            for (int i = 0; i < countOfElementInArray; i++)
            {
                intArray[i] = i;
                doubleArray[i] = i;
                stringArray[i] = i.ToString();
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();
            SelectionSort<int>.Sort(intArray, Comparer<int>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for sequential int is:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            SelectionSort<double>.Sort(doubleArray, Comparer<double>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for sequential double is:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            SelectionSort<string>.Sort(stringArray, Comparer<string>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for sequential string is:{0}", stopwatch.ElapsedMilliseconds);
        }

        public static void BackSequentialCompare(int countOfElementInArray)
        {
            int[] intArray = new int[countOfElementInArray];
            double[] doubleArray = new double[countOfElementInArray];
            string[] stringArray = new string[countOfElementInArray];

            for (int i = countOfElementInArray - 1; i >= 0; i--)
            {
                intArray[i] = i;
                doubleArray[i] = i;
                stringArray[i] = i.ToString();
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();
            SelectionSort<int>.Sort(intArray, Comparer<int>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for back sequential int is:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            SelectionSort<double>.Sort(doubleArray, Comparer<double>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for back sequential double is:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            SelectionSort<string>.Sort(stringArray, Comparer<string>.Default);
            stopwatch.Stop();

            Console.WriteLine("Selection sort result for back sequential string is:{0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
