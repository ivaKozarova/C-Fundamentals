using System;
using System.Collections.Generic;

namespace P03.PeriodicTable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var chemicalEl = new SortedSet<string>();
            AddChemicalElements(n, chemicalEl);

            Console.WriteLine(string.Join(" ", chemicalEl));

        }

        private static void AddChemicalElements(int n, SortedSet<string> chemicalEl)
        {
            for (int i = 0; i < n; i++)
            {
                var inputEl = Console.ReadLine().Split();
                foreach (var el in inputEl)
                {
                    chemicalEl.Add(el);
                }
            }
        }
    }
}
