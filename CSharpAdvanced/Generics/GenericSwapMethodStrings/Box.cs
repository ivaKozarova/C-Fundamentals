using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
       public Box()
        {
            this.MyList = new List<T>();
        }
        public List<T> MyList { get; set; }

        public void Add(T item)
        {
            this.MyList.Add(item);
        }
        public void Swap(int index1, int index2)
        {
            ValidateIndexes(index1, index2);

            T temp = this.MyList[index1];
            this.MyList[index1] = this.MyList[index2];
            this.MyList[index2] = temp;
        }

        private void ValidateIndexes(int index1 , int index2)
        {
            if(index1 >=0 && index1 < this.MyList.Count
                && index2 >= 0 && index2 < this.MyList.Count)
            {
                return;
            }
            else
            {
                throw new InvalidOperationException("Invalid index!");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.MyList)
            {
                sb.AppendLine($"{item.GetType()}: {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
