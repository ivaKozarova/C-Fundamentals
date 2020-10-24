using System;
using System.Linq;
using System.Numerics;

namespace MinAndMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));
            MinAndMaxSum(arr);

        }

        static void MinAndMaxSum(int[] arr)
        {
            long sum = arr.Sum(x => (long)x);
                  long maxSum = sum -  arr.Min();
            long  minSum= sum - arr.Max();
            Console.WriteLine($"{minSum} {maxSum}");
        }
    }
}
