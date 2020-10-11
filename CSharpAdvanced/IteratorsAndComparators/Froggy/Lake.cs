using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake: IEnumerable<int>
    {
        private List<int> lake;

        public Lake(params int[] elements)
        {
            this.lake =new List<int>(elements);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < lake.Count; i+=2)
            {
                yield return lake[i];
            }
            for (int i = lake.Count -1; i >= 0; i--)
            {
                if(i % 2 != 0)
                {
                    yield return lake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
