using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Dictionary_April2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
           
            string[] inputDefinitions = Console.ReadLine().Split(" | ").ToArray();
            CreateDic(dic, inputDefinitions);
           
            string[] words = Console.ReadLine().Split(" | ");
            PrintWordMeaning(dic, words);
           
            string command = Console.ReadLine();
            dic = PrintList(dic, command);

        }

        private static Dictionary<string, List<string>> PrintList(Dictionary<string, List<string>> dic, string command)
        {
            if (command == "List")
            {
                dic = dic.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var kvp in dic)
                {
                    Console.Write($"{kvp.Key} ");
                }
                Console.WriteLine();
            }

            return dic;
        }

        private static void PrintWordMeaning(Dictionary<string, List<string>> dic, string[] words)
        {
            foreach (var word in words)
            {
                if (dic.ContainsKey(word))
                {
                    dic[word] = dic[word].OrderByDescending(x => x.Length).ToList();

                    Console.WriteLine(word);
                    foreach (var item in dic[word])
                    {
                        Console.WriteLine($"-{item}");
                    }
                }
            }
        }

        private static void CreateDic(Dictionary<string, List<string>> dic, string[] inputDefinitions)
        {
            foreach (var input in inputDefinitions)
            {
                string[] info = input.Split(": ");
                string word = info[0];
                if (!dic.ContainsKey(word))
                {
                    dic[word] = new List<string>();
                }
                dic[word].Add(info[1]);
            }
        }
    }
}
