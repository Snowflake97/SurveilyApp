using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveilyApp
{
    public class UrlParser
    {
        public string UserInput { get; set; }
        public List<string> UrlList { get; set; }

        public UrlParser()
        {
        }

        public UrlParser(string userInput)
        {
            UserInput = userInput;
        }

        public override string ToString()
        {
            return UserInput;
        }

        public List<string> ParseUrl()
        {
            TrimWhiteSpaces();
            CreateUrlList();
            BuildUriList();
            RemoveDuplicatedElements();

            return UrlList;
        }

        private void TrimWhiteSpaces()
        {
            UserInput = String.Concat(UserInput.Where(c => !Char.IsWhiteSpace(c)));
        }

        private void CreateUrlList()
        {
            UrlList = UserInput.Split(';').ToList();
        }

        private void RemoveDuplicatedElements()
        {
            UrlList = UrlList.Distinct().ToList();
        }

        private void BuildUriList()
        {
            var temporaryUrlList = new List<string>();
            foreach (var url in UrlList)
            {
                var uri = BuildUri(url);
                if (uri != null)
                {
                    temporaryUrlList.Add(uri);
                }
            }

            UrlList = temporaryUrlList;
        }

        public string BuildUri(string url)
        {
            try
            {
                return new UriBuilder(url).Uri.ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}