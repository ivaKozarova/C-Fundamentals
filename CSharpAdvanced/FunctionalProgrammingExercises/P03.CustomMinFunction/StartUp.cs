using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace P03.CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minValue = arr =>
            {
                int minVal = Int32.MaxValue;
                foreach (var num in arr)
                {
                    if (num < minVal)
                    {
                        minVal = num;
                    }
                }
                return minVal;
            };
            Console.WriteLine(minValue(arr));

            Func<int[], int, int> maxVal = (arr, i) =>
             {
                 int maxVal = Int32.MinValue;
                 foreach (var num in arr)
                 {
                     if (num + i > maxVal)
                     {
                         maxVal = num + i;
                     }
                 }
                 return maxVal;
             };
            Console.WriteLine(maxVal(arr, 5));

            string[] names = new string[] { "Asq", "Poli", "Simona", "Natali", "Krasimira" };

            Func<string, int, bool> IsLettersLessThenFour = (name, n) => name.Length < n;
            foreach (string name in names)
            {
                bool check = IsLettersLessThenFour(name, 5);
                Console.WriteLine(check);
            }
            string nameG = "Gosho";

            Action<string> print = name => Console.WriteLine(name);
            print(nameG);
            void Loop(int n)
            {
                if (n == 10)
                {
                    return;
                } 
                Console.WriteLine(nameG);
                Loop(n + 1);
            }
            Loop(0);

            Func<int, int, int> sum = (a, b) => a + b;

            Console.WriteLine(sum(3, 5));

        }
    }
}
