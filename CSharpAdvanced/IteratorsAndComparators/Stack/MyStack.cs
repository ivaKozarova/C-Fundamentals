using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> customStack;
        public MyStack()
        {

            this.customStack = new List<T>();
        }

        public int Count => this.customStack.Count;

        public void Push(params T[] elements)
        {
            if (this.Count == 0)
            {
                this.customStack = elements.ToList();
            }
            else
            {
                this.customStack.InsertRange(this.Count, elements);
            }
        }

        public void Pop()
        {
            if (this.Count > 0)
            {
                this.customStack.RemoveAt(this.Count - 1);
            }
            else
            {
                System.Console.WriteLine("No elements");
            }
        }
        

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.customStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
