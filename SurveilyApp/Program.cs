using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SurveilyApp
{
    public static class Program
    {
        private static void IterVersion(List<string> urls)
        {
            Console.WriteLine("\n\nIter version:");
            var sw = Stopwatch.StartNew();
            foreach (var url in urls)
            {
                var jsonDownlander = new JsonDownloader(url);
                jsonDownlander.DownloadJson();
            }

            sw.Stop();
            Console.WriteLine("Iter version done - Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
        }

        private static async Task TaskVersion(List<string> urls)
        {
            Console.WriteLine("Task version:");
            var sw = Stopwatch.StartNew();
            var tasks = new List<Task>();
            foreach (var url in urls)
            {
                tasks.Add(Task.Run(() => new JsonDownloader(url).DownloadJson()));
            }

            await Task.WhenAll(tasks);
            sw.Stop();
            Console.WriteLine("Task version done - Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
        }

        private static async Task Main(string[] args)
        {
            // stdin TODO

            var urlList = new List<string>
            {
                "https://pokeapi.co/api/v2/pokemon/ditto",
                "https://pokeapi.co/api/v2/pokemon-species/aegislash",
                // "https://pokeapi.co/api/v2/type/3", //doubled json name
                "pokeapi.co/api/v2/pokemon/pikachu",
                "https://pokeapi.co/api/v2/pokemon/1",
                "https://pokeapi.co/api/v2/pokemon/2",
                "https://pokeapi.co/api/v2/pokemon/3",
                "https://pokeapi.co/api/v2/pokemon/4",
                "https://pokeapi.co/api/v2/pokemon/5",
                "https://pokeapi.co/api/v2/pokemon/6",
                "https://pokeapi.co/api/v2/pokemon/7",
                "https://pokeapi.co/api/v2/pokemon/8",
                "https://pokeapi.co/api/v2/pokemon/9",
                "https://pokeapi.co/api/v2/pokemon/10",
                "https://pokeapi.co/api/v2/pokemon/11",
            };
            // Simulated user input
            var testUrl = string.Join(";", urlList);

            // Parse input
            var urlParser = new UrlParser(testUrl);

            // Url list
            var urls = urlParser.ParseUrl();

            // Do iter version
            IterVersion(urls);

            // Do task version
            await TaskVersion(urls);
        }
    }
}