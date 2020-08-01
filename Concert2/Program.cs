using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._EXAM___Problem_1___Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var bands = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            string[] split = input.Split(new string[] {"; ",", " }, StringSplitOptions.RemoveEmptyEntries);

            while (input != "start of concert")
            {
                string command = split[0];
                string bandName = split[1];

                if (command == "Add")
                {
                    if (!bands.ContainsKey(bandName))
                    {
                        bands.Add(bandName, new List<string>());

                        for (int i = 1; i < split.Length; i++)
                        {
                            if (i == 1)
                            {
                                
                                bands[bandName].Add("0");
                                continue;
                            }
                            bands[bandName].Add(split[i]);
                        }
                    }

                    else
                    {
                        for (int i = 2; i < split.Length; i++)
                        {
                            if (!bands[bandName].Contains(split[i]))
                            {
                                bands[bandName].Add(split[i]);
                            }
                        }
                    }
                }

                else if (command == "Play")
                {
                    double time = double.Parse(split[2]);

                    if (!bands.ContainsKey(bandName))
                    {
                        bands.Add(bandName, new List<string>());
                        bands[bandName].Add("0");
                    }

                    double totalBandTime = double.Parse(bands[bandName][0]);
                    totalBandTime += time;

                    string totalTimeAsStr = totalBandTime.ToString();
                    bands[bandName][0] = totalTimeAsStr;
                }

                input = Console.ReadLine();
                split = input.Split(new string[] {"; ", ", " }, StringSplitOptions.RemoveEmptyEntries);
            }

            bands = bands
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            double totalTimeConcert = 0;

            foreach (var members in bands.Values)
            {
                double time = double.Parse(members[0]);
                totalTimeConcert += time;
            }

            Console.WriteLine($"Total time: {totalTimeConcert}");

            foreach (var band in bands)
            {
                string output = $"{band.Key} -> {band.Value[0]}";
                Console.WriteLine(output.Trim());
            }

            string checkBand = Console.ReadLine();
            Console.WriteLine(checkBand);


            Console.WriteLine($"=> {String.Join("\n=> ", bands[checkBand].Skip(1))}");
        }
    }
}