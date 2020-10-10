using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;
        public ListyIterator(params T[] arr)
        {
            this.Listy = arr.ToList();
        }
        public List<T> Listy { get; set; }

        public void Print()
        {
            if (Listy.Any())
            {
                Console.WriteLine(this.Listy[this.index]);
            }
            else
            {
                throw new InvalidOperationException("The list is empty!");
            }
        }

        public bool Move()
        {
            if(this.index < this.Listy.Count -1)
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return (this.index < this.Listy.Count - 1);
        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(' ', Listy));
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Listy.Count; i++)
            {
                yield return this.Listy[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
