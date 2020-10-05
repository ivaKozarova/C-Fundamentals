using System;

namespace BoxOfT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(3);
            box.Add(5);
            Console.WriteLine(box.Remove());

            Box<string> names = new Box<string>();

            names.Add("Krasi");
            names.Add("Pesho");

            Console.WriteLine(names.Remove());

            Console.WriteLine(names.Count);


        } 
    }
}
