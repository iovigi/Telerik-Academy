namespace QueueLibrary
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T>
    {
        public readonly IComparer<T> Comparer;

        private List<T> buffer;

        public PriorityQueue()
            : this(Comparer<T>.Default)
        {
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            this.Comparer = comparer;
            this.buffer = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.buffer.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.buffer.Count == 0;
            }
        }

        public T Peek
        {
            get
            {
                return this.buffer[0];
            }
        }

        public void Enqueue(T item)
        {
            this.buffer.Add(item);
            this.PercolatUp(buffer.Count - 1);
        }

        public T Dequeue()
        {
            T itemToReturn = this.buffer[0];
            var bufferCount = this.buffer.Count;
            this.Swap(0, bufferCount - 1);
            this.buffer.RemoveAt(bufferCount - 1);

            if (bufferCount > 1)
            {
                this.PercolatDown(0);
            }

            return itemToReturn;
        }

        private void PercolatUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            var parentIndex = (index % 2 == 0 ? index - 2 : index - 1) / 2;

            if (this.Comparer.Compare(this.buffer[index], this.buffer[parentIndex]) < 0)
            {
                this.Swap(index, parentIndex);
                this.PercolatUp(parentIndex);
            }
        }

        private void PercolatDown(int index)
        {
            int firstChildIndex = index * 2 + 1;
            int secondChildIndex = index * 2 + 2;

            int minIndex = this.FindMin(firstChildIndex, secondChildIndex);
            minIndex = this.FindMin(index, minIndex);

            if (minIndex != index)
            {
                this.Swap(index, minIndex);
                this.PercolatDown(minIndex);
            }
        }

        private int FindMin(int indexFirstItem, int indexSecondItem)
        {
            if (this.buffer.Count <= indexSecondItem)
            {
                return indexFirstItem;
            }

            if (this.Comparer.Compare(this.buffer[indexFirstItem], this.buffer[indexSecondItem]) <= 0)
            {
                return indexFirstItem;
            }

            return indexSecondItem;
        }

        private void Swap(int indexFirstItem, int indexSecondItem)
        {
            T temp = buffer[indexFirstItem];
            this.buffer[indexFirstItem] = this.buffer[indexSecondItem];
            this.buffer[indexSecondItem] = temp;
        }
    }
}
