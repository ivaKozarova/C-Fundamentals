using System;
using System.Collections.Generic;

namespace Pangram
{
    class Program
    {
        static List<char> alphabet;
        static void Main(string[] args)
        {
            CreateListOfLetter();
            string input = Console.ReadLine().ToLower();
            CheckLetters(input);
        }

        public static void CreateListOfLetter()
        {
            alphabet = new List<char>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                alphabet.Add(i);
            }
        }
        public static void CheckLetters(string input)
        {
            foreach (var letter in input)
            {
                if(alphabet.Contains(letter))
                {
                    alphabet.Remove(letter);
                }
            }
            if(alphabet.Count == 0)
            {
                Console.WriteLine("pangram");
            }
            else
            {
                Console.WriteLine("not pangram");
            }
        }
    }
}
