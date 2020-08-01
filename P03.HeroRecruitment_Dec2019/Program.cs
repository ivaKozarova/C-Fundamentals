using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.HeroRecruitment_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();
            string cmd; 

            while((cmd = Console.ReadLine())!= "End")
            {
                string[] cmdArg = cmd.Split();
                string heroName = cmdArg[1];

                if(cmdArg[0] == "Enroll")
                {
                    if(!heroes.ContainsKey(heroName))
                    {
                        heroes[heroName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if(cmdArg[0] == "Learn")
                {
                    string spellName = cmdArg[2];
                    if(!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if(heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                    else
                    {
                        heroes[heroName].Add(spellName);
                    }
                }
                else if(cmdArg[0] == "Unlearn")
                {
                    string spellName = cmdArg[2];
                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                    else
                    {
                        heroes[heroName].Remove(spellName);
                    }
                }

            }
            heroes = heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Heroes:");
            foreach (var kvp in heroes)
            {
                Console.WriteLine($"== {kvp.Key}: {string.Join(", ",kvp.Value)}");
            }
        }
    }
}
