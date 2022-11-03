using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveilyApp
{
    public class UrlParser
    {
        public string Url { get; }

        public UrlParser(string url)
        {
            Url = url;
        }

        public override string ToString()
        {
            return Url;
        }

        public List<string> ParseUrl()
        {
            return Url.Split(';').ToList();
        }
    }
}