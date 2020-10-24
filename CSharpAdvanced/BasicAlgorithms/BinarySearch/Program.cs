using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var number = int.Parse(Console.ReadLine());

         //  var index = BinarySearch(sortedArr, number);
           var index2 = RecursiveBinarySearch(sortedArr, 0, sortedArr.Length - 1, number);
            
                Console.WriteLine(index2);
            

        }
        static int RecursiveBinarySearch(int[] array , int min , int max , int number)
        {
            if(min <= max)
            {
                int middle = (min + max) / 2;
                if(number == array[middle])
                {
                    return middle;
                }
                else
                {
                    if(number < array[middle])
                    {
                        max = middle - 1;
                        return RecursiveBinarySearch(array, min, max, number);
                    }
                    min = middle + 1;
                    return RecursiveBinarySearch(array, min, max, number);
                }
            }
            return -1;
        }
        static int BinarySearch(int[] sortedArr, int number)
        {
            int min = 0;
            int max = sortedArr.Length - 1;
            
            while (min <= max)
            {
                int middle = (min + max) / 2;
                if (number == sortedArr[middle])
                {
                    return middle;
                }
                else if (number > sortedArr[middle])
                {
                    min = middle + 1;
                }
                else
                {
                    max = middle - 1;
                }
            }
            return -1;
        }
    }
}
