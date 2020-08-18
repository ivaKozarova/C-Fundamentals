using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Wardrobe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            AddClothes(wardrobe, n);

            var findCloth = Console.ReadLine().Split();
            PrintWardrobe(wardrobe, findCloth);
        }

        private static void PrintWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe, string[] findCloth)
        {
            string colorSearched = findCloth[0];
            string clothSearched = findCloth[1];

            foreach (var (color, clothCount) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (cloth, count) in clothCount)
                {
                    if (color == colorSearched && cloth == clothSearched)
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {count}");
                    }
                }
            }
        }

        private static void AddClothes(Dictionary<string, Dictionary<string, int>> wardrobe, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string color = info[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                for (int j = 1; j < info.Length; j++)
                {
                    string cloth = info[j];
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color][cloth] = 0;
                    }
                    wardrobe[color][cloth]++;
                }
            }
        }
    }
}
