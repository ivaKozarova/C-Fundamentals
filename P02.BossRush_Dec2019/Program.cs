using System;
using System.Text.RegularExpressions;

namespace P02.BossRush_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#$";
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                Match match = Regex.Match(text, pattern);
                if(match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string title = match.Groups["title"].Value;

                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }


            }
        }
    }
}
