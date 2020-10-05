using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            var divisable = IsDivisable(n, dividers);
            Console.WriteLine(String.Join(' ' ,divisable));


        }

        static List<int> IsDivisable(int n, int[] dividers)
        {
            var divisable = new List<int>();
           
            
            for (int i = 1; i <= n; i++)
            {
                var isDivisable = true;
                for (int j = 0; j < dividers.Length; j++)
                {
                    Predicate<int> predicate = x => i % x == 0;

                    
                   if(!predicate(dividers[j]))
                    {
                        isDivisable = false;
                        break;
                    }
                   
                }
                if (isDivisable)
                {
                    divisable.Add(i);
                }

            }
            return divisable;
        }
    }
}
