namespace RawData
{
    class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int weight,string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }

        public int CargoWeight
        {
            get { return this.cargoWeight; }
            set { this.cargoWeight = value; }
        }
        public string CargoType
        {
            get { return this.cargoType; }
            set { this.cargoType = value; }
        }


    }
}
