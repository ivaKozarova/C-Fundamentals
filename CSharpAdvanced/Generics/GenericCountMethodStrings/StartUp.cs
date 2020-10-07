using System;

namespace GenericCountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                box.Elements.Add(double.Parse(Console.ReadLine()));

            }
            var comparator = Console.ReadLine();

            int result = box.GreaterValueThan(double.Parse(comparator));
            Console.WriteLine(result);
        }
    }
}
