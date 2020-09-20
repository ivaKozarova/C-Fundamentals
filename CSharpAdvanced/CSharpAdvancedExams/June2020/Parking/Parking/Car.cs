namespace Parking
{
    public class Car
    {
        public Car(string manifacturer, string model, int year)
        {
            this.Manufacturer = manifacturer;
            this.Model = model;
            this.Year = year;
        }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{this.Manufacturer} {this.Model} ({this.Year})".ToString();
        }


    }
}

