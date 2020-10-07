using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.Elements = new List<T>();
        }
        public List<T> Elements { get; set; }

        public void Add(T value)
        {
            this.Elements.Add(value);
        }

        public int GreaterValueThan(T comparator)
           
        {
            int result = 0;
            foreach (var item in this.Elements)
            {
                int n = item.CompareTo(comparator);
                if(n > 0)
                {
                    result++;
                }
                

            }
            return result;
        }

    }
}
