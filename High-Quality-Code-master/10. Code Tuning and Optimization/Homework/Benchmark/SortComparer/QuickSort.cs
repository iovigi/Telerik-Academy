namespace SortComparer
{
    using System;
    using System.Collections.Generic;

    public static class QuickSort<T>
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

            Sort(array, 0, array.Length - 1, comparer);
        }

        private static void Sort(T[] array, int startIndex, int endIndex, IComparer<T> comparer)
        {
            int pivot = (startIndex + endIndex) / 2;

            array.Swap(pivot, endIndex);

            pivot = endIndex;

            int i = startIndex;
            int j = endIndex - 1;

            while (i < j)
            {
                while (i < j)
                {
                    if (comparer.Compare(array[i], array[pivot]) >= 0)
                    {
                        break;
                    }

                    ++i;
                }

                while (i < j)
                {
                    if (comparer.Compare(array[j], array[pivot]) <= 0)
                    {
                        break;
                    }

                    --j;
                }

                array.Swap(i, j);
            }

            if (comparer.Compare(array[i], array[pivot]) > 0)
            {
                array.Swap(i, pivot);
            }

            if (startIndex < j)
            {
                Sort(array, startIndex, j, comparer);
            }

            if ((i + 1) < endIndex)
            {
                Sort(array, i + 1, endIndex, comparer);
            }
        }
    }
}
