namespace SortComparer
{
    using System;
    using System.Collections.Generic;

    public class SelectionSort<T>
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

            int length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (comparer.Compare(array[i], array[j]) > 0)
                    {
                        array.Swap(i, j);
                    }
                }
            }
        }
    }
}
