using System;

namespace P01.StringManipulator_Aug2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command;
            while((command =Console.ReadLine()) != "Done")
            {
                string[] cmdArg = command.Split();
                string cmd = cmdArg[0];
                if(cmd == "Change")
                {
                    input = ChangeChar(input, cmdArg);
                }
                else if(cmd == "Includes")
                {
                    CheckForSubString(input, cmdArg);
                }
                else if(cmd == "End")
                {
                    CheckStringEnd(input, cmdArg);
                }
                else if(cmd == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if(cmd == "FindIndex")
                {
                    int index = input.IndexOf(char.Parse(cmdArg[1]));
                    Console.WriteLine(index);
                }
                else if(cmd == "Cut")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int length = int.Parse(cmdArg[2]);
                    string result = input.Substring(startIndex, length);
                    Console.WriteLine(result);

                }
            }
        }

        private static void CheckStringEnd(string input, string[] cmdArg)
        {
            string substring = cmdArg[1];
            if (input.EndsWith(substring))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static void CheckForSubString(string input, string[] cmdArg)
        {
            string substring = cmdArg[1];
            if (input.Contains(substring))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static string ChangeChar(string input, string[] cmdArg)
        {
            char oldChar = char.Parse(cmdArg[1]);
            char newChar = char.Parse(cmdArg[2]);
            input = input.Replace(oldChar, newChar);
            Console.WriteLine(input);
            return input;
        }
    }
}
