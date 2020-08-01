using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic7_FinalExamApril
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                CollectHeroesForParty(heroes);
            }
            string cmd;

            while((cmd =Console.ReadLine())!= "End")
            {
                string[] cmdArg = cmd.Split(" - ");
                string heroName = cmdArg[1];

                if(cmdArg[0] == "CastSpell")
                {
                    CastSpell(heroes, cmdArg, heroName);
                }
                else if( cmdArg[0] == "TakeDamage")
                {
                    TakeDmg(heroes, cmdArg, heroName);
                }
                else if(cmdArg[0] == "Recharge")
                {
                    RechargeMP(heroes, cmdArg, heroName);
                }
                else if(cmdArg[0] == "Heal")
                {
                    Heal(heroes, cmdArg, heroName);
                }
            }
            heroes = heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key)
                              .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in heroes)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine("  HP: " + kvp.Value[0]);
                Console.WriteLine("  MP: " + kvp.Value[1]);
            }

        }

        private static void Heal(Dictionary<string, List<int>> heroes, string[] cmdArg, string heroName)
        {
            int amount = int.Parse(cmdArg[2]);
            if (amount + heroes[heroName][0] < 100)
            {
                heroes[heroName][0] += amount;
            }
            else
            {
                amount = 100 - heroes[heroName][0];
                heroes[heroName][0] = 100;
            }
            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }

        private static void RechargeMP(Dictionary<string, List<int>> heroes, string[] cmdArg, string heroName)
        {
            int amount = int.Parse(cmdArg[2]);
            if (heroes[heroName][1] + amount < 200)
            {
                heroes[heroName][1] += amount;
            }
            else
            {
                amount = 200 - heroes[heroName][1];
                heroes[heroName][1] = 200;
            }
            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }

        private static void TakeDmg(Dictionary<string, List<int>> heroes, string[] cmdArg, string heroName)
        {
            int dmg = int.Parse(cmdArg[2]);
            string attacker = cmdArg[3];
            if (heroes[heroName][0] - dmg > 0)
            {
                heroes[heroName][0] -= dmg;
                Console.WriteLine($"{heroName} was hit for {dmg} HP by {attacker} " +
                    $"and now has {heroes[heroName][0]} HP left!");
            }
            else
            {
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                heroes.Remove(heroName);
            }
        }

        private static void CastSpell(Dictionary<string, List<int>> heroes, string[] cmdArg, string heroName)
        {
            int mpNeed = int.Parse(cmdArg[2]);
            string spell = cmdArg[3];
            if (heroes[heroName][1] - mpNeed >= 0)
            {
                heroes[heroName][1] -= mpNeed;
                Console.WriteLine($"{heroName} has successfully cast {spell} and now has {heroes[heroName][1]} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spell}!");
            }
        }

        private static void CollectHeroesForParty(Dictionary<string, List<int>> heroes)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int hitPoints = int.Parse(input[1]);
            int manaPoints = int.Parse(input[2]);

            heroes[name] = new List<int>() { hitPoints, manaPoints };
        }
    }
}
