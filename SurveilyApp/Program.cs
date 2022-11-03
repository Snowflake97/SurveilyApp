using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveilyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // stdin TODO

            var url1 = "https://pokeapi.co/api/v2/pokemon/ditto";
            var url2 = "https://pokeapi.co/api/v2/pokemon-species/aegislash";
            var url3 = "https://pokeapi.co/api/v2/type/3";
            var url4 = "https://pokeapi.co/api/v2/pokemon/pikachu";

            var test_url = url1 + ";" + url2 + ";" + url3 + ";" + url4;

            // Parse input
            var urlParser = new UrlParser(test_url);

            // Url list
            List<string> urls = urlParser.ParseUrl();

            foreach (var url in urls)
            {
                // Create threads? - thread per url
                var urlFetcher = new UrlFetcher(url);
                var fileName = url.Split("/").Last();
                var fomatedJson = urlFetcher.FetchJsonFromUrl();
                var fileSaver = new FileSaver(fileName);
                fileSaver.SaveToFile(fomatedJson);
            }
        }
    }
}