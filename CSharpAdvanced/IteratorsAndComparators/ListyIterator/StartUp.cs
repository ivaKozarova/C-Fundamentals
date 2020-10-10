using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split().ToArray();
            var list = new ListyIterator<string>(command.Skip(1).ToArray());

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                switch(input)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "Print":
                       list.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "PrintAll":
                        list.PrintAll();
                        break;
                }
            }


        }
    }
}
