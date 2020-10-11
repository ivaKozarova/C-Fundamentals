using System;
using System.Diagnostics.CodeAnalysis;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    { 
        public Person(string name, int age , string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull] Person secondPerson)
        {
            if(secondPerson == null)
            {
                return 1;
            }
            int result = this.Name.CompareTo(secondPerson.Name);
            if(result == 0)
            {
                result = this.Age.CompareTo(secondPerson.Age);
                if (result == 0)
                {
                    result = this.Town.CompareTo(secondPerson.Town);
                }
            }
            return result;
        }
    }
}
