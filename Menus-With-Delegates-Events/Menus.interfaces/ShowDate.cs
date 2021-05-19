using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class ShowDate : MenuItem, IActionItem
    {
        private const string k_Title = "ShowDate";

        public ShowDate()
        {
            Title = k_Title;
        }

        void IActionItem.Activate()
        {
            Console.WriteLine("Today is {0}", DateTime.Now.Date);
        }
    }
}