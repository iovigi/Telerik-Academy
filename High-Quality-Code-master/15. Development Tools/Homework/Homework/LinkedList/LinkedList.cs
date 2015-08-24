namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Example of implementation of IList with LinkedList solution
    /// </summary>
    /// <typeparam name="T">type of list</typeparam>
    public class LinkedList<T> : IList<T>
    {
        private Node<T> first;

        /// <summary>
        /// Gets count of the list.
        /// </summary>
        public int Count
        {
            get
            {
                var currentNode = this.first;
                int count = 0;

                while (currentNode != null)
                {
                    currentNode = currentNode.Next;
                    count++;
                }

                return count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether list isn't read only
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Get or set item of present index. If this index is out of range throw exception.
        /// </summary>
        /// <param name="index">Index of item</param>
        /// <returns>return item</returns>
        public T this[int index]
        {
            get
            {
                var node = this.GetNode(index);

                return node.Item;
            }

            set
            {
                var node = this.GetNode(index);

                node.Item = value;
            }
        }

        /// <summary>
        /// Add item from back of list
        /// </summary>
        /// <param name="item">This item will be add</param>
        public void Add(T item)
        {
            if (this.first == null)
            {
                this.first = new Node<T>(item);

                return;
            }

            var currentNode = this.first;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new Node<T>(item);
        }

        /// <summary>
        /// Remove all items from list
        /// </summary>
        public void Clear()
        {
            this.first = null;
        }

        /// <summary>
        /// Check list for item
        /// </summary>
        /// <param name="item">parameter item</param>
        /// <returns>return true if contains item, otherwise false.</returns>
        public bool Contains(T item)
        {
            var currentNode = this.first;

            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Copy items from list to given array from start index arrayIndex
        /// </summary>
        /// <param name="array">Array, where will be copy list</param>
        /// <param name="arrayIndex">start index of array.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex is invalid");
            }

            var count = this.Count;

            if (array.Length - arrayIndex < count)
            {
                throw new ArgumentException("array length is lower than Count of list");
            }

            var currentNode = this.first;

            for (int i = 0; i < count; i++)
            {
                array[i + arrayIndex] = currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Get Enumerator of list.
        /// </summary>
        /// <returns>yield return items</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.first;

            while (currentNode != null)
            {
                yield return currentNode.Item;

                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Get index of the item.
        /// </summary>
        /// <param name="item">parameter item</param>
        /// <returns>return index of item if contains in list, otherwise return -1.</returns>
        public int IndexOf(T item)
        {
            var index = 0;
            var currentNode = this.first;

            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    return index;
                }

                index++;
                currentNode = currentNode.Next;
            }

            return -1;
        }

        /// <summary>
        /// Insert item to index.
        /// </summary>
        /// <param name="index">index of item </param>
        /// <param name="item">parameter item</param>
        public void Insert(int index, T item)
        {
            var node = this.GetNode(index);

            node.Next = node;
            node.Item = item;
        }

        /// <summary>
        /// Remove item from list.
        /// </summary>
        /// <param name="item">parameter item</param>
        /// <returns>return true if item is remove from list, otherwise false.</returns>
        public bool Remove(T item)
        {
            var currentNode = this.first;

            if (currentNode == null)
            {
                return false;
            }

            if (currentNode.Item.Equals(item))
            {
                this.first = currentNode.Next;

                return true;
            }

            while (currentNode.Next != null)
            {
                if (currentNode.Next.Item.Equals(item))
                {
                    currentNode.Next = currentNode.Next.Next;

                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Remove item from list of present index.
        /// </summary>
        /// <param name="index">index of item</param>
        public void RemoveAt(int index)
        {
            var node = this.GetNode(index - 1);

            if (node.Next == null)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            node.Next = node.Next.Next;
        }

        /// <summary>
        /// Enumerator of items of list
        /// </summary>
        /// <returns>return enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// return node from index.
        /// </summary>
        /// <param name="index">index of node</param>
        /// <returns>return node</returns>
        private Node<T> GetNode(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index is invalid");
            }

            var currentNode = this.first;

            for (int i = 0; i < index; i++)
            {
                if (currentNode == null)
                {
                    break;
                }

                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException("index is out of range");
            }

            return currentNode;
        }
    }
}
