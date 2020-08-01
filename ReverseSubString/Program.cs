using System;
using System.Linq;

namespace ReverseSubString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string valueSubstring = Console.ReadLine();
            if (input.Contains(valueSubstring))
            {
                input = input.Remove(input.IndexOf(valueSubstring), valueSubstring.Length);

               
                var valueSubstring2 = new String(valueSubstring.Reverse().ToArray());

                input += valueSubstring2;
                Console.WriteLine(input);
            }
        }
    }
}
