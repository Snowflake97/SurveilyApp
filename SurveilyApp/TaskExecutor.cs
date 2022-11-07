using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SurveilyApp
{
    public class TaskExecutor
    {
        public TaskExecutor()
        {
        }

        public async Task PerformTaskJsonDownloader()
        {
            var testUrl = "pokeapi.co/api/v2/pokemon/1;https://pokeapi.co/api/v2/pokemon/2";
            //user input
            var urls = new UrlParser(testUrl).ParseUrl();
            // TODO if urls list len > 0 
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
    }
}