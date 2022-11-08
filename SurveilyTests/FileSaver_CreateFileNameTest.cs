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
    public class FileSaver_CreateFileNameTest
    {
        private readonly FileSaver _fileSaver;
        private readonly string _expectedResult;

        public FileSaver_CreateFileNameTest(string testInput, string expectedResult)
        {
            _fileSaver = new FileSaver(testInput, "null","null");
            _expectedResult = expectedResult;
        }

        [Test]
        public void CreateFileNameTest()
        {
            var methodResult = _fileSaver.CreateFileName();
            Assert.AreEqual(_expectedResult, methodResult);
        }
    }
}