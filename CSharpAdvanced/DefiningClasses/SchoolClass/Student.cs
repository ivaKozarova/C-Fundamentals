using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolClass
{
    public class Student
    {
        private string name;
        private int age;
        private double score;

        public string Name { get; set; }

        public int Age
        {
            get { return age; }
            set
            {
                if(age < 0)
                {
                    throw new InvalidOperationException("Invalid age!");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public double Score { get; set; }

        public Student(string name, int age, double score)
        {
            this.Name = name;
            this.Age = age;
            this.Score = score;
        }


    }
}
