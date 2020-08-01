using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.InboxManager_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sentEmails = new Dictionary<string, List<string>>();
            string input;
            while((input = Console.ReadLine())!= "Statistics")
            {
                string[] inputArg = input.Split("->");
                string command = inputArg[0];
                string userName = inputArg[1];

                if(command == "Add")
                {
                    if(!sentEmails.ContainsKey(userName))
                    {
                        sentEmails[userName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{userName} is already registered");
                    }
                }
                else if( command == "Send")
                {
                    if(!sentEmails.ContainsKey(userName))
                    {
                        sentEmails[userName] = new List<string>();
                    }
                    sentEmails[userName].Add(inputArg[2]);
                }
                else if(command == "Delete")
                {
                    if (sentEmails.ContainsKey(userName))
                    {
                        sentEmails.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"{userName} not found!");
                    }
                }

            }
            sentEmails = sentEmails.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Users count: {sentEmails.Count}");
            foreach (var kvp in sentEmails)
            {
                Console.WriteLine(kvp.Key);
                foreach (var email in kvp.Value)
                {
                    Console.WriteLine($"- {email}");
                }
            }
        }
    }
}
