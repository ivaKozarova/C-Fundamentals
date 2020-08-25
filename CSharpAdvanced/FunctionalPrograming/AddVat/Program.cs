using System;
using System.Linq;

namespace AddVat
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<double, double> addVat = n => n *= 1.2;
            Action<double> print = n => Console.WriteLine($"{n:f2}");

            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat)
                .ToList()
                .ForEach(print);
        }
    }
}
