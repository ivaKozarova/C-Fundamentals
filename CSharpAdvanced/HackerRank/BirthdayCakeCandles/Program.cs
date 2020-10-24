using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BirthdayCakeCandles
{
    class Program
    {
        static void Main(string[] args)
        {
            var candles = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int result = BirthdayCakeCandles(candles);
            Console.WriteLine(result);


        }
        static int BirthdayCakeCandles(List<int> candles)
        {
            int max = candles.Max();
            int result = candles.Where(x => x == max).Count();
                       
            return result;
        }
    }
}
