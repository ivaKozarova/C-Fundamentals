using System;
using System.IO;
using System.Net.Http;

namespace P04.MergeFiles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter("output.txt");
            using (streamWriter)
            {
                StreamReader streamReader = new StreamReader("fileOne.txt");
                using (streamReader)
                {
                    var line = streamReader.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine(line);
                        line = streamReader.ReadLine();
                    }
                }
                StreamReader streamReader2 = new StreamReader("fileTwo.txt");
                using (streamReader2)
                {
                    var line = streamReader2.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine(line);
                        line = streamReader2.ReadLine();
                    }
                }
            }
        }
    }
}
    
