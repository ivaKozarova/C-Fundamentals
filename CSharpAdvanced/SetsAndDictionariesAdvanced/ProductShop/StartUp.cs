using System;
using System.Collections.Generic;
using System.Linq;


namespace ProductShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            var shops = new Dictionary<string, Dictionary<string, double>>();
            while ((input = Console.ReadLine()) != "Revision")
            {
                AddShops(input, shops);
            }
            shops = shops.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value.ToDictionary(y => y.Key, y => y.Value));

            PrintShopsAndProductsList(shops);
        }

        private static void PrintShopsAndProductsList(Dictionary<string, Dictionary<string, double>> shops)
        {
            foreach (var (key, kvp) in shops)
            {
                Console.WriteLine($"{key}->");
                foreach (var (productKey, produstPrice) in kvp)
                {
                    Console.WriteLine($"Product: {productKey}, Price: {produstPrice}");
                }
            }
        }

        private static void AddShops(string input, Dictionary<string, Dictionary<string, double>> shops)
        {
            var inputArg = input.Split(", ");
            string shop = inputArg[0];
            string product = inputArg[1];
            double price = double.Parse(inputArg[2]);

            if (!shops.ContainsKey(shop))
            {
                shops[shop] = new Dictionary<string, double>();
            }
            if (!shops[shop].ContainsKey(product))
            {
                shops[shop][product] = 0;
            }
            shops[shop][product] = price;
        }
    }
}
