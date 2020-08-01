using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NikuldenSmeals_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> likeList = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> unlikeList = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] inputArg = input.Split('-');
                string guest = inputArg[1];
                string meal = inputArg[2];
                if (inputArg[0] == "Like")
                {
                    AddToLikeList(likeList, guest, meal);

                }
                else if (inputArg[0] == "Unlike")
                {
                    RemoveMeal(likeList, unlikeList, guest, meal);
                }
            }
            likeList = likeList.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in likeList)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlikeList.Values.Count}");

        }

        private static void RemoveMeal(Dictionary<string, List<string>> likeList, Dictionary<string, List<string>> unlikeList, string guest, string meal)
        {
            if (!likeList.ContainsKey(guest))
            {
                Console.WriteLine($"{guest} is not at the party.");
            }
            else
            {
                if (likeList[guest].Contains(meal))
                {
                    Console.WriteLine($"{guest} doesn't like the {meal}.");
                    likeList[guest].Remove(meal);
                    if (!unlikeList.ContainsKey(guest))
                    {
                        unlikeList[guest] = new List<string>();
                    }
                    unlikeList[guest].Add(meal);
                }
                else
                {
                    Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                }
            }
        }

        private static void AddToLikeList(Dictionary<string, List<string>> likeList, string guest, string meal)
        {
            if (!likeList.ContainsKey(guest))
            {
                likeList[guest] = new List<string>();
            }
            else
            {
                if (likeList[guest].Contains(meal))
                {
                    return;
                }

            }
            likeList[guest].Add(meal);
        }
    }
}
