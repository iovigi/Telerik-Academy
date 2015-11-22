namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int count = collection.Count;

            for (int i = 0; i < count; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < count; j++)
                {
                    if (collection[minIndex].CompareTo(collection[j]) > 0)
                    {
                        minIndex = j;
                    } 
                }

                if (minIndex != i)
                {
                    var temp = collection[i];
                    collection[i] = collection[minIndex];
                    collection[minIndex] = temp;
                }
            }
        }
    }
}
