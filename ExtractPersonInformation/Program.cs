using System;
using System.Text;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                StringBuilder name = new StringBuilder();
                StringBuilder age = new StringBuilder();
                for (int j = input.IndexOf('@') + 1; j < input.IndexOf('|'); j++)
                {
                    name.Append(input[j]);
                }
                for (int j = input.IndexOf('#') + 1; j < input.IndexOf('*'); j++)
                {
                    age.Append(input[j]);
                }

                    Console.WriteLine($"{name} is {age} years old.");
                
            }
        }
    }
}
