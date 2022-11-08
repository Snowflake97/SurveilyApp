using System;
using System.Linq;

namespace SurveilyApp
{
    public class InputHandler
    {
        private string Input { get; set; }

        public string GetUserInput(string dialogMessage)
        {
            Console.WriteLine(dialogMessage + ": ");
            Input = TrimInput(Console.ReadLine());
            return Input;
        }

        public string TrimInput(string userInput)
        {
            return String.Concat(userInput.Where(c => !Char.IsWhiteSpace(c)));
        }
    }
}