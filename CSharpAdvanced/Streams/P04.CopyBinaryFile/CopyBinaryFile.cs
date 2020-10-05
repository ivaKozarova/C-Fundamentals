using System.IO;

namespace P04.CopyBinaryFile
{
    class StartUp
    {
       static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../copyMe.jpg", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../copiedPic.jpg", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    while (reader.CanRead)
                    {
                        int byteRead = reader.Read(buffer, 0, buffer.Length);

                        if (byteRead == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
