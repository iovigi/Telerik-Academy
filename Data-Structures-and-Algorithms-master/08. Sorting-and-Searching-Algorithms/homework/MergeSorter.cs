namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, int startIndex, int endIndex)
        {
            if ((startIndex - endIndex) == 0)
            {
                return;
            }

            int middleIndex = (endIndex + startIndex) / 2;

            this.MergeSort(collection, startIndex, middleIndex);
            this.MergeSort(collection, middleIndex + 1, endIndex);

            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            T[] carryBuffer = new T[(endIndex - startIndex) + 1];
            int carryBufferIndex = 0;

            while (leftIndex <= middleIndex && rightIndex <= endIndex)
            {
                if (collection[leftIndex].CompareTo(collection[rightIndex]) < 0)
                {
                    carryBuffer[carryBufferIndex++] = collection[leftIndex++];
                }
                else
                {
                    carryBuffer[carryBufferIndex++] = collection[rightIndex++];
                }
            }

            while (leftIndex <= middleIndex)
            {
                carryBuffer[carryBufferIndex++] = collection[leftIndex++];
            }

            while (rightIndex <= endIndex)
            {
                carryBuffer[carryBufferIndex++] = collection[rightIndex++];
            }

            carryBufferIndex = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                collection[i] = carryBuffer[carryBufferIndex++];
            }
        }
    }
}
