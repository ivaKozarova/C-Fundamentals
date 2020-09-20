using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {

       
        private HashSet<Car> data;


        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new HashSet<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isRemoved = false;
            var currentCar = data
                .FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));
            if (currentCar == null)
            {
                return isRemoved;
            }
            else
            {
                data.Remove(currentCar);
                isRemoved = true;
                return isRemoved;
            }
        }
        public Car GetLatestCar()
        {
                var lastestCar = data.FirstOrDefault(c => c.Year == (data.Max(c => c.Year)));
                return lastestCar;
            
        }

        public Car GetCar(string manufacturer, string model)
        {
            var currentCar = data
                .FirstOrDefault(c => (c.Manufacturer == manufacturer && c.Model == model));
            return currentCar;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {this.Type}:")
                .AppendLine(string.Join(Environment.NewLine, data));

            return result.ToString().TrimEnd();
        }
       
            
    }
}
