using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string numbers = Console.ReadLine();
            var stackOfNum = new Stack<int>(numbers.Split().Select(int.Parse));
            int elementsToPop = integers[1];

            for (int i = 0; i < elementsToPop; i++)
            {
                if(stackOfNum.Any())
                {
                    stackOfNum.Pop();
                }
            }

            if (stackOfNum.Any())
            {
                int findElement = integers[2];


                if (stackOfNum.Contains(findElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int smallest = Int32.MaxValue;
                    while (stackOfNum.Any())
                    {
                        int currentNum = stackOfNum.Pop();
                        if (currentNum < smallest)
                        {
                            smallest = currentNum;
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
