using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("https://pokeapi.co/api/v2/pokemon/1", true)]
    [TestFixture("https://pokeapi.co/api/v2/pokemon/2/", true)]
    [TestFixture("https://www.google.com", false)]
    [TestFixture("http://www.google.com", false)]
    [TestFixture("www.google.com", false)]
    [TestFixture("google.com", false)]
    [TestFixture("somerandomstring", false)]
    public class JsonDownloader_DownloadJsonTest

    {
        private readonly JsonDownloader _jsonDownloader;
        private readonly bool _expectedResult;

        public JsonDownloader_DownloadJsonTest(string testInput, bool expectedResult)
        {
            _jsonDownloader = new JsonDownloader(testInput);
            _expectedResult = expectedResult;
        }

        [Test]
        public void DownloadJsonTest()
        {
            var jsonContent = _jsonDownloader.DownloadJson();
            if (_expectedResult)
            {
                Assert.That(string.IsNullOrEmpty(jsonContent), Is.False, "Result string must not be null");
            }
            else
            {
                Assert.That(string.IsNullOrEmpty(jsonContent), Is.True, "Result string must be null");
            }
        }
    }
}