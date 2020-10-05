using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string command;

            Action<int[]> print = new Action<int[]>(numbers =>
                   Console.WriteLine(string.Join(' ', numbers)));
           

            while ((command = Console.ReadLine()) != "end")
            {
               if(command == "print")
                {
                    print(numbers);
                }
               else
                {
                    Func<int[], int[]> manipulator = Manipulator(command);

                    numbers = manipulator(numbers);
                }
            }

        }
        static Func<int[], int[]> Manipulator (string command)
        {
            Func<int[], int[]> manipulator = 
            
                     new Func<int[], int[]>(numbers =>
               {
                   if (command == "add")
                   {
                       for (int i = 0; i < numbers.Length; i++)
                       {
                           numbers[i]++;
                       }
                   }
                   else if( command == "multiply")
                   {
                       for (int i = 0; i < numbers.Length; i++)
                       {
                           numbers[i] *= 2;
                       }
                   }
                   else if(command == "subtract")
                   {
                       for (int i = 0; i < numbers.Length; i++)
                       {
                           numbers[i]--;
                       }
                   }
                   return numbers;
               });
                return manipulator;
        }
    }
}
