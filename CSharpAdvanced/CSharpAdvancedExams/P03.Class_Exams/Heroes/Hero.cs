using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int lvl, Item item)
        {
            this.Name = name;
            this.Level = lvl;
            this.Item = item;
        }
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            sb.AppendLine($"{this.Item}");
            return sb.ToString().TrimEnd();
        }
    }
}
