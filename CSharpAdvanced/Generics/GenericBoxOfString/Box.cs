
namespace GenericBoxOfString
{
    class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            
            return $"{this.item.GetType()}: {this.item.ToString()}";
        }

    }
}
