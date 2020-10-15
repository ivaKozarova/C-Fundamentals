using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split().ToArray();

            Stack<string> inputArg = new Stack<string>(input);

            Queue<string> halls = new Queue<string>();
            List<int> guests = new List<int>();
            
            int currCapacity = 0;

            while (inputArg.Any())
            {
                var currentElement = inputArg.Pop();

                var isDigit = int.TryParse(currentElement, out int countOfGuests);

                if(!isDigit)
                {
                    halls.Enqueue(currentElement);
                }
                else
                {
                    if(currCapacity + countOfGuests > n)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", guests)}");
                        currCapacity = 0;
                        guests.Clear();
                    }
                    if(halls.Any())
                    {
                        guests.Add(countOfGuests);
                        currCapacity += countOfGuests;
                    }
                }
            }

        }
    }
}
