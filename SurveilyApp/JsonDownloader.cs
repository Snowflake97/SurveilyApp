using System;
using System.Linq;

namespace SurveilyApp
{
    public class JsonDownloader
    {
        public string Url { get; }
        public string FileName { get; }
        public UrlFetcher UrlFetcher;
        public FileSaver FileSaver;

        public JsonDownloader(string url)
        {
            Url = url;
            UrlFetcher = new UrlFetcher(url);
            FileName = Url.Split("/").Last(); // TODO function, logic, empty names, existed names etc
            FileSaver = new FileSaver(FileName);
        }

        public void DownloadJson()
        {
            var isUrlValid = UrlFetcher.IsUrlExists().Result;
            if (isUrlValid)
            {
                var fomatedJson = UrlFetcher.FetchJsonFromUrl();
                FileSaver.SaveToFile(fomatedJson);
                Console.WriteLine("Url " + Url + " is valid, results are saved in file " + FileName);
            }
            else
            {
                Console.WriteLine("Url " + Url + " is no valid url - skipping");
            }
        }
    }
}