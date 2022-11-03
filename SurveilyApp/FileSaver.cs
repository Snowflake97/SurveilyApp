using System;

namespace SurveilyApp
{
    public class FileSaver
    {
        private static readonly string _projectDirectory = System.IO.Directory
            .GetParent(System.IO.Directory
                .GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString())
            .ToString();

        private static readonly string _jsonResultsDirectory =
            System.IO.Path.Combine(_projectDirectory, "json_results");

        private static readonly string _jsonExtension = ".json";
        public string FileName { get; }

        public FileSaver(string fileName)
        {
            FileName = fileName;
        }

        public void SaveToFile(string formatedJson)
        {
            var filePath = System.IO.Path.Combine(_jsonResultsDirectory, FileName + _jsonExtension);
            System.IO.File.WriteAllText(filePath, formatedJson);
        }
    }
}