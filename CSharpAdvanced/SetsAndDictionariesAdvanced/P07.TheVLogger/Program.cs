using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace P07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, List<SortedSet<string>>>();
            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var inputInfo = input.Split();

                if (inputInfo[1] == "joined")
                {
                    JoinUser(vloggers, inputInfo);
                }
                else if (inputInfo[1] == "followed")
                {
                    AddFollowerAndFollowing(vloggers, inputInfo);
                }
            }
            vloggers = vloggers.OrderByDescending(x => x.Value[0].Count)
                               .ThenBy(x => x.Value[1].Count)
                               .ToDictionary(x => x.Key, x => x.Value);
            

            PrintStatistics(vloggers);
        }

        private static void PrintStatistics(Dictionary<string, List<SortedSet<string>>> vloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int i = 1;
            foreach (var (username, list) in vloggers)
            {
                Console.WriteLine($"{i}. {username} : {list[0].Count} followers, {list[1].Count} following");

                if (i == 1)
                {
                    foreach (var follower in list[0])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                i++;
            }
        }


        private static void AddFollowerAndFollowing(Dictionary<string, List<SortedSet<string>>> vloggers, string[] inputInfo)
        {
            string follower = inputInfo[0];
            string following = inputInfo[2];

            if (vloggers.ContainsKey(follower)
                && vloggers.ContainsKey(following)
                && follower != following)
            {
                
                vloggers[following][0].Add(follower);
                vloggers[follower][1].Add(following);
            }
        }

        private static void JoinUser(Dictionary<string, List<SortedSet<string>>> vloggers, string[] inputInfo)
        {
            string userName = inputInfo[0];
            if (!vloggers.ContainsKey(userName))
            {
                vloggers[userName] = new List<SortedSet<string>>();
                vloggers[userName].Add(new SortedSet<string>());
                vloggers[userName].Add(new SortedSet<string>());
            }
        }
    }
}
