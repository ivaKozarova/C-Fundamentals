using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>
            {
                10, 20, 30, 40, 50
             };

            Func<int, bool> myFunc = n => n >10;
            Action<int> myAction = Console.WriteLine;

            list
                 .Where(myFunc)
                 .ToList()
                 .ForEach(myAction);

            Console.WriteLine(new string('*',20));

            Func<int, int> multiplayer = n => n * 2;

            list.Select(multiplayer)
                .ToList()
                .ForEach(myAction);




        }
    }
}
