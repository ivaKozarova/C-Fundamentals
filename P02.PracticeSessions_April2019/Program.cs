using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace P02.PracticeSessions_April2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<string>> roadsRacer = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine())!= "END")
            {
                string[] inputArg = input.Split("->");

                string command = inputArg[0];
                string road = inputArg[1];

                if(command == "Add")
                {
                    AddRoadAndRacer(roadsRacer, inputArg, road);
                }
                else if(command == "Move")
                {
                    MoveRacerToAnotherRoad(roadsRacer, inputArg, road);
                }
                else if(command == "Close")
                {
                    roadsRacer.Remove(road);
                }
            }
            roadsRacer = roadsRacer.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Practice sessions:");
            foreach (var kvp in roadsRacer)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var racer in kvp.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }

        }

        private static void MoveRacerToAnotherRoad(Dictionary<string, List<string>> roadsRacer, string[] inputArg, string road)
        {
            string racer = inputArg[2];
            string nextRoad = inputArg[3];
            // if (roadsRacer[road].Any(x => x.Contains(racer)))
            if (roadsRacer[road].Contains(racer))
            {
                roadsRacer[road].Remove(racer);
                roadsRacer[nextRoad].Add(racer);
            }
        }

        private static void AddRoadAndRacer(Dictionary<string, List<string>> roadsRacer, string[] inputArg, string road)
        {
            string racer = inputArg[2];
            if (!roadsRacer.ContainsKey(road))
            {
                roadsRacer[road] = new List<string>();
            }
            roadsRacer[road].Add(racer);
        }
    }
}
