using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservationNums = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                reservationNums.Add(input);
            }
            while ((input = Console.ReadLine()) != "END")
            {
                if (reservationNums.Contains(input))
                {
                    reservationNums.Remove(input);
                }
            }

            PrintList(reservationNums);

        }

        private static void PrintList(HashSet<string> reservationNums)
        {
            Console.WriteLine(reservationNums.Count);
            if (reservationNums.Any())
            {
                
                Console.WriteLine(string.Join("\n", reservationNums));
            }
        }
    }
}
