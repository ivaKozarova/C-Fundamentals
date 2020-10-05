using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P03.WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            var text = File.ReadAllText("../../../text.txt").ToLower();

            var punctuations = text.Where(char.IsPunctuation).Distinct().ToArray();
            var textArray = text.Split().Select(x => x.Trim(punctuations)).ToArray();

            var dicWords = new Dictionary<string, int>();

            CreateDictionarWithWordsAndCount(words, textArray, dicWords);

            string pathToActualResults = "../../../actualResult.txt";
            WriteToFile(dicWords, pathToActualResults);

            dicWords = dicWords
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);

            string pathToExpectedResults = "../../../expectedResult.txt";
            WriteToFile(dicWords, pathToExpectedResults);

        }

        private static void CreateDictionarWithWordsAndCount(string[] words, string[] textArray, Dictionary<string, int> dicForWords)
        {
            for (int i = 0; i < textArray.Length; i++)
            {
                if (words.Contains(textArray[i]))
                {
                    if (!dicForWords.ContainsKey(textArray[i]))
                    {
                        dicForWords[textArray[i]] = 0;
                    }
                    dicForWords[textArray[i]]++;
                }
            }
        }

        private static void WriteToFile(Dictionary<string, int> dicForWords, string path)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in dicForWords)
            {
                sb.AppendLine($"{kvp.Key} - {kvp.Value}");
            }
            File.WriteAllText(path, sb.ToString());
        }
    }
}

