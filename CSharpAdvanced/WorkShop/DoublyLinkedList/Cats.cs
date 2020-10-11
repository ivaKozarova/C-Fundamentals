namespace DoublyLinkedList
{
    class Cat
    {
        public Cat(string name, int age, string owner)
        {
            this.Name = name;
            this.Age = age;
            this.Owner = owner;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        public override string ToString()
        {

            return $"The cat {this.Name} at {this.Age}y.o. with owner { this.Owner}!".ToString();
        }
    }
}
