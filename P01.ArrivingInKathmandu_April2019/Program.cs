using System;
using System.Text;
using System.Text.RegularExpressions;

namespace P01.ArrivingInKathmandu_April2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @"^(?<name>[!@#$?A-za-z0-9]+)=(?<length>\d+)<<(?<geohashcode>.+)$";

            while((input = Console.ReadLine())!= "Last note")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    int length = int.Parse(match.Groups["length"].Value);
                    string geohashcode = match.Groups["geohashcode"].Value;

                    if (length == geohashcode.Length)
                    {
                        string nameOfPeak = match.Groups["name"].Value;
                        StringBuilder sb = new StringBuilder();
                        foreach (var letter in nameOfPeak)
                        {
                            if (char.IsLetterOrDigit(letter))
                            {
                                sb.Append(letter);
                            }
                        }
                        Console.WriteLine($"Coordinates found! {sb} -> {geohashcode}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }

                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
