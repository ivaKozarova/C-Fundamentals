using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"Note.txt");
            using (reader)
            {
                int count = 0;
                string currentLine;
                using (var writer = new StreamWriter("Output.txt"))
                {
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (count % 2 == 1)
                        {
                            writer.WriteLine(currentLine);
                        }
                        count++;
                    }
                }
            }
            using (var readerTwo = new StreamReader("Output.txt"))
            {
                string line;
                while ((line = readerTwo.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine(new string('*', 80));
            using (var newReader = new StreamReader(@"Note.txt"))
            {
                var len = newReader.ReadToEnd();
                Console.WriteLine(len);
            }
            using (var readerThree = new StreamReader("Note.txt"))
            {
                int numerator = 1;
                using (var writer = new StreamWriter("OutputWithNums.txt"))
                {
                    var line = readerThree.ReadLine();
                    while (line != null)
                    {
                        line = $"{numerator}. {line}";
                        writer.WriteLine(line);
                        numerator++;
                       line = readerThree.ReadLine();
                    }
                }
            }
            
        }
    }
}
