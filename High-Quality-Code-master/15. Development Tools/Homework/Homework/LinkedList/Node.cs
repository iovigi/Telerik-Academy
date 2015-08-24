namespace LinkedList
{
    /// <summary>
    /// Internal class node use for logic of list
    /// </summary>
    /// <typeparam name="T">type of node</typeparam>
    internal class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="item">item of node</param>
        public Node(T item)
        {
            this.Item = item;
        }

        /// <summary>
        /// Gets or sets item of node
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        ///  Gets or sets next node
        /// </summary>
        public Node<T> Next { get; set; }
    }
}
