using System;
using System.Globalization;
using System.Linq;

namespace WarriorQuest_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd;

            while ((cmd = Console.ReadLine()) != "For Azeroth")
            {
                string[] cmdArg = cmd.Split();
                string command = cmdArg[0];
                if (command == "GladiatorStance" && cmdArg.Length == 1)
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (command == "DefensiveStance" && cmdArg.Length == 1)
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (command == "Dispel" && cmdArg.Length == 3)
                {
                    int index = int.Parse(cmdArg[1]);
                    char letter = char.Parse(cmdArg[2]);
                    if (index >= 0 && index < input.Length)
                    {
                        var inputArr = input.ToArray();
                        inputArr[index] = letter;
                        input = new string(inputArr);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (cmdArg[1] == "Change" && cmdArg.Length == 4)
                {
                    string firstSubstring = cmdArg[2];
                    string secondSubstring = cmdArg[3];
                    input = input.Replace(firstSubstring, secondSubstring);

                    Console.WriteLine(input);
                }
                else if (cmdArg[1] == "Remove" && cmdArg.Length == 3)
                {
                    string stringToRemove = cmdArg[2];
                    while (input.Contains(stringToRemove))
                    {
                        int startIndex = input.IndexOf(stringToRemove);
                        input = input.Remove(startIndex, stringToRemove.Length);
                    }
                    Console.WriteLine(input);
                }

                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }

        }

    }
}

