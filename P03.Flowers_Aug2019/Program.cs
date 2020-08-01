using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Flowers_Aug2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> followers = new Dictionary<string, List<int>>();

            string input;
            while((input= Console.ReadLine())!= "Log out")
            {
                string[] commandArg = input.Split(": ");
                string command = commandArg[0];
                string userName = commandArg[1];

                if(command == "New follower")
                {
                    if(!followers.ContainsKey(userName))
                    {
                        followers[userName] = new List<int> { 0, 0 };
                    }
                }
                else if(command =="Like")
                {
                    if (!followers.ContainsKey(userName))
                    {
                        followers[userName] = new List<int> { 0, 0 };
                    }
                    int likes = int.Parse(commandArg[2]);
                    followers[userName][0] += likes;
                }
                else if(command == "Comment")
                {
                    if (!followers.ContainsKey(userName))
                    {
                        followers[userName] = new List<int> { 0, 0 };
                    }
                    followers[userName][1]++;
                }
                else if(command == "Blocked")
                {
                    if (followers.ContainsKey(userName))
                    {
                        followers.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"{userName} doesn't exist.");
                    }
                }

            }
            Console.WriteLine($"{followers.Count} followers");
            followers = followers.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in followers)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Sum()}");
            }

        }
    }
}
