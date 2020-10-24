using System;
using System.Collections.Generic;

namespace GradingStudents
{
    class Result
    {
        public static List<int> GradingStudents(List<int> grades)
        {
            var result = new List<int>();
            
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] % 5 > 2 && grades[i] >= 38)
                {
                    grades[i] = grades[i] + (5 - grades[i] % 5);
                }
                result.Add(grades[i]);
            }
            return result;
        }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var grades = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var grade = int.Parse(Console.ReadLine());
                grades.Add(grade);

            }
            var result = Result.GradingStudents(grades);
            Console.WriteLine(string.Join(Environment.NewLine , result));

        }
    }
}
