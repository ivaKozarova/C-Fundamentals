using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var coll = new List<int>
            {
                4,5,6,7,8,9,10
            };

            var originStack = new Stack<int>(coll);
            originStack.Pop();
            originStack.Push(2);
            originStack.Contains(2);
            originStack.Sum();
            originStack.OrderByDescending(x => x);





            MyStack stack = new MyStack(coll);

            

            stack.Push(23);
            stack.Push(22);
            stack.Push(17);
            stack.Push(12);
            stack.Push(6);
            stack.Push(10);
            stack.Push(9);
            stack.Push(4);


            var count = stack.Count;
            Console.WriteLine(count);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            
            stack.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            
            var list  = stack.Where((x => x % 2 == 0));
            Console.WriteLine(string.Join(' ',list));


            Console.WriteLine($"-- contains 23 ? {stack.Contains(23)}");
            var stackOrig = new Stack<int>();

            
        }
    }
}
