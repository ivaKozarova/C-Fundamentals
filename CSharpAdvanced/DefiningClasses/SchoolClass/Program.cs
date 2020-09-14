using System;
using System.Collections.Generic;

namespace SchoolClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();
            while ((input = Console.ReadLine()) != "end")
            {

                var inputInfo = input.Split();
                string name = inputInfo[0];
                int age = int.Parse(inputInfo[1]);
                double score = double.Parse(inputInfo[2]);
                Student student = new Student(name, age, score);
                students.Add(student);
                

            }
            StudentsClass.PrintAll(students);

        }
    }
}
