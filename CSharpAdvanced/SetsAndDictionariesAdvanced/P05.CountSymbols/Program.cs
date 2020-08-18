using System;
using System.Collections.Generic;

namespace P05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbolCounter = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            AddSymbols(symbolCounter, text);
            Print(symbolCounter);
        }

        private static void Print(SortedDictionary<char, int> symbolCounter)
        {
            foreach (var (symbol, count) in symbolCounter)
            {
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }

        private static void AddSymbols(SortedDictionary<char, int> symbolCounter, string text)
        {
            foreach (var symbol in text)
            {
                if (!symbolCounter.ContainsKey(symbol))
                {
                    symbolCounter[symbol] = 0;
                }
                symbolCounter[symbol]++;
            }
        }
    }
}
