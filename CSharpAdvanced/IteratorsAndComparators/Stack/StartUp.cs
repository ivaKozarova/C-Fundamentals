using System;
using System.Linq;

namespace Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var myStack = new MyStack<int>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArg = input.Split(' ', 2);
                if(cmdArg[0] == "Push")
                {
                    var elements = cmdArg[1].Split(", ").Select(int.Parse).ToArray();
                    myStack.Push(elements);
                }
                else if(cmdArg[0] == "Pop")
                {
                    myStack.Pop();
                }

            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(string.Join(Environment.NewLine, myStack));
            }
            
        }
    }
}
