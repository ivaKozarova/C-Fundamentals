using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ActionPointWtihStream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Names.txt"))

            {
                string line;
                int count = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Line {count}");
                    Console.WriteLine(new string('-',30));
                    line
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .ForEach(new Action<string>(n => Console.WriteLine(n)));
                    Console.WriteLine();
                    count++;
                }
            }
        }
    }
}
