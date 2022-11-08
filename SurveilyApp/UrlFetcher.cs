using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SurveilyApp
{
    public class UrlFetcher
    {
        public string Url { get; }

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

        public string FetchContentFromUrl()
        {
            using var webClient = new System.Net.WebClient();
            if (IsUrlExists().Result)
            {
                try
                {
                    var fetchedContent = webClient.DownloadString(Url);
                    return fetchedContent;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }
    }
}