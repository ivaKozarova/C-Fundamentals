using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyStack
{
    class MyStack
    {
        private int[] stack;
        private int capacity;

        public MyStack(IEnumerable<int> collection)
            :this(collection.Count())
            
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }


        public MyStack(int capacity)
        {

            this.capacity = capacity;
            this.stack = new int[capacity];
        }
        public MyStack()
            : this(4)
        {
        }

        public int Count
        {
            get;
            private set;
        }

        public void Push(int number)
        {
            if (this.Count == this.stack.Length)
            {
                ResizeStack();
            }
            this.stack[Count] = number;
            this.Count++;
        }

        public void Clear()
        {
            this.Count = 0;
            this.stack = new int[capacity];
        }

        private void ResizeStack()
        {
            var newStack = new int[this.stack.Length * 2];
            for (int i = 0; i < stack.Length; i++)
            {
                newStack[i] = stack[i];
            }

            this.stack = newStack;
        }

        public int Pop()
        {
            this.ValidateEmptyStack();
            var result = this.stack[this.Count - 1];
            
            this.Count--;
            return result;
        }

        private void ValidateEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
        }

        public int Peek()
        {
            this.ValidateEmptyStack();
            return this.stack[this.Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.Count -1; i >= 0; i--)
            {
                action(this.stack[i]);

            }
        }

        public IEnumerable<int> Where(Func<int,bool> where)
        {
            var filteredList = new List<int>();

            for (int i = this.Count -1 ; i >=0; i--)
            {
                if(where(this.stack[i]))
                {
                    filteredList.Add(this.stack[i]);
                }
                
            }
            return filteredList;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(this.stack[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
