using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("https://pokeapi.co/api/v2/pokemon/1", true)]
    [TestFixture("https://pokeapi.co/api/v2/pokemon/2/", true)]
    [TestFixture("https://www.google.com", true)]
    [TestFixture("http://www.google.com", true)]
    [TestFixture("www.google.com", true)]
    [TestFixture("google.com", true)]
    [TestFixture("somerandomstring", false)]
    public class UrlFetcher_IsUrlExistsTest
    {
        private readonly UrlFetcher _urlFetcher;
        private readonly bool _expectedResult;

        public UrlFetcher_IsUrlExistsTest(string testInput, bool expectedResult)
        {
            _urlFetcher = new UrlFetcher(testInput);
            _expectedResult = expectedResult;
        }

        [Test]
        public void IsUrlExistsTest()
        {
            var methodResult = _urlFetcher.IsUrlExists().Result;
            Assert.AreEqual(_expectedResult, methodResult);
        }
    }
}