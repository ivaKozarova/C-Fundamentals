using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var magicValue = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var materialsBoxes = new Stack<int>(materials);
            var magicBoxes = new Queue<int>(magicValue);

            var collectedPresents = new Dictionary<string, int>();

            while (materialsBoxes.Any() && magicBoxes.Any())
            {
                int currentMaterial = materialsBoxes.Peek();
                int currentMagic = magicBoxes.Peek();
                int result = currentMagic * currentMaterial;
                if (result > 0)
                {
                    PositiveResult(materialsBoxes, magicBoxes, collectedPresents, currentMaterial, result);
                }
                else if (result == 0)
                {
                    ZeroResult(materialsBoxes, magicBoxes, currentMaterial, currentMagic);
                }
                else
                {
                    NegativeResult(materialsBoxes, magicBoxes, currentMaterial, currentMagic);
                }
            }
              Print(materialsBoxes, magicBoxes, collectedPresents);

        }

        private static void Print(Stack<int> materialsBoxes, Queue<int> magicBoxes, Dictionary<string, int> collectedPresents)
        {
            if ((collectedPresents.ContainsKey("Doll") && collectedPresents.ContainsKey("Wooden train"))
                || collectedPresents.ContainsKey("Teddy bear") && collectedPresents.ContainsKey("Bicycle"))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materialsBoxes.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materialsBoxes)}");
            }
            if (magicBoxes.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicBoxes)}");
            }

            collectedPresents = collectedPresents.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var (toy, amount) in collectedPresents)
            {
                Console.WriteLine($"{toy}: {amount}");
            }

           
        }

        private static void NegativeResult(Stack<int> materialsBoxes, Queue<int> magicBoxes, int currentMaterial, int currentMagic)
        {
            int sum = currentMaterial + currentMagic;
            materialsBoxes.Pop();
            magicBoxes.Dequeue();
            materialsBoxes.Push(sum);
        }

        private static void ZeroResult(Stack<int> materialsBoxes, Queue<int> magicBoxes, int currentMaterial, int currentMagic)
        {
            if (currentMagic == 0)
            {
                magicBoxes.Dequeue();
            }
            if (currentMaterial == 0)
            {
                materialsBoxes.Pop();
            }
        }

        private static void PositiveResult(Stack<int> materialsBoxes, Queue<int> magicBoxes, Dictionary<string, int> collectedPresents, int currentMaterial, int result)
        {
            switch (result)
            {
                case 150:
                    AddToCollection("Doll", collectedPresents);
                    materialsBoxes.Pop();
                    magicBoxes.Dequeue();
                    break;
                case 250:
                    AddToCollection("Wooden train", collectedPresents);
                    materialsBoxes.Pop();
                    magicBoxes.Dequeue();
                    break;
                case 300:
                    AddToCollection("Teddy bear", collectedPresents);
                    materialsBoxes.Pop();
                    magicBoxes.Dequeue();
                    break;
                case 400:
                    AddToCollection("Bicycle", collectedPresents);
                    materialsBoxes.Pop();
                    magicBoxes.Dequeue();
                    break;
                default:
                    currentMaterial += 15;
                    materialsBoxes.Pop();
                    magicBoxes.Dequeue();
                    materialsBoxes.Push(currentMaterial);
                    break;
            }
        }

        private static void AddToCollection(string present,Dictionary<string,int> collectedPresents)
        {
            if(!collectedPresents.ContainsKey(present))
            {
                collectedPresents[present] = 0;
            }
            collectedPresents[present] += 1;
        }
    }
}
