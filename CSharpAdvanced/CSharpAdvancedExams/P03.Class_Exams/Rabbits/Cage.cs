using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var rabbit = data.FirstOrDefault(x => x.Name == name);
            if (rabbit != null)
            {
                data.Remove(rabbit);
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var soldRabbit = data.FirstOrDefault(x => x.Name == name);
            if (soldRabbit != null)
            {
                soldRabbit.Available = false;
            }
            return soldRabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbitsfromCurrSpecies = data.Where(x => x.Species == species).ToArray();
            foreach (var rabbit in rabbitsfromCurrSpecies)
            {
                rabbit.Available = false;
            }
            return rabbitsfromCurrSpecies;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");
            var notSoldRabbits = data.Where(x => x.Available == true);
            sb.AppendLine(string.Join(Environment.NewLine, notSoldRabbits));

            return sb.ToString().TrimEnd();
               
        }
    }
}
