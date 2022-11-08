using Newtonsoft.Json;

namespace SurveilyApp
{
    public class JsonDownloader
    {
        public string Url { get; }
        public UrlFetcher UrlFetcher;

        public JsonDownloader(string url)
        {
            Url = url;
            UrlFetcher = new UrlFetcher(url);
        }

        private static string TryFormatToJson(string fetchedContent)
        {
            try
            {
                var parsedJson = JsonConvert.DeserializeObject(fetchedContent);
                return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                return null;
            }
        }

        public string DownloadJson()
        {
            if (UrlFetcher.IsUrlExists().Result)
            {
                var fetchedContent = UrlFetcher.FetchContentFromUrl();
                var jsonContent = TryFormatToJson(fetchedContent);
                return jsonContent;
            }

            return null;
        }
    }
}