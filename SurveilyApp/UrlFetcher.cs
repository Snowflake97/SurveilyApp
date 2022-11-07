using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SurveilyApp
{
    public class UrlFetcher
    {
        public string Url { get; }
        public bool IsUrlValid { get; set; }

        public UrlFetcher(string url)
        {
            Url = url;
        }

        public UrlFetcher()
        {
        }

        public async Task<bool> IsUrlExists()
        {
            try
            {
                var tempUrl = new UriBuilder(Url).Uri.ToString();
                using var client = new HttpClient();
                // Only head request
                var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, tempUrl));

                if (response.IsSuccessStatusCode)
                {
                    // Url exists
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
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

        public string FetchContentFromUrl()
        {
            using var webClient = new System.Net.WebClient();
            if (IsUrlExists().Result)
            {
                IsUrlValid = true;
                try
                {
                    var fetchedContent = webClient.DownloadString(Url);
                    var jsonContent = TryFormatToJson(fetchedContent);
                    return jsonContent;
                }
                catch
                {
                    return null;
                }
            }

            IsUrlValid = false;
            return null;
        }
    }
}