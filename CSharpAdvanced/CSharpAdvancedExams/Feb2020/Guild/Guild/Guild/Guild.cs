using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private HashSet<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new HashSet<Player>();

        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.roster.Count; }
        }

        public void AddPlayer(Player player)
        {
            if(this.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            bool isPlayerRemoved = true;
            var currPlayer = roster.FirstOrDefault(p => p.Name == name);
            if (currPlayer == null)
            {
                isPlayerRemoved = false;
            }
            else
            {
                roster.Remove(currPlayer);
            }
            return isPlayerRemoved;
        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = roster.FirstOrDefault(p => p.Name == name);
            if(playerToPromote != null && playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var playerToPromote = roster.FirstOrDefault(p => p.Name == name);
            if (playerToPromote != null && playerToPromote.Rank != "Trail")
            {
                playerToPromote.Rank = "Trail";
            }
        }

        public Player[] KickPlayersByClass(string classPlayer)
        {

            var players = roster.Where(p => p.Class == classPlayer).ToArray();
            foreach (var player in players)
            {
                roster.Remove(player);
            }
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Players in the guild: {this.Name}")
               .Append(string.Join(Environment.NewLine, roster));
            return sb.ToString().TrimEnd();
        }

    }
}
