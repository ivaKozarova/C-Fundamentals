using System;
using System.Data;

namespace P01.StringManipulator_Aug2019G1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string commanad;
            while ((commanad = Console.ReadLine()) != "End")
            {
                string[] cmdArg = commanad.Split();

                if (cmdArg[0] == "Translate")
                {
                    input = Translate(input, cmdArg);
                }
                else if (cmdArg[0] == "Includes")
                {
                    bool check = input.Contains(cmdArg[1]);
                    Check(check);

                }
                else if (cmdArg[0] == "Start")
                {
                    bool check = input.StartsWith(cmdArg[1]);
                    Check(check);
                }
                else if(cmdArg[0] == "Lowercase")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if(cmdArg[0] == "FindIndex")
                {
                    char letter = char.Parse(cmdArg[1]);
                    int index = input.LastIndexOf(letter);
                    Console.WriteLine(index);
                }
                else if(cmdArg[0] == "Remove")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int count = int.Parse(cmdArg[2]);

                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);
                }


            }
        }

        private static void Check(bool check)
        {
            if (check)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        private static string Translate(string input, string[] cmdArg)
        {
            char letter = char.Parse(cmdArg[1]);
            char replacement = char.Parse(cmdArg[2]);
            input = input.Replace(letter, replacement);
            Console.WriteLine(input);
            return input;
        }
    }
}
