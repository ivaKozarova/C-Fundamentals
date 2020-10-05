using System;
using System.IO.Compression;

namespace P06.ZipAndExtract
{
    class ZipAndExtract
    {
        static void Main(string[] args)
        { 

            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
        
            ZipFile.CreateFromDirectory("../../../CopyMe", $"{path}\\zippedCopyMe.zip");

           ZipFile.ExtractToDirectory($"{path}\\zippedCopyMe.zip", "../../../CopyMe2");

        }
    }
}
