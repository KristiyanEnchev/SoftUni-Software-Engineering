using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> fileData = new Dictionary<string, Dictionary<string, double>>();

            foreach (var item in fileNames)
            {
                FileInfo fileInfo = new FileInfo(item);
                string extension = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbsSize = Math.Round(size / 1024.0,3);

                if (!fileData.ContainsKey(extension))
                {
                    fileData.Add(extension, new Dictionary<string, double>());
                }

                fileData[extension].Add(fileInfo.Name, kbsSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedDic = fileData
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> res = new List<string>();

            foreach (var item in sortedDic)
            {
                res.Add(item.Key);

                foreach (var fileDat in item.Value.OrderBy(kvp => kvp.Value))
                {
                    res.Add($"--{fileDat.Key} - {fileDat.Value}kb");
                }
            }


            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            File.WriteAllLines(filePath, res );
        }
    }
}
