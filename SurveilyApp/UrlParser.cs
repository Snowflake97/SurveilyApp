using System;
using System.Collections.Generic;
using System.Linq;
using static System.String;

namespace SurveilyApp
{
    public class UrlParser
    {
        private string UserInput { get; set; }
        private List<string> UrlList { get; set; }

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
            UserInput = Concat(UserInput.Where(c => !char.IsWhiteSpace(c)));
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
            var temporaryUrlList = UrlList.Select(BuildUri).Where(uri => uri != null).ToList();

            UrlList = temporaryUrlList;
        }

        public static string BuildUri(string url)
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