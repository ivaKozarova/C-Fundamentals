using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace Concert_July2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> bandTime = new Dictionary<string, int>();
            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "start of concert")
            {
                string[] inputArg = input.Split(new string[] { "; ", ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string bandName = inputArg[1];
                string cmd = inputArg[0];
                if (!bandTime.ContainsKey(bandName))
                {
                    bandTime[bandName] = 0;
                    bandMembers[bandName] = new List<string>();
                }
                if (cmd == "Play")
                {
                    int time = int.Parse(inputArg[2]);
                    bandTime[bandName] += time;
                }
                else if (cmd == "Add")
                {
                    for (int i = 2; i < inputArg.Length; i++)
                    {
                        string nameOfMember = inputArg[i];

                        if (!bandMembers[bandName].Contains(nameOfMember))
                        {
                            bandMembers[bandName].Add(nameOfMember);
                        }
                    }
                }
            }
            bandTime = bandTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x=>x.Key , x=>x.Value);
            Console.WriteLine($"Total time: {bandTime.Values.Sum()}");
            foreach (var band in bandTime)
            {
                Console.WriteLine($"{ band.Key} -> { band.Value}");
            }
            string inputBand = Console.ReadLine();
            Console.WriteLine(inputBand);
            foreach (var member in bandMembers[inputBand])
            {
                Console.WriteLine($"=> {member}");
            }



        }
    }
}
