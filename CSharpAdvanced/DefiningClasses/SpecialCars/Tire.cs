namespace SpecialCars
{
    public class Tire
    {
        public int YearOfTire { get; set; }
        public  double Pressure { get; set; }
       
        public Tire(int year, double pressure)
        {
            this.YearOfTire = year;
            this.Pressure = pressure;
        }

    }
}
