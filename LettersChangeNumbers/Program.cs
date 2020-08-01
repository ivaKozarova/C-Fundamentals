using System;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            double sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                string currWord = sequence[i];
                char firstLetter = currWord[0];
                char lastLetter = currWord[currWord.Length - 1];
                double number = double.Parse(sequence[i].Substring(1, sequence[i].Length - 2));
                double temp = 0;

                if (char.IsUpper(firstLetter))
                {
                    int posOfLetter = firstLetter - 'A' + 1;
                    temp = number / posOfLetter;
                }
                else
                {
                    int posOfLetter = firstLetter - 'a' + 1;
                    temp = number * posOfLetter;
                }
                if (char.IsUpper(lastLetter))
                {
                    int posOfLetter = lastLetter - 'A' + 1;
                    temp -= posOfLetter;
                }
                else
                {
                    int posOfLetter = lastLetter - 'a' + 1;
                    temp += posOfLetter;
                }
                sum += temp;

            }
            Console.WriteLine($"{sum:f2}");


        }
    }
}
