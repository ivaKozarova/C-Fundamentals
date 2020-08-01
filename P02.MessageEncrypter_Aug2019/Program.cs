using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.MessageEncrypter_Aug2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"([*|@])([A-Z][a-z]{2,})\1: \[([A-Za-z]+)\]\|\[([A-Za-z]+)\]\|\[([A-Za-z]+)\]\|$";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                List<int> asciiCodes = new List<int>();
                Match match = Regex.Match(input, pattern);
                if(match.Success)
                {
                    string tag = match.Groups[2].Value;
                    string groupOne = match.Groups[3].Value;
                    string groupTwo = match.Groups[4].Value;
                    string groupThree = match.Groups[5].Value;
                    foreach (var letter in groupOne)
                    {
                        int code = letter;
                        asciiCodes.Add(code);
                    }
                    foreach (var letter in groupTwo)
                    {
                        int code = letter;
                        asciiCodes.Add(code);
                    }
                    foreach (var letter in groupThree)
                    {
                        int code = letter;
                        asciiCodes.Add(code);
                    }
                    Console.WriteLine($"{tag}: {string.Join(' ',asciiCodes)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
