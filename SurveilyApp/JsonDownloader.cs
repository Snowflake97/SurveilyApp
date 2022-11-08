using Newtonsoft.Json;

namespace SurveilyApp
{
    public class JsonDownloader
    {
        private readonly UrlFetcher _urlFetcher;

        public JsonDownloader(string url)
        {
            _urlFetcher = new UrlFetcher(url);
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
            if (_urlFetcher.IsUrlExists().Result)
            {
                var fetchedContent = _urlFetcher.FetchContentFromUrl();
                var jsonContent = TryFormatToJson(fetchedContent);
                return jsonContent;
            }

            return null;
        }
    }
}