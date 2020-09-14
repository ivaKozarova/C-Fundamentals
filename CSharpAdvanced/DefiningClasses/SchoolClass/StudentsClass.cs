using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolClass
{
    public class StudentsClass
    {
        //public List<Student> Students { get; set; } = new List<Student>();

        //public StudentsClass(Student student)
        //{
        //    Students.Add(student);
        //}

        public static void PrintAll(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}: age: {student.Age} with score {student.Score}");
            }
        }





    }
}
