using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var guest = Console.ReadLine().Split().ToList();

            string command;
            var listOfCommands = new HashSet<string>();
            while ((command = Console.ReadLine()) != "Print")
            {
                ReadFilters(command, listOfCommands);
            }

            RunFilters(listOfCommands, guest);

            Console.WriteLine(string.Join(' ', guest));

        }

        static void RunFilters(HashSet<string> filters, List<string> guests)
        {
            
            foreach (var item in filters)
            {
                var args = item.Split(";");
                var filterType = args[0];

                Predicate<string> predicate = GetPredicate(filterType, args[1]);

                for (int i = 0; i < guests.Count; i++)
                {
                    if (predicate(guests[i]))
                    {
                        guests.Remove(guests[i]);
                        i--;
                    }
                }
            }
        }

        private static Predicate<string> GetPredicate(string filter, string arg)
        {
            Predicate<string> predicate = null;
            switch (filter)
            {
                case "Starts with": 
                    return predicate = x => x.StartsWith(arg);
                case "Ends with":
                    return predicate = x => x.EndsWith(arg);
                case "Contains":
                    return predicate = x => x.Contains(arg);
                case "Length": 
                    return predicate = x => x.Length == int.Parse(arg);
                default:
                    return null;
            }
        }

        static void ReadFilters(string command, HashSet<string> listOfCommands)
        {
            var cmdArg = command.Split(";", 2);

            var filter = cmdArg[0];
            var parameter = cmdArg[1];

            if (filter == "Add filter")
            {
                listOfCommands.Add(parameter);
            }
            else if (filter == "Remove filter")
            {
                if (listOfCommands.Contains(parameter))
                {
                    listOfCommands.Remove(parameter);
                }
            }
        }
    }
}
