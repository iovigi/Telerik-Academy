namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (item.CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int middleIndex = (this.Items.Count- 1) / 2;

            while (true)
            {
                if (this.Items[middleIndex].CompareTo(item) == 0)
                {
                    return true;
                }

                if (middleIndex == 0 || middleIndex == this.Items.Count - 1)
                {
                    return false;
                }

                if (this.Items[middleIndex].CompareTo(item) < 0)
                {
                    middleIndex = (this.Items.Count + middleIndex) / 2;
                }
                else
                {
                    middleIndex = middleIndex / 2;
                }
            }
        }

        public void Shuffle()
        {
            var count = this.Items.Count;
            var random = new Random();


            for (int i = 0; i < count - 1; i++)
            {
                var indexToSwap = random.Next(i + 1, count);

                T temp = this.Items[indexToSwap];
                this.Items[indexToSwap] = this.Items[i];
                this.Items[i] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
