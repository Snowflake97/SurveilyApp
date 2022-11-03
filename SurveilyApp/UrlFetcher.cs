using System;
using Newtonsoft.Json; // TODO install trough NuGet (packages.config/PackageReference?)

namespace SurveilyApp
{
    public class UrlFetcher
    {
        public string Url { get; }

        public UrlFetcher(string url)
        {
            Url = url;
        }

        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }

        public string FetchJsonFromUrl()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(Url);
                return FormatJson(json);
            }
        }
    }
}