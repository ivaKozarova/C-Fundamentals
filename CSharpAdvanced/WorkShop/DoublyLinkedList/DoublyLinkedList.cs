using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>

    {
        private NodeInfo<T> head;
        private NodeInfo<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if(this.Count == 0)
            {
                this.head = this.tail = new NodeInfo<T>(element);
          
            }
            else
            {
                var newHead = new NodeInfo<T>(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
             this.Count++;

        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new NodeInfo<T>(element);
            }
            else
            {
                var newTail = new NodeInfo<T>(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public string RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }
            var firstElement= $"Removed: {this.head.Value}";
            this.head = this.head.NextNode;
            this.Count--;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }
            
            return firstElement;
        }

        public string RemoveLast()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("The List is empty!");
            }
            var last = $"Removed: {this.tail.Value}";
            this.tail = this.tail.PreviousNode;
            this.Count--;

            if(this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }
            return last;
           
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while(currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }
        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            var counter = 0;

            var currNode = this.head;
            while(currNode != null)
            {
                arr[counter] = currNode.Value;
                counter++;
                currNode = currNode.NextNode;
            }
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currNode = this.head;
            while (currNode != null)
            {
                yield return currNode.Value;
                currNode = currNode.NextNode;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
