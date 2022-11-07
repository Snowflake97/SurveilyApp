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
            FileName = CreateFileName();
            FileSaver = new FileSaver(FileName);
        }

        public string CreateFileName()
        {
            var splitedString = Url.Split(new char[] { ':', '.', '/' });
            splitedString = splitedString.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var fileName = string.Join("_", splitedString);
            return fileName;
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