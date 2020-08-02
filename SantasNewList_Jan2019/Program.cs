using System;
using System.Collections.Generic;
using System.Linq;


namespace SantasNewList_Jan2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Children> listOfChildren = new List<Children>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input.Split("->");
                if (inputArg[0] == "Remove" && inputArg.Length == 2)
                {
                    RemoveChild(listOfChildren, inputArg);
                }
                else
                {
                    CreateListOfChildren(listOfChildren, inputArg);
                }
            }
            Dictionary<string, int> presents = new Dictionary<string, int>();
            CreateListOfPresents(listOfChildren, presents);
            PrintInfoAboutChildren(listOfChildren);
            PrintInfoAboutPresents(presents);

            while ((input = Console.ReadLine()) != "Stop")
            {
                FindChild(input, listOfChildren);
            }
        }

        private static void FindChild(string input, List<Children> listOfChildren)
        {
            var result = listOfChildren.Find(x => x.Name == input);
            if (result != null)
            {
                Console.WriteLine($"{result.Name}:");
                foreach (var kvp in result.Present)
                {
                    Console.WriteLine($"--{kvp.Key}:{kvp.Value}");

                }
            }
            else
            {
                Console.WriteLine("Child not found!");
            }
        }

        private static void PrintInfoAboutPresents(Dictionary<string, int> presents)
        {
            Console.WriteLine("Presents:");
            foreach (var kvp in presents)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }

        private static void PrintInfoAboutChildren(List<Children> listOfChildren)
        {
            if (listOfChildren.Any(x => x.Name != "Removed"))
            {
                listOfChildren = listOfChildren.OrderByDescending(x => x.Present.Values.Sum())
                                        .ThenBy(x => x.Name)
                                        .ToList();

                Console.WriteLine("Children:");
                for (int i = 0; i < listOfChildren.Count; i++)
                {
                    if (listOfChildren[i].Name != "Removed")
                    {
                        Console.WriteLine($"{listOfChildren[i].Name} -> {listOfChildren[i].Present.Values.Sum()}");
                    }
                }

            }


        }

        private static void CreateListOfPresents(List<Children> listOfChildren, Dictionary<string, int> presents)
        {
            for (int i = 0; i < listOfChildren.Count; i++)
            {
                foreach (var kvp in listOfChildren[i].Present)
                {
                    if (!presents.ContainsKey(kvp.Key))
                    {
                        presents[kvp.Key] = 0;
                    }
                    presents[kvp.Key] += kvp.Value;

                }
            }
        }

        private static void CreateListOfChildren(List<Children> listOfChildren, string[] inputArg)
        {
            string name = inputArg[0];
            string present = inputArg[1];
            int count = int.Parse(inputArg[2]);
            if (listOfChildren.Any(x => x.Name == name))
            {
                Children result = listOfChildren.Find(x => x.Name == name);
                if (!result.Present.ContainsKey(present))
                {

                    result.Present[present] = count;
                }
                else
                {
                    result.Present[present] += count;
                }
            }
            else
            {
                Children child = new Children(name, present, count);
                listOfChildren.Add(child);
            }
        }

        private static void RemoveChild(List<Children> listOfChildren, string[] inputArg)
        {
            string name = inputArg[1];
            Children result = listOfChildren.Find(x => x.Name == name);
            if (result != null)
            {
                result.Name = "Removed";
            }
        }
    }
    class Children
    {
        public string Name { get; set; }
        public Dictionary<string, int> Present { get; set; }

        public Children(string name, string present, int count)
        {
            this.Name = name;
            this.Present = AddToDic(present, count);
        }
        public Dictionary<string, int> AddToDic(string present, int count)
        {
            Dictionary<string, int> presents = new Dictionary<string, int>();
            presents[present] = count;
            return presents;
        }
    }
}
