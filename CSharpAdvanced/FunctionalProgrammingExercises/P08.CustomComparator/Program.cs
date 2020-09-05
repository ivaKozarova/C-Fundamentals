using System;
using System.Linq;

namespace P08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> comprator = new Func<int, int, int>((n1, n2) =>
            {
                if(n1 % 2 ==0 && n2 % 2 != 0)
                { 
                    return -1;
                }
                else if(n1 % 2 != 0 && n2 % 2 ==0 )
                {
                    return 1;
                }
                else
                {
                    return n1.CompareTo(n2);
                }

            });

            Comparison<int> comparison = new Comparison<int>(comprator);

            Array.Sort(numbers, comparison);

            Console.WriteLine(string.Join(' ',numbers));

        }
    }
}
