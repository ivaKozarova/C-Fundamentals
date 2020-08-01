using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace P03.BattleManager_Aug2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, People> peopleInfo = new Dictionary<string,People>();
            string input;
            while ((input = Console.ReadLine()) != "Results")
            {
                string[] cmdArg = input.Split(':');
                string command = cmdArg[0];

                if (command == "Add")
                {
                    Add(peopleInfo, cmdArg);
                }
                else if(command == "Attack")
                {
                    Attack(peopleInfo, cmdArg);
                }
                else if( command == "Delete")
                {
                    string userName = cmdArg[1];
                    if(userName == "All")
                    {
                        peopleInfo = new Dictionary<string, People>();

                    }
                    peopleInfo.Remove(userName);
                }    
            }
            int count = peopleInfo.Count;
            Console.WriteLine($"People count: {count}");
            peopleInfo = peopleInfo.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in peopleInfo)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Health} - {kvp.Value.Energy}");
            }



        }

        private static void Attack(Dictionary<string, People> peopleInfo, string[] cmdArg)
        {
            string attacker = cmdArg[1];
            string defender = cmdArg[2];
            int damage = int.Parse(cmdArg[3]);

            if (peopleInfo.ContainsKey(attacker) && peopleInfo.ContainsKey(defender))
            {
                peopleInfo[defender].Health -= damage;
                if (peopleInfo[defender].Health <= 0)
                {
                    peopleInfo.Remove(defender);
                    Console.WriteLine($"{defender} was disqualified!");
                }
                peopleInfo[attacker].Energy -= 1;
                if (peopleInfo[attacker].Energy == 0)
                {
                    peopleInfo.Remove(attacker);
                    Console.WriteLine($"{attacker} was disqualified!");
                }
            }
        }

        private static void Add(Dictionary<string, People> peopleInfo, string[] cmdArg)
        {
            string userName = cmdArg[1];
            int health = int.Parse(cmdArg[2]);
            int energy = int.Parse(cmdArg[3]);

            if (!peopleInfo.ContainsKey(userName))
            {
                People person = new People(userName, health, energy);
                peopleInfo[userName] = person;
            }
            else
            {
                peopleInfo[userName].Health += health;
            }
        }
    }
    class People
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }

        public People(string userName , int health , int energy)
        {
            this.Name = userName;
            this.Health = health;
            this.Energy = energy;
        }

    }
}
