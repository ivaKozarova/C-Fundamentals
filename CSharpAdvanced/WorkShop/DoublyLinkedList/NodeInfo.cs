namespace DoublyLinkedList
{
    public class NodeInfo<T>
    {
        public NodeInfo(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public NodeInfo<T> PreviousNode { get; set; }
        public NodeInfo<T> NextNode { get; set; }

    }
}
