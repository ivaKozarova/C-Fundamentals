using System;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length -1; i++)
            {
                if(text[i+1] == text[i])
                {
                    text = text.Remove(i + 1, 1);
                    i--;
                }
            }
            Console.WriteLine(text);
        }
    }
}
