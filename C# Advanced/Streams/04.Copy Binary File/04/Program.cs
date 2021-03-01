using System;
using System.IO;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream readFile = new FileStream("copyMe.png", FileMode.Open);
            using FileStream writeStream = new FileStream("newImage.png", FileMode.Create);


            while (readFile.Position < readFile.Length)
            {
                byte[] buffer = new byte[4096];
                int count = readFile.Read(buffer, 0, buffer.Length);


                writeStream.Write(buffer);
            }

        }
    }
}
