using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.BalancedParentheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().ToCharArray().Reverse();
            var stackParentheses = new Stack<char>(sequence);

            var stackOpeningParentheses = new Stack<char>();
            bool isBalanced = true;
            while (isBalanced && stackParentheses.Any())
            {
                char ch = stackParentheses.Pop();
                if(ch == '(' || ch == '[' || ch == '{')
                {
                    stackOpeningParentheses.Push(ch);
                }
                else
                {
                    if (stackOpeningParentheses.Any())
                    {
                        char opening = stackOpeningParentheses.Pop();
                        if (opening == '(' && ch != ')')
                        {
                            isBalanced = false;
                        }
                        else if (opening == '[' && ch != ']')
                        {
                            isBalanced = false;
                        }
                        else if (opening == '{' && ch != '}')
                        {
                            isBalanced = false;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }
            if(isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            { 
                Console.WriteLine("NO");
            }



        }
    }
}
