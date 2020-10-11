using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            var people = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                var inputArg = input.Split(' ');
                var name = inputArg[0];
                var age = int.Parse(inputArg[1]);
                var town = inputArg[2];
                var person = new Person(name, age, town);
                people.Add(person);
            }

            var n = int.Parse(Console.ReadLine());

            var currentPerson = people[n - 1];

            var matches = 0;

            for (int i = 0; i < people.Count; i++)
            {
                int result = currentPerson.CompareTo(people[i]);
                if(result == 0)
                {
                    matches++;
                }
            }

            if(matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }


        }
    }
}
