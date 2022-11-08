using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveilyApp
{
    public class TaskExecutor
    {
        private List<string> UrlList { get; }
        private List<Task> TaskList { get; }

        private string DirectoryPath { get; }
        private string UserUrlsInput { get; }

        public TaskExecutor()
        {
            var inputHandler = new InputHandler();
            UserUrlsInput = inputHandler.GetUserInput("Please enter urls (; is the delimiter)");
            DirectoryPath =
                inputHandler.GetUserInput(
                    "Please enter path to directory where results should be stored");
            TaskList = new List<Task>();
            UrlList = new UrlParser(UserUrlsInput).ParseUrl();
        }

        private void PerformUrlJsonDownloadAndSave(string url)
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
            if (UrlList.Count > 0)
            {
                foreach (var url in UrlList)
                {
                    TaskList.Add(Task.Run(() => PerformUrlJsonDownloadAndSave(url)));
                }

                await Task.WhenAll(TaskList);
            }
            else
            {
                Console.WriteLine("Nothing to do");
            }
        }
    }
}