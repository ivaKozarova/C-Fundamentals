using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var males = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var females = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var malesStack = new Stack<int>(males);
            var femalesQueue = new Queue<int>(females);

            int matches = 0;

            while(femalesQueue.Any() && malesStack.Any())
            {
                var currMale = malesStack.Peek();
                var currFemale = femalesQueue.Peek();

                if(currMale <= 0)
                {
                    malesStack.Pop();
                    continue;
                }
                else if (currMale % 25 == 0)
                {
                    malesStack.Pop();
                    if (malesStack.Any())
                    {
                        malesStack.Pop();
                    }
                    continue;
                }
                if (currFemale <= 0)
                {
                    femalesQueue.Dequeue();
                    continue;
                }
                else if(currFemale % 25 == 0 )
                {
                    femalesQueue.Dequeue();
                    if (femalesQueue.Any())
                    {
                        femalesQueue.Dequeue();
                    }
                    continue;
                }

                currFemale = femalesQueue.Dequeue();
                currMale = malesStack.Pop();
                if(currFemale != currMale)
                {
                    currMale -= 2;
                    if (currMale > 0)
                    {
                        malesStack.Push(currMale);
                    }
                }
                else
                {
                    matches++;
                }

            }

            Console.WriteLine($"Matches: {matches}");
            if (malesStack.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ",malesStack)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }
            if (femalesQueue.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", femalesQueue)}");
            }
            else
            {
                Console.WriteLine($"Females left: none");
            }


        }
    }
}
