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
    public class UrlFetcher_FetchContentFromUrl

    {
        private readonly UrlFetcher _urlFetcher;
        private readonly bool _expectedResult;

        public UrlFetcher_FetchContentFromUrl(string testInput, bool expectedResult)
        {
            _urlFetcher = new UrlFetcher(testInput);
            _expectedResult = expectedResult;
        }

        [Test]
        public void FetchContentFromUrlTest()
        {
            var jsonContent = _urlFetcher.FetchContentFromUrl();
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