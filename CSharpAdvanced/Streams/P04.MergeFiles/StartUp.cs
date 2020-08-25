using System;
using System.IO;

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
                StreamReader streamReader2 = new StreamReader("fileTwo.txt");
                using (streamReader)
                {
                    using (streamReader2)
                    {
                        while (true)
                        {
                            var lineFromFirst = streamReader.ReadLine();
                            if (lineFromFirst != null)
                            {
                                streamWriter.WriteLine(lineFromFirst);
                            }
                            var lineFromSecond = streamReader2.ReadLine();
                            if (lineFromSecond != null)
                            {
                                streamWriter.WriteLine(lineFromSecond);
                            }
                            if(streamReader.EndOfStream && streamReader2.EndOfStream)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

