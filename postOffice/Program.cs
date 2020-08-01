using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace postOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|').ToArray();
            string partOne = input[0];
            Regex findCapitalLetters = new Regex(@"(\$|\#|\%|\*|\&)(?<letters>[A-Z]+)\1");
            var validLetters = findCapitalLetters.Match(partOne);
            if (validLetters.Success)
            {
                string firstLetters = validLetters.Groups["letters"].ToString();
                foreach (var letter in firstLetters)
                {
                    int codeOfLetter = (int)letter;
                    Regex findLength = new Regex(@"(?<asciicode>\d{2,3}):(?<length>\d{2})");
                    MatchCollection matches = findLength.Matches(input[1]);
                    string[] words = input[2].Split();
                    foreach (Match match in matches)
                    {
                        bool isFind = false;
                        int asciiCode = int.Parse(match.Groups["asciicode"].ToString());
                        int length = int.Parse(match.Groups["length"].ToString());
                        if (codeOfLetter == asciiCode)
                        {
                            foreach (var word in words)
                            {
                                if (word[0] == letter && word.Length == length + 1)
                                {
                                    Console.WriteLine(word);
                                    isFind = true;
                                    break;
                                }
                            }
                        }
                        if (isFind == true)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
