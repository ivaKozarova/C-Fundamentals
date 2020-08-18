using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstLength = length[0];
            int secondLength = length[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            AddToSet(firstLength, firstSet);
            AddToSet(secondLength, secondSet);

            PrintIntersectList(firstSet, secondSet);

        }

        private static void PrintIntersectList(HashSet<int> firstSet, HashSet<int> secondSet)
        {
            //foreach (var number in firstSet)
            //{
            //    if (secondSet.Contains(number))
            //    {
            //        Console.Write(number + " ");
            //    }
            //}
            //Console.WriteLine();
            var commonList = firstSet.Intersect(secondSet);
            Console.WriteLine(string.Join(" ",commonList));
        }

        private static void AddToSet(int length, HashSet<int> set)
        {
            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                set.Add(number);
            }
        }
    }
}
