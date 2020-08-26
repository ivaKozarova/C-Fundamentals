using System;
using System.Linq;

namespace P01.ActionPrint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(new Action<string>(n => Console.WriteLine(n)));

        }
    }
}
