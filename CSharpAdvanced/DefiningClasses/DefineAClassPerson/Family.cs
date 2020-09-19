using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private HashSet<Person> members;
        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person person)
        {
            this.members.Add(person);
        }

        public HashSet<Person> GetAllPeopleAbove30()
        {
            return this.members.Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToHashSet();

                
        }

    }
}
