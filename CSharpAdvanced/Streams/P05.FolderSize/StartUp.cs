using System;
using System.IO;

namespace P05.FolderSize
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\TestFolder";
            var files = Directory.GetFiles(path);
            double size = 0;
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                size += fileInfo.Length;
            }
            size = size / 1024 / 1024;

            using var writer = new StreamWriter("Result.txt");
            var dir = new DirectoryInfo(path);
            string dirName = dir.Name;
            writer.WriteLine($"{dirName} : {size} MB");
            writer.Flush();
        }

    }
}
