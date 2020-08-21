using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace P08.Ranking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var contestPasswords = new Dictionary<string, string>();
            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                CreatePasswordList(contestPasswords, input);
            }
            var ranking = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var inputArg = input.Split("=>");
                string contest = inputArg[0];
                string password = inputArg[1];

                if (contestPasswords.ContainsKey(contest)
                    && contestPasswords[contest] == password)
                {
                    CreateRankingList(ranking, inputArg, contest);
                }
            }

            PrintBestCandidate(ranking);
            PrintUsers(ranking);
        }

        private static void PrintUsers(Dictionary<string, Dictionary<string, int>> ranking)
        {
            ranking = ranking.OrderBy(x => x.Key)
                            .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(x=>x.Value)
                            .ToDictionary(y=>y.Key, y=> y.Value));

            Console.WriteLine("Ranking:");

            foreach (var (user, contestPoints) in ranking)
            {
                Console.WriteLine($"{user}");
                foreach (var (contest, points) in contestPoints)
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }

        private static void PrintBestCandidate(Dictionary<string, Dictionary<string, int>> ranking)
        {
            ranking = ranking.OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);
            var Bestuser = ranking.Take(1);
            foreach (var kvp in Bestuser)
            {
                Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value.Values.Sum()} points.");
            }
        }

        private static void CreateRankingList(Dictionary<string, Dictionary<string, int>> ranking, string[] inputArg, string contest)
        {
            string user = inputArg[2];
            int points = int.Parse(inputArg[3]);

            if (!ranking.ContainsKey(user))
            {
                ranking[user] = new Dictionary<string, int>();
            }

            if (!ranking[user].ContainsKey(contest) || ranking[user][contest] < points)
            {
                ranking[user][contest] = points;
            }
        }

        private static void CreatePasswordList(Dictionary<string, string> contestPasswords, string input)
        {
            var arg = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
            string contest = arg[0];
            string password = arg[1];
            if (!contestPasswords.ContainsKey(contest))
            {
                contestPasswords[contest] = string.Empty;
            }
            contestPasswords[contest] = password;
        }
    }
}
