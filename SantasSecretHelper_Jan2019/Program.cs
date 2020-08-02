using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace SantasSecretHelper_Jan2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string input;
            string pattern = @"@(?<name>[A-Za-z]+)([^@\-!:>]*)!(?<behavior>[GN])!\2*";

            List<string> listOfGoods = new List<string>();
            while ((input = Console.ReadLine()) != "end")
            {
                string decodedMsg = DecodeInput(key, input);
                MatchAndAdd(pattern, listOfGoods, decodedMsg);

            }
            Console.WriteLine(string.Join(Environment.NewLine , listOfGoods));
        }

        private static void MatchAndAdd(string pattern, List<string> listOfGoods, string decodedMsg)
        {
            Match match = Regex.Match(decodedMsg, pattern);
            if (match.Success)
            {
                string name = match.Groups["name"].Value;
                string behavior = match.Groups["behavior"].Value;
                if (behavior == "G")
                {
                    listOfGoods.Add(name);
                }
            }
        }

        private static string DecodeInput(int key, string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var letter in input)
            {
                sb.Append((char)(letter - key));
            }
            string decodedMsg = sb.ToString();
            return decodedMsg;
        }
    }
}
