using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MirrorWords_ApilExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> sameWord = new List<string>();
            Regex sameWords = new Regex(@"([@|#])([A-Za-z]{3,})(\1){2}([A-Za-z]{3,})(\1)");
            MatchCollection matches = sameWords.Matches(input);
            foreach (Match item in matches)
            {
                string firstWord = item.Groups[2].ToString();
                string secondWord = item.Groups[4].ToString();

                string secondWordReversed = ReverseSecondWord(secondWord);
                if (firstWord == secondWordReversed)
                {
                    sameWord.Add(firstWord + " <=> " + secondWord);

                }
            }
                
            

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            if(sameWord.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ",sameWord));
            }
        }

        private static string ReverseSecondWord(string secondWord)
        {
            
            char[] arr = secondWord.ToCharArray();
            arr = arr.Reverse().ToArray();
            secondWord = new string(arr);
            return secondWord;
        }
    }
}
