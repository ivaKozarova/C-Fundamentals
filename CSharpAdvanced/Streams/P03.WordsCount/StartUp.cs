using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace P03.WordsCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> countWords = new Dictionary<string, int>();
            StreamReader streamReader = new StreamReader("words.txt");

            var words = new List<string>();
            using (streamReader)
            {
                words = streamReader.ReadToEnd().Split().ToList();
            }

            StreamReader streamReader1 = new StreamReader("text.txt");

            using (streamReader1)
            {
                var text = streamReader1.ReadToEnd().ToLower();
                var punctuations = text.Where(char.IsPunctuation).Distinct().ToArray();
                var wordsArray = text.Split()
                                    .Select(x => x.Trim(punctuations))
                                    .ToArray();

                foreach (var word in wordsArray)
                {

                    if (words.Contains(word))
                    {
                        if (!countWords.ContainsKey(word))
                        {
                            countWords[word] = 0;
                        }
                        countWords[word]++;
                    }

                }
            }

            countWords = countWords.OrderByDescending(x => x.Value)
                       .ToDictionary(x => x.Key, x => x.Value);

            StreamWriter streamWriter = new StreamWriter("otput.txt");
            using (streamWriter)
            {
                foreach (var (word, count) in countWords)
                {
                    streamWriter.WriteLine($"{word} - {count}");
                }
            }

        }
    }
}
