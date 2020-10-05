using System;
using System.IO;
using System.Linq;

namespace P01.EvenLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                int counter = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (counter % 2 == 0)
                    {
                        line = Reverse(line);
                        line = ReplaceSpecialSymbols(line);
                        Console.WriteLine(line);

                    }
                    counter++;
                }
            }
        }

        public static string Reverse(string line)
        {
            var array = line.Split(' ').ToArray().Reverse();
            return String.Join(' ', array);
        }

        public static string ReplaceSpecialSymbols(string line)
        {
            var punctuations = new char[] { '-', ',', '.', '!', '?' };

            for (int i = 0; i < line.Length; i++)
            {
                if (punctuations.Contains(line[i]))
                {
                    line = line.Replace(line[i], '@');
                }
            }
            return line;
        }

    }
}
