using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PasswordResetAprilGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input;

            while((input=Console.ReadLine()) != "Done")
            {
                string[] inputArg = input.Split();
                if (inputArg.Length == 1)
                {
                    text = TakeOdd(text);
                }
                else if (inputArg[0] == "Cut")
                {
                    text = CutSubstring(text, inputArg);
                }
                else if (inputArg[0] == "Substitute")
                {
                    text = ReplaceWithSustitute(text, inputArg);
                }

            }
            Console.WriteLine($"Your password is: {text}");
        }

        private static string ReplaceWithSustitute(string text, string[] inputArg)
        {
            string substringtoFind = inputArg[1];
            string substituteString = inputArg[2];
            if (!text.Contains(substringtoFind))
            {
                Console.WriteLine("Nothing to replace!");
            }
            else
            {
                while (text.Contains(substringtoFind))
                {
                    text = text.Replace(substringtoFind, substituteString);
                    Console.WriteLine(text);
                }
            }
           
            return text;
        }

        private static string CutSubstring(string text, string[] inputArg)
        {
            int index = int.Parse(inputArg[1]);
            int length = int.Parse(inputArg[2]);

            string subString = text.Substring(index, length);
            if (text.Contains(subString))
            {
                text = text.Remove(text.IndexOf(subString), length);
            }
            Console.WriteLine(text);
            return text;
        }

        private static string TakeOdd(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append(text[i]);
                }
            }
            text = sb.ToString();
            Console.WriteLine(text);
            return text;
        }
    }
}
