using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<bool> IsUrlExists()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Only head request
                    var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, Url));

                    if (response.IsSuccessStatusCode)
                    {
                        // Url exists
                        return true;
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
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