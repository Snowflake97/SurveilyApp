using System;

namespace SurveilyApp
{
    public class InputHandler
    {
        public string Input { get; set; }

        public InputHandler()
        {
        }

        public void GetUserInput()
        {
            Input = Console.ReadLine();
        }
    }
}