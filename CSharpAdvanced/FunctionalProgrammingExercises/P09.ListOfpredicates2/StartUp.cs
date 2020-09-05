using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.ListOfpredicates2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Distinct()
                .Select(int.Parse)
                .ToList();
            

            List<int> numbers = FindNumbers(n, dividers);
            if(numbers.Count > 0)
            {
                Console.WriteLine(string.Join(' ',numbers));
            }
        }

        private static List<int> FindNumbers(int n , List<int> dividers)
        {
            var numbers = new List<int>();
            for (int i = 1; i < n; i++)
               
            {
                var isDivisiable = true;

                for (int j = 0; j < dividers.Count; j++)
                {
                    Predicate<int> predicate = n => i % n != 0;
                    if(predicate(dividers[j]))
                    {
                        isDivisiable = false;
                        break;
                    }
                }
                if(isDivisiable)
                {
                    numbers.Add(i); 
                }
              
            }
            return numbers;
        }
    }
}
