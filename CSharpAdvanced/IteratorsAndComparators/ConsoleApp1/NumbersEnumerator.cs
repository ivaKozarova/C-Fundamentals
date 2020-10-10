
using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    class NumbersEnumerator : IEnumerator<int>
    {
        private int[] array;
        private int index;

        public NumbersEnumerator(int[] array)
        {
            this.array = array;
            Reset();
        }
       
        public int Current
        {
            get { return this.array[this.index]; }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            
            index++;
            return this.index < this.array.Length;
            
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
