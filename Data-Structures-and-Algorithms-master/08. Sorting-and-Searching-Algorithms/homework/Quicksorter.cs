namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> collection, int firstIndex, int lastIndex)
        {
            var pivot = lastIndex;

            var leftIndex = firstIndex;
            var rightIndex = lastIndex - 1;

            while (leftIndex < rightIndex)
            {
                while (collection[leftIndex].CompareTo(collection[pivot]) < 0 && leftIndex < pivot)
                {
                    leftIndex++;
                }

                while (collection[rightIndex].CompareTo(collection[pivot]) > 0 && leftIndex < rightIndex)
                {
                    rightIndex--;
                }

                if (leftIndex >= rightIndex)
                {
                    break;
                }

                this.Swap(collection, leftIndex, rightIndex);
            }

            if (collection[leftIndex].CompareTo(collection[pivot]) > 0)
            {
                this.Swap(collection, leftIndex, pivot);
            }

            if (firstIndex < leftIndex - 1)
            {
                this.Sort(collection, firstIndex, leftIndex - 1);
            }

            if (leftIndex + 1 < lastIndex)
            {
                this.Sort(collection, leftIndex + 1, lastIndex);
            }
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            var temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}
