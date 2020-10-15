
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild : IEnumerable<Player>
    { 
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name);
            if(player != null)
            {
                roster.Remove(player);
                return true;
            }

            return false;
        }
        public void PromotePlayer(string name)
        {
            int indexOfPlayer = FindPlayer(name, "Trail");
            if (indexOfPlayer != -1)
            {
                this.roster[indexOfPlayer].Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            int indexOfPlayer = FindPlayer(name, "Member");
            if (indexOfPlayer != -1)
            {
                this.roster[indexOfPlayer].Rank = "Trail";
            }
        }

        private int FindPlayer(string name, string rank)
        {
            for (int i = 0; i < this.roster.Count; i++)
            {
                if (roster[i].Name == name)
                {
                    if (roster[i].Rank == rank)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public IEnumerator<Player> GetEnumerator()
        {
            for (int i = 0; i < this.roster.Count; i++)
            {
                yield return this.roster[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            var arr = roster.Where(x => x.PlayerClass == playerClass).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                roster.Remove(arr[i]);
            }
            return arr;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            sb.AppendLine($"{string.Join(Environment.NewLine,roster)}");
            return sb.ToString().TrimEnd();

        }

    }
}
