using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            int travelPoints = 0;
            var destinations = new List<string>();

            if(matches.Any())
            {
                travelPoints = AddMatchToList(matches, travelPoints, destinations);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }

        private static int AddMatchToList(MatchCollection matches, int travelPoints, List<string> destinations)
        {
            foreach (var match in matches)
            {
                string destination = match.ToString();
                destination = destination.Substring(1, destination.Length - 2);
                travelPoints += destination.Length;
                destinations.Add(destination);
            }

            return travelPoints;
        }
    }
}
