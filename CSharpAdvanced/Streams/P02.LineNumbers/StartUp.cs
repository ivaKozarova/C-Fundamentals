using System;
using System.IO;

namespace P02.LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("input.txt");
            using (streamReader)
            {
                string line; 
                int cnt = 1;
                StreamWriter streamWriter = new StreamWriter("output.txt");
                using (streamWriter)
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"{cnt}. {line}");
                        cnt++;
                        
                    
                }
            }
        }
    }
}
