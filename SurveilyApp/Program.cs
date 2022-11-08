using System.Threading.Tasks;

namespace SurveilyApp
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            await new TaskExecutor().DownloadContentFromAllUrls();
        }
    }
}