using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace HitListExamFeb2018
{
    class StartUp
    {
        public class Person
        {
            public Person(string name)
            {
                this.Name = name;
                this.InfoIndex = 0;
                this.Info = new Dictionary<string, string>();
            }
            public string Name { get; set; }
            public Dictionary<string, string> Info { get; set; }
            public int InfoIndex { get; set; }

            public void CalcIndex(int value)
            {
                
                this.InfoIndex += value;
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                   sb.AppendLine ($"Info on {this.Name}:");
                foreach (var kvp in this.Info.OrderBy(x=>x.Key))
                {
                    sb.AppendLine($"---{kvp.Key}: {kvp.Value}");
                }
                sb.AppendLine($"Info index: {this.InfoIndex}");
                return sb.ToString().TrimEnd();
            }

        }

        //public class People
        //{
        //    public People()
        //    {
        //        this.PeopleList = new List<Person>();
        //    }
        //    public List<Person> PeopleList { get; set; }
        //    private void Add(Person person)
        //    {
        //        this.PeopleList.Add(person);
        //    }
        //}

        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());

            string input;
            List<Person> people = new List<Person>();
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var infoArg = input.Split(new char[] { '=', ';' });
                var name = infoArg[0];
                bool isExist = false;
                foreach (var el in people)
                {
                    if (el.Name == name)
                    {
                        AddPersonInfo(infoArg, el);
                        isExist = true;
                        break;
                    }
                }
                    if (!isExist)
                    {
                        Person person = new Person(name);
                        people.Add(person);
                        AddPersonInfo(infoArg, person);
                    }
                
            }
            var searchedPerson = Console.ReadLine().Split();
            for (int i = 0; i < people.Count; i++)
            {
                if(people[i].Name == searchedPerson[1])
                {
                    Console.WriteLine(people[i]);
                    if(people[i].InfoIndex >= targetIndex)
                    {
                        Console.WriteLine("Proceed");
                    }
                    else
                    {
                        Console.WriteLine($"Need {targetIndex - people[i].InfoIndex} more info.");
                    }
                    break;
                }
            }


        }

        private static void AddPersonInfo(string[] infoArg, Person person)
        {
            for (int i = 1; i < infoArg.Length; i++)
            {
                var info = infoArg[i].Split(':');
                int infoIndex = 0;

                if (!person.Info.ContainsKey(info[0]))
                {
                    person.Info[info[0]] = info[1];
                    infoIndex = info[0].Length + info[1].Length;
                }
                else
                {
                    int value = person.Info[info[0]].Length ;
                    person.Info[info[0]] = info[1];
                    infoIndex = info[1].Length - value;
                }
               
                
                person.CalcIndex(infoIndex);
            }
        }
    }
}
