using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {

        private string type;
        private int capacity;
        private HashSet<Car> data;


        public Parking(string type, int capacity)
        {
            this.type = type;
            this.capacity = capacity;
            this.data = new HashSet<Car>();
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Car car)
        {
            if (this.Count < this.capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            
            var currentCar = data
                .FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));
           if(currentCar == null)
            {
                return false;
            }
           else
            {
                data.Remove(currentCar);
                return true;
            }
        }

        public string GetLatestCar()
        {

            if (data.Count == 0)
            {
                return "null";
            }
            var lastestCar = data.FirstOrDefault(c => c.Year == (data.Max(c => c.Year)));
            return lastestCar.ToString();
        }

        public Car GetCar(string manufacturer , string model)
        {
            var currentCar = data
                .FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));
            return currentCar;
        }

      public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {this.type}:")
                .AppendLine($"{string.Join(Environment.NewLine, data)}");

            return result.ToString().TrimEnd(); 
        }
    }


}
