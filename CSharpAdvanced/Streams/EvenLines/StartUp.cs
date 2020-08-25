using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("text.txt"))
            {
                
                int cnt = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if(cnt % 2 == 0 &&  line != null)
                    {
                        line = ReplaceSymbols(line);
                        line = Reverse(line);
                        
                        Console.WriteLine(line);
                    }
                    cnt++;
                }
            }
        }
        static string Reverse(string line)
        {
            var words = line.Split();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[words.Length - 1 - i]+ " ");
            }
            return sb.ToString().TrimEnd();
        }

        private static string ReplaceSymbols(string line)
        {
            char[] punctuationsmarks = { '-', ',', '.', '!', '?' };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                if (punctuationsmarks.Contains(line[i]))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(line[i]);
                }
            }
            return sb.ToString().TrimEnd();

        }
    }
}
