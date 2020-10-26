using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            var thread = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var valueOfTask = int.Parse(Console.ReadLine());
            while (true)
            {
                var currentTask = task.Peek();
                var currentThread = thread.Peek();

                   if (currentTask == valueOfTask)
                    {
                        Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                        break;
                    }
                   else if (currentThread >= currentTask)
                    {
                   
                        task.Pop();
                        thread.Dequeue();
                    }
                
                else
                {
                    thread.Dequeue();
                }
            }
            Console.WriteLine(string.Join(' ',thread));
        }
    }
}