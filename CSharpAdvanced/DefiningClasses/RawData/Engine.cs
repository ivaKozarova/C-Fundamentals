namespace RawData
{
    class Engine
    {

        private int engineSpeed;
        private int enginePower;

        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }

        public int EngineSpeed
        {
            get { return this.engineSpeed; }
            set { this.engineSpeed = value; }
        }
        public int EnginePower
        {
            get { return this.enginePower; }
            set { this.enginePower = value; }
        }
    }
}
