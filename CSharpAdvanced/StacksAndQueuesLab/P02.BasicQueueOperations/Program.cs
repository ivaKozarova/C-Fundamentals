using System;

using System.Collections.Generic;
using System.Linq;

namespace P02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < numbers[0]; i++)
            {
                if(i <  inputNum.Length)
                {
                    queue.Enqueue(inputNum[i]);
                }
            }

            int numbersToRemove = numbers[1];
            for (int i = 0; i < numbersToRemove; i++)
            {
                if (queue.Any())
                {
                    queue.Dequeue();
                }
            }

            int numberToFind = numbers[2];

            if(queue.Any())
            {
                if(queue.Contains(numberToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int smallest = Int32.MaxValue;
                    while(queue.Any())
                    {
                        int number = queue.Dequeue();
                        if(number < smallest)
                        {
                            smallest = number;
                        }
                    }
                    Console.WriteLine(smallest);
                }
            }
            else
            {
                Console.WriteLine(0);
            }




        }
    }
}
