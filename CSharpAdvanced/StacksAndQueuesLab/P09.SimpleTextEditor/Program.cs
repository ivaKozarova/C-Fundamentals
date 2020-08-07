using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            var undoStep = new Stack<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] operation = Console.ReadLine().Split();
                if (operation[0] == "1")
                {
                    undoStep.Push(text);
                    text += operation[1];
                }
                else if (operation[0] == "2")
                {
                    undoStep.Push(text);
                    int count = int.Parse(operation[1]);
                    text = text.Remove(text.Length - count);
                }
                else if (operation[0] == "3")
                {
                    int index = int.Parse(operation[1]);
                    var ch = text.ToCharArray()[index - 1];
                    Console.WriteLine(ch);
                }
                else if (operation[0] == "4")
                {
                    if (undoStep.Any())
                    {
                        text = undoStep.Pop();
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
