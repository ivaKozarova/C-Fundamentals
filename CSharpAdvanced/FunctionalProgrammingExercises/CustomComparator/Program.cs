using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> comparator = ((n1, n2) =>
           {
               if (n1 % 2 == 0 && n2 % 2 != 0)
               {
                   return -1;
               }
               else if (n1 % 2 != 0 && n2 % 2 == 0)
               {
                   return 1;
               }
               else
               {
                   return n1.CompareTo(n2);
               }
           });

            Comparison<int> compare = new Comparison<int>(comparator);

            Array.Sort(numbers, compare);

            Console.WriteLine(string.Join(' ', numbers));

           // Sorting(numbers);

        }

        static void Sorting(int[] numbers)
        {
            Array.Sort(numbers, (x, y) => y.CompareTo(x));
             

            Console.WriteLine(string.Join(' ',numbers));
               

        }
    }
}
