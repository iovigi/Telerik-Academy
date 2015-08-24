namespace SortComparer
{
    using System;
    using System.Collections.Generic;

    public static class InsertionSort<T>
    {
        public static void Sort(T[] array, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            if (array.Length <= 1)
            {
                return;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j >= 1; j--)
                {
                    if (comparer.Compare(array[i], array[j]) <= 0)
                    {
                        break;
                    }

                    array.Swap(i, j);
                }
            }
        }
    }
}
