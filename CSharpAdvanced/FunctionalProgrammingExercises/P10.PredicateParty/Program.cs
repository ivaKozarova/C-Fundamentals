using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command;

            while((command = Console.ReadLine())!= "Party!")
            {
                var cmdArg = command.Split(' ');
                var cmdType = cmdArg[1];
                var arg = cmdArg[2];

                Predicate<string> predicate = GetPredicate(cmdType, arg);

                if(cmdArg[0] == "Double")
                {
                    var matches = guests.FindAll(predicate);
                    if(matches.Count > 0)
                    {
                        foreach (var match in matches)
                        {
                            var index = guests.IndexOf(match);
                            guests.Insert(index, match);
                        }
                    }
                }
                else if(cmdArg[0] == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
            }

            if(guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ",guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string type , string arg)
        {
            switch(type)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(arg);
                case "EndsWith":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length == int.Parse(arg);
                default:
                    return null;
            }
        }
    }
}
