
using System.Text;

namespace Guild
{
    public class Player
    {

        public Player(string name, string playerClass)
        {
            this.Name = name;
            this.PlayerClass = playerClass;
            this.Description = "n/a";
            this.Rank = "Trail";

        }

        public Player(string name, string playerClass, string description, string rank)
            : this(name, playerClass)
        {
            this.Description = description;
            this.Rank = rank;
        }

        public string Name { get; set; }
        public string PlayerClass { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.PlayerClass}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }

    }
}
