using System;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.Password_Aug2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"^(.+?)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$";
            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();

                Match match = Regex.Match(password, pattern);
                if (match.Success)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(match.Groups[2]);
                    sb.Append(match.Groups[3]);
                    sb.Append(match.Groups[4]);
                    sb.Append(match.Groups[5]);
                    string valid = sb.ToString();
                    Console.WriteLine($"Password: {valid}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
