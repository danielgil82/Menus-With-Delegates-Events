using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class ShowTime : MenuItem, IActionItem
    {
        private const string k_Title = "ShowTime";

        public ShowTime(): base(k_Title)
        {
        }

        void IActionItem.Activate()
        {
            Console.WriteLine("The time now is {0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
        }
    }
}