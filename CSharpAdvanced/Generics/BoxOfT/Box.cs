
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> list;

        public Box()
        {
            this.list = new Stack<T>();
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void Add(T element)
        {
            this.list.Push(element);
        }

        public T Remove()
        {
            return this.list.Pop();
        }

    }
}