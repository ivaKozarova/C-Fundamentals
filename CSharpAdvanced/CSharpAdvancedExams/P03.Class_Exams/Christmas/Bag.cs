using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        //private string color;
        //private int capacity;
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Present present)
        {
            if(this.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            if(data.Any(x=>x.Name == name))
            {
                data.Remove(data.First(x => x.Name == name));
                    return true;
            }
            return false;
        }

        public Present GetHeaviestPresent()
        {
            var heaviest = data.OrderByDescending(x => x.Weight).FirstOrDefault();
            return heaviest;
        }
        public Present GetPresent(string name)
        {
            var currentPresent = data.FirstOrDefault(x => x.Name == name);
            return currentPresent;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var item in this.data)
            {
                sb.AppendLine($"{item.ToString()}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
