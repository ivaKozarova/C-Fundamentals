using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }
        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }
        public void Remove(string name)
        {
            data.Remove(data.Find(x => x.Name == name));
        }
        public Hero GetHeroWithHighestStrength()
        {
            var orderedByStrength = data.OrderByDescending(x => x.Item.Strength);
            return orderedByStrength.First();
        }
        public Hero GetHeroWithHighestAbility()
        {
           var orderedByAbility = data.OrderByDescending(x => x.Item.Ability);
           return orderedByAbility.First();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var orderedByIntelligence = data.OrderByDescending(x => x.Item.Intelligence);
            return orderedByIntelligence.First();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{string.Join(Environment.NewLine, data)}");
            return sb.ToString().TrimEnd();
        }
    }
}
