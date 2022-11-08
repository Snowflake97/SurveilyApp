using System;
using System.IO;
using System.Linq;

namespace SurveilyApp
{
    public class FileSaver
    {
        public static readonly string _jsonExtension = ".json";
        public string Url { get; }
        public string FileName { get; }
        public string AbsoluteDirectoryPath { get; }
        public string AbsolutePathToFile { get; }
        public string FileContent { get; }

        public FileSaver(string url, string absoluteDirectoryPath, string fileContent)
        {
            Url = url;
            FileContent = fileContent;
            FileName = CreateFileName();
            AbsoluteDirectoryPath = absoluteDirectoryPath;
            CreateDirectory(AbsoluteDirectoryPath);
            AbsolutePathToFile = Path.Combine(AbsoluteDirectoryPath, FileName + _jsonExtension);
        }

        public string CreateFileName()
        {
            var splittedString = Url.Split(new char[] { ':', '.', '/' });
            splittedString = splittedString.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var fileName = string.Join("_", splittedString);
            return fileName;
        }

        public bool IsFileExists()
        {
            if (File.Exists(AbsolutePathToFile))
            {
                return true;
            }

            return false;
        }

        public bool IsDirectryExits()
        {
            if (Directory.Exists(AbsoluteDirectoryPath))
            {
                return true;
            }

            return false;
        }


        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void SaveToFile()
        {
            if (IsDirectryExits())
            {
                if (IsFileExists() == false)
                {
                    File.WriteAllText(AbsolutePathToFile, FileContent);
                    Console.WriteLine("[" + Url + "] - json content saved under " + FileName);
                }
                else
                {
                    Console.WriteLine("[" + Url + "] - " + FileName + " already exists - skipping");
                }
            }
            else
            {
                Console.WriteLine("[" + Url + "] - Provided directory is invalid, files won't be saved - skipping");
            }
        }
    }
}