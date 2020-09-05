using System;
using System.Globalization;
using System.Linq;

namespace P05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Action<int[]> print = numbers =>
            {
                Console.WriteLine(String.Join(' ', numbers));
            };

            string action;

            while ((action = Console.ReadLine()) != "end")
            {
                if (action == "print")
                {
                    print(numbers);

                }
                else
                {
                    Func<int[], int[]> manipulator = ManipulateArray(action);
                    numbers = manipulator(numbers);
                }

            }
        }

        static Func<int[],int[]> ManipulateArray (string action)
        {
            Func<int[], int[]> manipulator = null;
            if (action == "add")
            {
                manipulator = new Func<int[], int[]>((numbers) =>
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]++;
                    }
                    return numbers;
                });
            }
            else if (action == "subtract")
            {
                manipulator = new Func<int[], int[]>(numbers =>
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }
                    return numbers;
                });
            }
            else if (action == "multiply")
            {
                manipulator = new Func<int[], int[]>(numbers =>
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] *= 2;
                    }
                    return numbers;
                });
            }
            
                return manipulator;
            
           
        }
    }
}
