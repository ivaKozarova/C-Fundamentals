using System;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Deciphering_April2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string pattern = @"^([d-z#,\|]+)$";
            string[] input = Console.ReadLine().Split();

            Match match = Regex.Match(code, pattern);
            if (match.Success)
            {
                string text = match.Groups[1].Value;
                StringBuilder sb = new StringBuilder();
                foreach (var letter in text)
                {
                    sb.Append((char)(letter - 3));
                }

                sb.Replace(input[0], input[1]);
                Console.WriteLine(sb);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }

        }
    }
}
