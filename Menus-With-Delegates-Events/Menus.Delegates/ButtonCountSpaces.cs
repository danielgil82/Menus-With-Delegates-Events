using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class ButtonCountSpaces : MenuItem
    {
        public class temp
        {
            private const string k_Title = "CountSpaces";

            public ButtonCountSpaces() : base(k_Title)
            {
            }

            internal override void DoWhenSelected(object i_Object)
            {
                this.SelectedMenuItem += new SelectedEventHandler(buttonCountSpaces_SelectedMenuItem);
                OnSelected(this);
                this.SelectedMenuItem -= new SelectedEventHandler(buttonCountSpaces_SelectedMenuItem);
            }

            private void buttonCountSpaces_SelectedMenuItem(object i_Object)
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

                if (numberOfSpaces == 1)
                {
                    Console.WriteLine("There is {0} space in your sentence", numberOfSpaces);
                }
                else
                {
                    Console.WriteLine("There are {0} spaces in your sentence", numberOfSpaces);
                }
            }
        }
    }
}