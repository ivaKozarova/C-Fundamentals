using System;
using System.Linq;

namespace P01.Username_Aug2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Sign up")
            {
                string[] cmdArg = input.Split();
                string command = cmdArg[0];

                if (command == "Case")
                {
                    userName = ChangeCase(userName, cmdArg);
                }
                else if (command == "Reverse")
                {
                    ReverseSubString(userName, cmdArg);

                }
                else if (command == "Cut")
                {
                    userName = CutSubString(userName, cmdArg);
                }
                else if(command == "Replace")
                {
                    userName = ReplaceChar(userName, cmdArg);
                }
                else if(command == "Check")
                {
                    CheckForSpecialChar(userName, cmdArg);
                }
            }

        }

        private static void CheckForSpecialChar(string userName, string[] cmdArg)
        {
            char validator = char.Parse(cmdArg[1]);
            if (userName.Contains(validator))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine($"Your username must contain {validator}.");
            }
        }

        private static string ReplaceChar(string userName, string[] cmdArg)
        {
            char replacer = char.Parse(cmdArg[1]);
            userName = userName.Replace(replacer, '*');
            Console.WriteLine(userName);
            return userName;
        }

        private static string CutSubString(string userName, string[] cmdArg)
        {
            string substring = cmdArg[1];
            if (userName.Contains(substring))
            {
                int startIndex = userName.IndexOf(substring);

                userName = userName.Remove(startIndex, substring.Length);
                Console.WriteLine(userName);
            }
            else
            {
                Console.WriteLine($"The word {userName} doesn't contain {substring}.");
            }

            return userName;
        }

        private static void ReverseSubString(string userName, string[] cmdArg)
        {
            int startIndex = int.Parse(cmdArg[1]);
            int endIndex = int.Parse(cmdArg[2]);
            if (startIndex >= 0 && endIndex < userName.Length && startIndex < endIndex)
            {
                string substring = userName.Substring(startIndex, endIndex - startIndex + 1);
                substring = new string(substring.Reverse().ToArray());
                Console.WriteLine(substring);
            }
        }

        private static string ChangeCase(string userName, string[] cmdArg)
        {
            if (cmdArg[1] == "lower")
            {
                userName = userName.ToLower();
            }
            else if (cmdArg[1] == "upper")
            {
                userName = userName.ToUpper();
            }
            Console.WriteLine(userName);
            return userName;
        }
    }
}
