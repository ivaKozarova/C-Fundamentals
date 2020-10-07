using GenericBoxOfString;
using System;
using System.Linq;

namespace GenericSwapMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.MyList.Add(input);
              
            }
            var indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap(indexes[0], indexes[1]);

            Console.WriteLine(box);


        }
    }
}
