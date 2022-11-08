using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("link", "http://link/")]
    [TestFixture("http://link/", "http://link/")]
    [TestFixture("link 2", null)]
    [TestFixture(null, null)]
    [TestFixture("", null)]
    public class UrlParser_BuildUriTest
    {
        private readonly string _userInput;
        private readonly string _expectedUrl;

        public UrlParser_BuildUriTest(string userInput, string expectedUrl)
        {
            _userInput = userInput;
            _expectedUrl = expectedUrl;
        }

        [Test]
        public void BuildUriTest()
        {
            var methodResult = UrlParser.BuildUri(_userInput);
            Assert.AreEqual(_expectedUrl, methodResult);
        }
    }
}