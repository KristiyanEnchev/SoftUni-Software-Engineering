using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Compression;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            using ZipArchive zipFile = ZipFile.Open("zipfile.zip", ZipArchiveMode.Create);
            ZipArchiveEntry zipArchiveEntry = zipFile.CreateEntryFromFile("copyMe.png", "copyMeOutput.png");
        }
    }
}
