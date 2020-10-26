using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClassroomProject
{
    public  class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.students = new List<Student>();
            this.Capacity = capacity;
        }
       
        public int Capacity { get; set; }

        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if(this.Count < this.Capacity)
            {
                students.Add(student);
                var textToReturn = $"Added student {student.FirstName} {student.LastName}";
                return textToReturn;
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault((x => x.FirstName == firstName && x.LastName == lastName));
            {
                if(student != null )
                {
                    students.Remove(student);
                    return $"Dismissed student {student.FirstName} {student.LastName}";
                }
            }
            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            Student[] studentsWithSubject = this.students.FindAll(x => x.Subject == subject).ToArray();
            if(studentsWithSubject.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in studentsWithSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }
        public int GetStudentsCount()
        {
            return this.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            var currentStudent = students.FirstOrDefault((x => x.FirstName == firstName && x.LastName == lastName));
            return currentStudent;
        }

    }
}
