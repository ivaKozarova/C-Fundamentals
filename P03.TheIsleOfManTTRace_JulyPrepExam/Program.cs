using System;
using System.Text;
using System.Text.RegularExpressions;

namespace P03.TheIsleOfManTTRace_JulyPrepExam
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string pattern = @"^([#\$%\*&])(?<racer>[A-Za-z]+)\1\=(?<length>\d+)!!(?<code>.+)$";
                        

            while (true)
            { 
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if(match.Success)
                {
                    string name = match.Groups["racer"].Value;
                    int length = int.Parse(match.Groups["length"].Value);
                    string code = match.Groups["code"].Value;
                    if(length == code.Length)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var letter in code)
                        {
                            sb.Append((char)(letter + length));
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {sb}");
                        break;
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
