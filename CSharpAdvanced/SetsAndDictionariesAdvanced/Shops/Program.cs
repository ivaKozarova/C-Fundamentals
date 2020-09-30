using System;
using System.Collections.Generic;
using System.Linq;

namespace Shops
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, decimal>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                var inputArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var shop = inputArg[0];
                var product = inputArg[1];
                var price = decimal.Parse(inputArg[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, decimal>();
                }
                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop][product] = price;
                }

            }

            var keys = shops.Select(x => x.Key).ToList();


            for (int i = 0; i < keys.Count; i++)
            {
                shops[keys[i]] = shops[keys[i]].OrderBy(s => s.Value)
                    .ToDictionary(s => s.Key, s => s.Value);
            }

            foreach (var kvp in shops)
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var (product, price) in kvp.Value)
                {
                    Console.WriteLine($"-> {product} - {price}");
                }
            }


        }
    }
}
