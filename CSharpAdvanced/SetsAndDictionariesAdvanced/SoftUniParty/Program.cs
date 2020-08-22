using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservationList = new HashSet<string>();
            var vipReservationList = new HashSet<string>();
            
            AddToReservationLists(reservationList, vipReservationList);

            string reservationNum; 

            while ((reservationNum = Console.ReadLine()) != "END")
            {
                if (reservationList.Contains(reservationNum))
                {
                    reservationList.Remove(reservationNum);
                }
                else if(vipReservationList.Contains(reservationNum))
                {
                    vipReservationList.Remove(reservationNum);
                }
            }

            PrintList(reservationList, vipReservationList);

        }
    

        private static void PrintList(HashSet<string> reservationNums, HashSet<string> vipReservationList)
        {
            Console.WriteLine(reservationNums.Count + vipReservationList.Count);
            if(vipReservationList.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipReservationList));
            }
            if (reservationNums.Any())
            {

                Console.WriteLine(string.Join("\n", reservationNums));
            }
        }

        private static void AddToReservationLists(HashSet<string> reservationList, HashSet<string> vipReservationList)
        {
            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipReservationList.Add(input);
                    }

                    else
                    {
                        reservationList.Add(input);
                    }
                }
            }
        }
    }
}
