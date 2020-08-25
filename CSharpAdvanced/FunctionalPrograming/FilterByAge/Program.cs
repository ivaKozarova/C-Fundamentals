using System;
using System.Collections.Generic;


namespace FilterByAge
{
   
    class Program
    {
        static void Main(string[] args)
        {
            var people = CreateListOfPeople();
            string filter = Console.ReadLine();
            var ageFilter = int.Parse(Console.ReadLine());
            string selector = Console.ReadLine();

            Func<Info, bool> filterByAge = CreateFilter(filter, ageFilter);
            Action<Info> print = PrintInfo(selector);

            PrintResult(people, filterByAge, print);
        }
        private static void PrintResult(List<Info> people, Func<Info, bool> filter , Action<Info> print)
        {
            foreach (var person in people)
            {
                if(filter(person))
                {
                    print(person);
                }
            }
        }
        private static List<Info> CreateListOfPeople()
        {
            int n = int.Parse(Console.ReadLine());
            List<Info> info = new List<Info>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ");
                Info currInfo = new Info
                {
                    Name = input[0],
                    Age = int.Parse(input[1])
                };
                info.Add(currInfo);
            }
            return info;
        }

        private static Action<Info> PrintInfo(string selector)
        {
            switch(selector)
            {
                case "name age":
                    return x=> Console.WriteLine($"{x.Name} - {x.Age}");
                case "name":
                    return x => Console.WriteLine($"{x.Name}");
                case "age":
                    return x => Console.WriteLine($"{x.Age}");
                default:
                    return null;
            }
        }

        private static Func<Info, bool> CreateFilter(string filter , int ageFilter)
        {
            switch (filter)
            {
                case "older":
                    return n => n.Age >= ageFilter;
                    
                case "younger":
                    return n => n.Age < ageFilter;
                default:
                    return null;
            }
        }
    }
}
