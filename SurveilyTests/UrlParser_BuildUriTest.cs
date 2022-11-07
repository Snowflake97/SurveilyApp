using System;
using System.Collections.Generic;
using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("link", "http://link/")]
    // more TODO
    public class UrlParser_BuildUriTest
    {
        private readonly UrlParser _urlParser;
        private readonly string _userInput;
        private readonly string _expectedUrl;

        public UrlParser_BuildUriTest(string userInput, string expectedUrl)
        {
            _userInput = userInput;
            _urlParser = new UrlParser(_userInput);
            _expectedUrl = expectedUrl;
        }

        [Test]
        public void BuildUriTest()
        {
            var methodResult = _urlParser.BuildUri(_userInput);
            Console.WriteLine(methodResult);
            Console.WriteLine(_expectedUrl);
            Console.WriteLine();
            Assert.AreEqual(_expectedUrl, methodResult);
        }
    }
}