using System;
using System.Linq;
namespace P02.KnightsOfHonor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(new Action<string>(n => Console.WriteLine("Sir " + n)));
        }
    }
}
