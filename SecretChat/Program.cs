using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd;
            while((cmd = Console.ReadLine())!= "Reveal")
            {
                string[] cmdArg = cmd.Split(":|:");
                string action = cmdArg[0];
                if(action == "InsertSpace")
                {
                    int index = int.Parse(cmdArg[1]);
                    input = input.Insert(index, " ");
                    Console.WriteLine(input);
                }
                else if (action == "Reverse")
                {
                    string valueSubstring = cmdArg[1];
                    if(input.Contains(valueSubstring))
                    {
                        input = input.Remove(input.IndexOf(valueSubstring), valueSubstring.Length);
                        string valueSubstring2 = new String(valueSubstring.Reverse().ToArray());

                        input += valueSubstring2;
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if(action == "ChangeAll")
                {
                    string valueSubstring = cmdArg[1];
                    string replacement = cmdArg[2];
                    while(input.Contains(valueSubstring))
                    {
                        input = input.Replace(valueSubstring, replacement);
                        Console.WriteLine(input);
                    }
                }
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
