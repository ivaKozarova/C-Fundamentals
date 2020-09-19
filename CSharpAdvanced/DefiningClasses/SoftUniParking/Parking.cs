using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;
        public Parking( int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }
        public int Count
        {
            get { return this.cars.Count; }
        }
        
        public string AddCar(Car car)
        {
            if(this.cars.Any(c=>c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if(this.cars.Count >= capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if(!this.cars.Any(c=>c.RegistrationNumber == registrationNumber ))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                int indexOfCar = this.cars.FindIndex(c => c.RegistrationNumber == registrationNumber);
                this.cars.RemoveAt(indexOfCar);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car currentCar = this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            return currentCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                this.cars.RemoveAll(c => c.RegistrationNumber == regNumber);
            }
        }




    }
}
