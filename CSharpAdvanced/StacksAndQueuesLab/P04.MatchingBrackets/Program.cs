using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace P04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
           
                if(input[i] == '(')
                {
                    stack.Push(i);
                }
                else if(input[i] == ')')
                {
                    int secondIndex = i;
                    int firtstIndex = stack.Pop();
                    Console.WriteLine(input.Substring(firtstIndex, secondIndex - firtstIndex +1));
                }
            }

        }
    }
}
