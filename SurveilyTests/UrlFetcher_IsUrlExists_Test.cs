using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("https://pokeapi.co/api/v2/pokemon/1", true, true)]
    [TestFixture("https://pokeapi.co/api/v2/pokemon/2/", true, true)]
    [TestFixture("https://www.google.com", true, false)]
    [TestFixture("http://www.google.com", true, false)]
    [TestFixture("www.google.com", true, false)]
    [TestFixture("google.com", true, false)]
    [TestFixture("somerandomstring", false, false)]
    public class UrlFetcherIsUrlExistsTest
    {
        private readonly UrlFetcher _urlFetcher;
        private readonly bool _isValidUrl;
        private readonly bool _isJsonShouldBeRetrieved;

        public UrlFetcherIsUrlExistsTest(string url, bool isValidUrl, bool isJsonShouldBeRetrieved)
        {
            _urlFetcher = new UrlFetcher(url);
            _isValidUrl = isValidUrl;
            _isJsonShouldBeRetrieved = isJsonShouldBeRetrieved;
        }

        [Test]
        public void UrlFetcherIsUrlExists()
        {
            var methodResult = _urlFetcher.IsUrlExists().Result;
            Assert.AreEqual(_isValidUrl, methodResult);
        }

        [Test]
        public void UrlFetcherIsJsonRetrieved()
        {
            var jsonContent = _urlFetcher.FetchContentFromUrl();
            if (_isJsonShouldBeRetrieved)
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