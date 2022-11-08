using System;
using System.IO;
using System.Linq;

namespace SurveilyApp
{
    public class FileSaver
    {
        private const string JsonExtension = ".json";
        private static readonly string CurrentDirectory = Directory.GetParent(Environment.CurrentDirectory)?.ToString();
        public string Url { get; set; }
        private string FileName { get; }
        public string DirectoryPath { get; set; }
        public string PathToFile { get; set; }
        private string FileContent { get; }

        public FileSaver()
        {
        }

        public FileSaver(string url, string directoryPath, string fileContent)
        {
            Url = url;
            FileContent = fileContent;
            FileName = CreateFileName();
            DirectoryPath = directoryPath;
            CreateDirectory();
            MakePathToFile();
        }

        private void MakePathToFile()
        {
            if (!string.IsNullOrEmpty(DirectoryPath))
            {
                PathToFile = Path.Combine(DirectoryPath, FileName + JsonExtension);
            }
            else
            {
                PathToFile = Path.Combine(CurrentDirectory, FileName + JsonExtension);
            }
        }

        public string CreateFileName()
        {
            var splitedString = Url.Split(new char[] { ':', '.', '/' });
            splitedString = splitedString.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var fileName = string.Join("_", splitedString);
            return fileName;
        }

        public bool IsFileExists()
        {
            return File.Exists(PathToFile);
        }

        public bool IsDirectoryExits()
        {
            return Directory.Exists(DirectoryPath);
        }


        public void CreateDirectory()
        {
            if (!string.IsNullOrEmpty(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            else
            {
                DirectoryPath = CurrentDirectory;
            }
        }

        public void SaveToFile()
        {
            if (!string.IsNullOrEmpty(PathToFile) && IsDirectoryExits())
            {
                if (IsFileExists() == false)
                {
                    File.WriteAllText(PathToFile, FileContent);
                    Console.WriteLine("[" + Url + "] - json content saved under " + PathToFile);
                }
                else
                {
                    Console.WriteLine("[" + Url + "] - " + FileName + " already exists under " + DirectoryPath +
                                      " - skipping");
                }
            }
            else
            {
                Console.WriteLine("[" + Url + "] - Provided directory is invalid, files won't be saved - skipping");
            }
        }
    }
}