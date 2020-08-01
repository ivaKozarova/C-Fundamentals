using System;
using System.Text.RegularExpressions;

namespace postOfffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');
            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];
            string firstPattern = @"([#$%&*])(?<capitals>[A-Z]+)\1";
            Match firstMatch = Regex.Match(firstPart, firstPattern);
            string capitals = firstMatch.Groups["capitals"].Value;
            foreach (var letter in capitals)
            {
                int asciiCode = letter;
                string secondPattern = $@"{asciiCode}:(?<length>[0-9][0-9])";
                Match secondMatch = Regex.Match(secondPart, secondPattern);
                
                int length = int.Parse(secondMatch.Groups["length"].Value);
                string thirdPattern = $@"(?<=\s|^){letter}[^\s]{{{length}}}(?=\s|$)";
                Match thirdMatch = Regex.Match(thirdPart, thirdPattern);
                string word = thirdPattern.ToString();
                Console.WriteLine(word);

            }
            


        }
    }
}
