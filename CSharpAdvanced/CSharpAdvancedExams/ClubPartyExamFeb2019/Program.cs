using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubPartyExamFeb2019
{
    class Program
    {
        class Hall
        {
            public Hall()
            {
                this.People = new List<int>();
            }
            public string Name { get; set; }
            public int Capacity { get; set; }
            public List<int> People { get; set; }

            public override string ToString()
            {
                return $"{this.Name} -> {string.Join(", ",this.People)}".ToString();
            }
        }
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var stack = new Stack<string>(Console.ReadLine().Split(' '));
            Queue<Hall> halls = new Queue<Hall>();

            //int currentCapacity = 0;
            //List<int> reservations = new List<int>();

            while (stack.Any())
            {
                var current = stack.Pop();
                int people;
                if (int.TryParse(current, out people))
                {
                    if (halls.Count > 0)
                    {
                        var currentHall = halls.Peek();
                        if (currentHall.Capacity + people <= capacity)
                        {
                            currentHall.Capacity += people;
                            currentHall.People.Add(people);
                        }
                        else
                        {
                            Console.WriteLine(currentHall);
                            halls.Dequeue();
                            if (halls.Any())
                            {
                                halls.Peek().Capacity += people;
                                halls.Peek().People.Add(people);
                            }

                        }
                    }
                }
                else
                {
                    Hall hall = new Hall() { Name = current };
                    halls.Enqueue(hall);
                }


            }

                        //        if (currentCapacity + people <= capacity)
                        //        {
                        //            reservations.Add(people);
                        //            currentCapacity += people;
                        //        }
                        //        else
                        //        {
                        //            Console.WriteLine($"{halls.Peek()} -> {string.Join(", ", reservations)}");
                        //            halls.Dequeue();
                        //            currentCapacity = 0;
                        //            reservations = new List<int>();

                        //            if (halls.Any())
                        //            {
                        //                currentCapacity += people;
                        //                reservations.Add(people);
                        //            }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    halls.Enqueue(current);
                 

        }
    }
}
