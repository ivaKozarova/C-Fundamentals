using System;
using System.IO;
using System.Linq;

namespace P02.LineNumbers_HW
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] outputLines = new string[lines.Length];           
            //using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            //{
                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];
                    int countLetter = CountOfLetter(line);
                    int countPunctuations = CountOfPuncMarks(line);

                    string result = $"Line {i + 1}:{line}({countLetter})({countPunctuations})";

                
                outputLines[i] = result;
                   
                }
            File.WriteAllLines("../../../outputLines.txt", outputLines);
            //}

            
        }

        static int CountOfLetter(string line)
        {
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
         static int CountOfPuncMarks(string line)
        {
            int countOfPuncMarks = 0;
            var punctuations = new char[] { '-', ',', '.', '!', '?','\''};

            for (int i = 0; i < line.Length; i++)
            {
                if (punctuations.Contains(line[i]))
                {
                    countOfPuncMarks++;
                }
            }
            return countOfPuncMarks;
        }
    }
}
