using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamObeject_My
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Dictionary<string, List<string>>> students = new Dictionary<int, Dictionary<string, List<string>>>();
            string input;

            while ((input = Console.ReadLine()) != "Start")
            {
                string[] inputArg = input.Split().ToArray();
                int studentClass = int.Parse(inputArg[0]);
                string name = inputArg[1];
                if (!students.ContainsKey(studentClass))
                {
                    students[studentClass] = new Dictionary<string, List<string>>();
                }
                if (!students[studentClass].ContainsKey(name))
                {
                    students[studentClass][name] = new List<string>();
                }
                for (int i = 2; i < inputArg.Length; i++)
                {
                    string subject = inputArg[i];
                    bool isExist = students[studentClass][name].Any(s => s == subject);

                    if (isExist == false)
                    {
                        students[studentClass][name].Add(subject);
                    }
                }
            }
            string inputSubject;
            while ((inputSubject = Console.ReadLine()) != "Stop")
            {
                int totalCount = 0;
                foreach (var kvp in students)
                {
                    foreach (var item in kvp.Value)
                    {
                        totalCount += item.Value.Where(x => x == inputSubject).Count();
                    }
                }
                Console.WriteLine($"{inputSubject} : {totalCount}");
                students = students.ToDictionary(x => x.Key, x => x.Value.OrderBy(y=>y.Key)
                .ToDictionary(y=>y.Key,y=>y.Value));

                foreach (var kvp in students)
                {
                   
                    Console.WriteLine($"{kvp.Key} : ");
                    foreach (var item in kvp.Value)
                    {
                        if (item.Value.Any(s => s == inputSubject))
                        {
                            Console.WriteLine($"-- {item.Key}");
                        }
                    }

                }
            }


        }
    }
}
