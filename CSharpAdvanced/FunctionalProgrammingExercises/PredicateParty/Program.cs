using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split().ToList();
            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                var cmdArg = command.Split();
                var action = cmdArg[0];
                var criteria = cmdArg[1];
                var arg = cmdArg[2];

                if (action == "Double")
                {
                    DoubleGuests(guests, criteria, arg);
                }
                else if (action == "Remove")
                {
                    RemoveGuest(guests, criteria, arg);
                }

            }

            if(guests.Any())
            {
                Console.WriteLine($"{string.Join(", " guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
        static void RemoveGuest(List<string> guests, string criteria, string arg)
        {
            Predicate<string> predicate = CreatePredicate(criteria, arg);

            for (int i = 0; i < guests.Count; i++)
            {
                if (predicate(guests[i]))
                {
                    guests.RemoveAt(i);
                    i--;
                }
            }
        }

        static void DoubleGuests(List<string> guests, string criteria, string arg)
        {
            Predicate<string> predicate = CreatePredicate(criteria, arg);

            for (int i = 0; i < guests.Count; i++)
            {
                if (predicate(guests[i]))
                {
                    guests.Insert(i, guests[i]);
                    i++;
                }
            }

        }


        private static Predicate<string> CreatePredicate(string criteria, string arg)
        {
            Predicate<string> predicate = null;
            if (criteria == "StartsWith")
            {
                predicate = x => x.StartsWith(arg);
            }
            else if (criteria == "EndsWith")
            {
                predicate = x => x.EndsWith(arg);
            }
            else if (criteria == "Length")
            {
                var argNumber = int.Parse(arg);
                predicate = x => x.Length == argNumber;
            }

            return predicate;
        }
    }
}
