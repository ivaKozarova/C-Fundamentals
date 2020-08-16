using System;
using System.Collections.Generic;
using System.Text;


namespace WeightedUniformStrings
{
    class Program
    {
        static Dictionary<char, int> letters;
        static void Main(string[] args)
        {
            CreateDictionary();
            string input = Console.ReadLine();
            var uniformWeight = new HashSet<int>();
            FillUniforms(input, uniformWeight);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int searchingWeight = int.Parse(Console.ReadLine());
                if (uniformWeight.Contains(searchingWeight))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }


        }

        private static void CreateDictionary()
        {
            letters = new Dictionary<char, int>();
            int i = 1;
            for (char x = 'a'; x <= 'z'; x++)
            {
                letters.Add(x, i);
                i++;
            }
        }
        private static void FillUniforms(string input, HashSet<int> uniformWeight)
        {
            uniformWeight.Add(letters[input[0]]);
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < input.Length; i++)
            {
                    if (input[i] == input[i - 1])
                    {
                        sb.Append(input[i]);
                    }
                    else
                    {
                        sb.Clear();
                        sb.Append(input[i]);
                    }
                    int value = letters[input[i]] * sb.Length;
                    uniformWeight.Add(value);
               
            }
        }
    }

}