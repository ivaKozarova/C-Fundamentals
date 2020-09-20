using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            int commandsCount = int.Parse(Console.ReadLine());

            Stack<string> changes = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandAsArray = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentCommand = commandAsArray[0];

                if (currentCommand == "1")
                {
                    
                    changes.Push(text);
                    text += commandAsArray[1];

                }

                else if (currentCommand == "2")
                {
                    changes.Push(text);
                    int count = int.Parse(commandAsArray[1]);
                    text = text.Substring(0, text.Length - count);
                   

                }

                else if (currentCommand == "3")
                {
                    int index = int.Parse(commandAsArray[1]);
                    
                    Console.WriteLine(text[index - 1]);
                }

                else if (currentCommand == "4")
                {
                    if (changes.Any())
                    {
                        text = changes.Pop();
                    }
                    else
                    {
                        text = string.Empty;
                    }
                }


            }
        }
    }
}