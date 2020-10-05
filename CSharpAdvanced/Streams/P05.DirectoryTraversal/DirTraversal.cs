using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDir = Console.ReadLine();

            var files = Directory.GetFiles(inputDir);
            var dicWithFiles = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                var ext = fileInfo.Extension;
                var name = fileInfo.Name;
                var size = fileInfo.Length / 1024;

                if(!dicWithFiles.ContainsKey(ext))
                {
                    dicWithFiles[ext] = new Dictionary<string, double>();
                }
                dicWithFiles[ext][name] = size;
            }

            dicWithFiles = dicWithFiles.OrderByDescending(x => x.Value.Count)
                .ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            
            string pathToDesktop = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";

            using (StreamWriter writer = new StreamWriter($"{pathToDesktop}\\report.txt"))
            {
                foreach (var kvp in dicWithFiles)
                {
                    writer.WriteLine(kvp.Key);
                    foreach (var (name, size) in kvp.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{name} - {size}kb");
                    }
                }
            }
         
        }
    }
}
