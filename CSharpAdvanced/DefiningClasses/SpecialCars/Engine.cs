namespace SpecialCars
{
    public class Engine
    {
        public int HorsePowers { get; set; }
        public double  CubicCapacity { get; set; }

        public Engine(int hp, double capacity)
        {
            this.HorsePowers = hp;
            this.CubicCapacity = capacity;
        }

    }
}
