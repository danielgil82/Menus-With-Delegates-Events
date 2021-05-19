using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class CountSpaces : MenuItem, IActionItem
    {
        private const string k_Title = "CountSpaces";

        public CountSpaces()
        {
            Title = k_Title;
        }

        void IActionItem.Activate()
        {
            string usersSentence = string.Empty;
            uint numberOfSpaces = 0;

            Console.WriteLine("Please enter a sentence");
            usersSentence = Console.ReadLine();
            foreach (char character in usersSentence)
            {
                if (character == ' ')
                {
                    numberOfSpaces++;
                }
            }

            Console.WriteLine("There is {0} spaces in your sentence", numberOfSpaces);
        }
    }
}