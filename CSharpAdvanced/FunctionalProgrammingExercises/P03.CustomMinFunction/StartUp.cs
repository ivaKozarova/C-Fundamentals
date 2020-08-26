using System;
using System.Linq;

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
        }
    }
}
