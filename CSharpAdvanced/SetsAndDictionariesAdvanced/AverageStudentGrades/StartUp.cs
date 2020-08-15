using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class StartUp
    {
        static Dictionary<string, List<decimal>> studentsGrade;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            studentsGrade = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                AddStudents();
            }
            PrintResuts();
        }

        private static void PrintResuts()
        {
            foreach (var (key, value) in studentsGrade)
            {
                var grades = string.Join(" ", (value.Select(x => x.ToString("F2"))));
                var average = value.Average();
                Console.WriteLine($"{key} -> {grades} (avg: {average:f2})");

            }
        }

        private static void AddStudents()
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            decimal grade = decimal.Parse(input[1]);

            
            if (!studentsGrade.ContainsKey(name))
            {
                studentsGrade[name] = new List<decimal>();
            }
            studentsGrade[name].Add(grade);
        }
    }
}
