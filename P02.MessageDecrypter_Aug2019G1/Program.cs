using System;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.MessageDecrypter_Aug2019G1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^(\$|%)([A-Z][a-z]{2,})\1: \[([0-9]+)\]\|\[([0-9]+)\]\|\[([0-9]+)\]\|$";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                if(match.Success)
                {
                    StringBuilder sb = new StringBuilder();
                    string tag = match.Groups[2].Value;
                    sb.Append(tag + ": ");
                    for (int j = 3; j <= 5; j++)
                    {
                        int groups = int.Parse(match.Groups[j].Value);
                        char letter = (char)groups;
                        sb.Append(letter);

                    }
                    Console.WriteLine(sb);
                    

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }


            }
        }
    }
}
