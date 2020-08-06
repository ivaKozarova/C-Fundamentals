using System;

using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var stackOfInt = new Stack<int>(input);
            string command;
            while((command = Console.ReadLine().ToLower())!= "end")
            {
                var cmdArg = command.Split();
                switch(cmdArg[0].ToLower())
                {
                    case "add":
                        for (int i = 1; i < cmdArg.Length; i++)
                        {
                            stackOfInt.Push(int.Parse(cmdArg[i]));
                        }
                        break;
                    case "remove":
                        int count = int.Parse(cmdArg[1]);
                        if (count <= stackOfInt.Count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                stackOfInt.Pop();
                            }
                        }
                        break;
                }
            }
            
            Console.WriteLine($"Sum: {stackOfInt.Sum()}");

        }
    }
}
