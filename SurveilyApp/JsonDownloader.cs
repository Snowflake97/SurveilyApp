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
            var fetchedContent = UrlFetcher.FetchContentFromUrl();
            if (UrlFetcher.IsUrlValid)
            {
                if (fetchedContent != null)
                {
                    FileSaver.SaveToFile(fetchedContent);
                    Console.WriteLine("Url " + Url + " is valid, results are saved in file " + FileName +
                                      FileSaver._jsonExtension);
                }
                else
                {
                    Console.WriteLine("Url " + Url + " is valid but not json response was retrieved - skipping");
                }
            }
            else
            {
                Console.WriteLine("Url " + Url + " is not valid url - skipping");
            }
        }
    }
}