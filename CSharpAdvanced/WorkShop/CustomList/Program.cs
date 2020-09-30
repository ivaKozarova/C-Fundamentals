using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            
            Console.WriteLine(list.Count);

            for (int i = 5; i > 0; i--)
            {
                list.Add(i);
            }

            Console.WriteLine($"Count: {list.Count}");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"--{list[i]}");
            }

            var result = list.Contains(25);
            Console.WriteLine(result);
            result = list.Contains(5);
            Console.WriteLine(result);

            list.Swap(1, 4);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[4]);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"--{list[i]}");
            }
        }
    }
}
