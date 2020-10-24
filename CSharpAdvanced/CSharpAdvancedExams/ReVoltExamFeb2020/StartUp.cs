using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RabbitClass

{
    class StartUp
    {
        class Rabbit 
        {
            
            public string Name { get; set; }
            public bool Available { get; set; }

            public string Spices { get; set; }
            public override string ToString()
            {
                return $"{this.Name}-> {this.Available} -- {this.Spices}".ToString();
            }

          
        }
        class Rabbits : IEnumerable<Rabbit>
        {
            private List<Rabbit> data;
            public Rabbits()
            {
                this.data = new List<Rabbit>();
            }
            public void Add(Rabbit rabbit)
            {
                data.Add(rabbit);
            }

            public IEnumerator<Rabbit> GetEnumerator()
            {
                for (int i = 0; i < data.Count; i++)
                {
                    yield return data[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        static void Main(string[] args)
        {
            
            Rabbit rabbit = new Rabbit() { Name = "pesho", Available = true, Spices = "gogo" };
            Rabbit rabbit2 = new Rabbit() { Name = "Gosho", Available = false, Spices = "stop" };
            Rabbit rabbit3 = new Rabbit() { Name = "Krasi", Available = true, Spices = "gogo" };
            Rabbits rabbits = new Rabbits();
            rabbits.Add(rabbit);
            rabbits.Add(rabbit2);
            rabbits.Add(rabbit3);
            foreach (var rab in rabbits)
            {
                Console.WriteLine(rab);
            }
            var selected = rabbits.Where(x => x.Spices == "gogo").Select(x => { x.Available = false; return x; });
            
            foreach (var el in selected)
            {
                Console.WriteLine(el);
            }


        }

    }


    }
   
