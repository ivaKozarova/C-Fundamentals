using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var numbersCount = new Dictionary<int, int>();

            AddNumberAndCountIt(n, numbersCount);

            PrintNumbers(numbersCount);

        }

        private static void PrintNumbers(Dictionary<int, int> numbersCount)
        {
            foreach (var (number, count) in numbersCount)
            {
                if (count % 2 == 0)
                {
                    Console.WriteLine(number);
                }
            }
        }

        private static void AddNumberAndCountIt(int n, Dictionary<int, int> numbersCount)
        {
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount[number] = 0;
                }
                numbersCount[number]++;
            }
        }
    }
}
