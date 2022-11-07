using System;
using System.Collections.Generic;
using NUnit.Framework;
using SurveilyApp;

namespace SurveilyTests
{
    [TestFixture("https://pokeapi.co/api/v2/pokemon/1/;https://pokeapi.co/api/v2/pokemon/2",
        new[] { "https://pokeapi.co/api/v2/pokemon/1/", "https://pokeapi.co/api/v2/pokemon/2" })]
    [TestFixture("www.google.com;http://www.google.com", new[] { "http://www.google.com/" })]
    [TestFixture("https://pokeapi.co/api/v2/pokemon/1/;https://pokeapi.co/api/v2/pokemon/1/",
        new[] { "https://pokeapi.co/api/v2/pokemon/1/" })]
    [TestFixture(";;;;;", null)]
    [TestFixture("link", new[] { "http://link/" })]
    [TestFixture(";;;;;;;link;;;;;link2;link3", new[] { "http://link/", "http://link2/", "http://link3/" })]
    public class UrlParser_ParseUrlTest
    {
        private readonly UrlParser _urlParser;
        private readonly string _userInput;
        private List<string> _expectedUrlsList;

        public UrlParser_ParseUrlTest(string userInput, string[] urls)
        {
            _userInput = userInput;
            _urlParser = new UrlParser(_userInput);
            _expectedUrlsList = new List<string>();
            if (urls != null)
            {
                foreach (var url in urls)
                {
                    _expectedUrlsList.Add(url);
                }
            }
        }

        [Test]
        public void ParseUrlTest()
        {
            var methodResult = _urlParser.ParseUrl();
            Console.WriteLine(methodResult);
            Console.WriteLine(_expectedUrlsList);
            Console.WriteLine();
            Assert.AreEqual(_expectedUrlsList, methodResult);
        }
    }
}