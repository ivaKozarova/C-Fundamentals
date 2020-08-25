using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, int> parseFunc = n => int.Parse(n);
            Func<int, bool> selectEvenNums = n => n % 2 == 0;


            var list = Console.ReadLine()
                .Split(", ")
                .Select(parseFunc)
                .Where(selectEvenNums)
                .OrderBy(x => x);

            Console.WriteLine(string.Join(", ",list));
                
                
        }
    }
}
