using System.Threading.Tasks;

namespace SurveilyApp
{
    public class Program
    {
        private static async Task Main()
        {
            await new TaskExecutor().DownloadContentFromAllUrls();
        }
    }
}