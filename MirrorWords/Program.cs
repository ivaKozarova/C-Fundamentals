using System;
using System.Text;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int countWords = 0;
            StringBuilder sb = new StringBuilder();
            string takeWordOne = "";
            string takeWordTwo = "";

            foreach (var letter in text)
            {
                int index = text.IndexOf('#');
                if(index != -1)
                {
                    for (int i = index; i < length; i++)
                    {

                    }
                }
            }
        }
    }
}
