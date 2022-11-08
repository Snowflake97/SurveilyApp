using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveilyApp
{
    public class TaskExecutor
    {
        public List<string> UrlList { get; }
        public List<Task> TaskList { get; }

        public string DirectoryPath { get; }
        public string UserUrlsInput { get; }

        public TaskExecutor()
        {
            var inputHandler = new InputHandler();
            UserUrlsInput = inputHandler.GetUserInput("Please enter urls (; is the delimiter)");
            DirectoryPath =
                inputHandler.GetUserInput(
                    "Please enter path to directory where results should be stored (absolute path)");
            TaskList = new List<Task>();
            UrlList = new UrlParser(UserUrlsInput).ParseUrl();
        }

        public void PerformUrlJsonDownloadAndSave(string url)
        {
            var jsonContent = new JsonDownloader(url).DownloadJson();
            if (jsonContent != null)
            {
                var fileSaver = new FileSaver(url, DirectoryPath, jsonContent);
                fileSaver.SaveToFile();
            }
            else
            {
                Console.WriteLine("[" + url + "] - no json content fetched");
            }
        }

        public async Task DownloadContentFromAllUrls()
        {
            foreach (var url in UrlList)
            {
                TaskList.Add(Task.Run(() => PerformUrlJsonDownloadAndSave(url)));
            }

            await Task.WhenAll(TaskList);
        }
    }
}