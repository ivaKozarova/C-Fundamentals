using System;
using System.Diagnostics.CodeAnalysis;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] Person secondPerson)
        {
            int result = 1;
            if(secondPerson != null)
            {
                result = this.Name.CompareTo(secondPerson.Name);
                if(result == 0)
                {
                    result = this.Age.CompareTo(secondPerson.Age);

                }
            }
            return result; 
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.CompareTo(person) == 0;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
