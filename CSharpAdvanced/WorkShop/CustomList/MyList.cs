using System;

namespace CustomList
{
    class MyList
    {
        private int[] list;
        private int capacity;

        public MyList()
            : this(4)
        {
        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.list = new int[capacity];
        }

        public int Count
        {
            get;
            private set;
        }

        public void Add(int number)
        {
            if (this.Count == list.Length)
            {
                ResizeList(this.list);
            }
                this.list[this.Count] = number;
                this.Count++;
         }

        private void ResizeList(int[] list)
        {
            var newLength = list.Length * 2;
            var biggerList = new int[newLength];

            for (int i = 0; i < list.Length; i++)
            {
                biggerList[i] = list[i];
            }
           
            this.list = biggerList;
        }

        public void Clear()
        {
            this.Count = 0;
            this.list = new int[capacity];
        }

        public int RemoveAt(int index)
        {            
            if (this.ValidateIndex(index))
            {
                var result = this.list[index];
                for (int i = index + 1; i < this.Count; i++)
                {
                    this.list[i - 1] = this.list[i];
                }
                this.list[this.Count - 1] = 0;
                this.Count--;
                return result;
            }
            else
            {
                throw new Exception($"Index must be from 0 to {this.Count - 1}.");
            }
        }

        public  bool Contains(int number)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(number == list[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex , int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            var firstValue = this.list[firstIndex];
            this.list[firstIndex] = this.list[secondIndex];
           this.list[secondIndex] = firstValue;
        }

        private bool ValidateIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return true;
            }
            else
            {
                throw new Exception("Invalid index!");
            }
        }

        public int this[int index]
        {
            get
            {
                if (ValidateIndex(index))
                {
                    return this.list[index];
                }
                else
                {
                    throw new Exception("Index is not valid!");
                }
            }
            set
            {
                if (ValidateIndex(index))
                {
                    this.list[index] = value;
                    Count++;
                }
            }
        }
    }
}
