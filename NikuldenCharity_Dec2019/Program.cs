using System;
using System.Linq;
using System.Security.Cryptography;

namespace NikuldenCharity_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] cmd = command.Split(' ').ToArray();
                if (cmd[0] == "Replace")
                {
                    input = input.Replace(cmd[1], cmd[2]);
                    Console.WriteLine(input);
                }
                else if (cmd[0] == "Cut")
                {
                    int startIndex = int.Parse(cmd[1]);
                    int endIndex = int.Parse(cmd[2]);
                    if (startIndex >= 0 && endIndex < input.Length && startIndex <= endIndex)
                    {
                        input = input.Remove(startIndex, (endIndex - startIndex + 1));
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (cmd[0] == "Make")
                {
                    if (cmd[1] == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    else
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }
                else if (cmd[0] == "Check")
                {
                    string substring = cmd[1];
                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }
                }
                else if (cmd[0] == "Sum")
                {
                    int startIndex = int.Parse(cmd[1]);
                    int endIndex = int.Parse(cmd[2]);
                    int sum = 0;
                    if (startIndex >= 0 && endIndex < input.Length && startIndex <= endIndex)
                    {
                        string substring = input.Substring(startIndex, endIndex - startIndex + 1);
                        foreach (var letter in substring)
                        {
                            sum += (int)letter;
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}
