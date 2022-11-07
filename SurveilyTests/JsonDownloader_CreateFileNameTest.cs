using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("https://pokeapi.co/api/v2/pokemon/1", "https_pokeapi_co_api_v2_pokemon_1")]
    [TestFixture("https://pokeapi.co/api/v2/pokemon/2/", "https_pokeapi_co_api_v2_pokemon_2")]
    [TestFixture("https://pokeapi.....co/api/v2/pokemon/2////////", "https_pokeapi_co_api_v2_pokemon_2")]
    [TestFixture("https://www.google.com", "https_www_google_com")]
    [TestFixture("http://www.google.com", "http_www_google_com")]
    [TestFixture("www.google.com", "www_google_com")]
    [TestFixture("google.com", "google_com")]
    [TestFixture("somerandomstring", "somerandomstring")]
    public class JsonDownloader_CreateFileNameTest
    {
        private readonly JsonDownloader _jsonDownloader;
        private readonly string _expectedResult;

        public JsonDownloader_CreateFileNameTest(string testInput, string expectedResult)
        {
            _jsonDownloader = new JsonDownloader(testInput);
            _expectedResult = expectedResult;
        }

        [Test]
        public void CreateFileNameTest()
        {
            var methodResult = _jsonDownloader.CreateFileName();
            Assert.AreEqual(_expectedResult, methodResult);
        }
    }
}