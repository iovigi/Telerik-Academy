namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            Debug.Assert(array != null, "array is null");

            for (int index = 0; index < array.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(array, index, array.Length - 1);

                Swap(ref array[index], ref array[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] array, T value) where T : IComparable<T>
        {
            return BinarySearch(array, value, 0, array.Length - 1);
        }

        public static void Main()
        {
            int[] array = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", array));
            SelectionSort(array);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", array));

            SelectionSort(new int[0]);
            SelectionSort(new int[1]);

            Console.WriteLine(BinarySearch(array, -1000));
            Console.WriteLine(BinarySearch(array, 0));
            Console.WriteLine(BinarySearch(array, 17));
            Console.WriteLine(BinarySearch(array, 10));
            Console.WriteLine(BinarySearch(array, 1000));
        }

        private static int FindMinElementIndex<T>(T[] array, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(array != null, "array is null");
            Debug.Assert(array.Length >= (endIndex - startIndex), "Index isn't correct for given array length");
            Debug.Assert(startIndex <= endIndex, "start index is bigger than endIndex");

            int minElementIndex = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (array[i].CompareTo(array[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] array, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(array != null, "array is null");
            Debug.Assert(array.Length >= (endIndex - startIndex), "Index isn't correct for given array length");
            Debug.Assert(startIndex <= endIndex, "start index is bigger than endIndex");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (array[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (array[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
