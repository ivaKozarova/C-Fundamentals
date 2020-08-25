
using System;
using System.Linq;
using System.Collections.Generic;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            if (text.Length > 0)
            {
                Func<string, bool> findUpperCase = x => char.IsUpper(x[0]);
                Action<string> print = Console.WriteLine;

                text.Split(' ',StringSplitOptions.RemoveEmptyEntries)
               .Where(findUpperCase)
               .ToList()
               .ForEach(print);
            }
          
        }
    }
}
