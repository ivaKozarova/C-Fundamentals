using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var elelents = new int[] { 0, 3, 6, 8, 2 };

            foreach (var el in elelents)
            {
                var isExist = array.Contains(el);

            }
        }
    }
}
