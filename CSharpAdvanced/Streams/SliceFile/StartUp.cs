using System;
using System.IO;

namespace SliceFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("SliceMe.txt", FileMode.Open);
            int parts = 4;
                      
            using (fileStream)
            {
                var length = (long)(Math.Ceiling((double)fileStream.Length / parts));
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    using (var createFile = new FileStream($"Part-{i+1}.txt", FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while(fileStream.Read(buffer, 0 , buffer.Length) == buffer.Length)
                        {
                            createFile.Write(buffer, 0, buffer.Length);
                            currentPieceSize += buffer.Length;
                            if(currentPieceSize >= length)
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
