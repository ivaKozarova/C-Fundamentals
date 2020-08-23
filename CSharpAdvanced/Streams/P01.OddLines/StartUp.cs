using System;
using System.Diagnostics.Tracing;
using System.IO;

namespace P01.OddLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("input.txt", FileMode.Open);
            
            
            using (fileStream)
            {
                StreamReader streamReader = new StreamReader(fileStream);
                
                StreamWriter streamWriter = new StreamWriter("output.txt");
                using(streamWriter)
                { 
                    var counter  = 0;
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        if (counter % 2 == 1)
                        {
                            streamWriter.WriteLine(line);
                        }
                        counter++;
                    }
                }
              

            }

        }
    }
}
