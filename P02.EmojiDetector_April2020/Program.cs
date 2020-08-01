using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.EmojiDetector_April2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long cool = 1;
            foreach (var symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    cool *= long.Parse(symbol.ToString());
                }
            }
            string pattern = @"([:]{2}|[**]{2})(?<name>[A-Z][a-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> coolEmoji = new List<string>();
             foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                int asciiSum = 0;
                foreach (var letter in name)
                {
                    asciiSum += letter;
                }
                if(asciiSum >= cool)
                {
                    string surroundEl = match.Groups[1].Value;
                    string fullName = surroundEl + name + surroundEl;
                    coolEmoji.Add(fullName);
                }
            }
            Console.WriteLine($"Cool threshold: {cool}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (var emoji in coolEmoji)
            {
                Console.WriteLine(emoji);
            }


        }
    }
}
