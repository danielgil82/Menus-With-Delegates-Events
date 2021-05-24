using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class ShowDate : MenuItem, IActionItem
    {
        private const string k_Title = "ShowDate";

        public ShowDate() : base(k_Title)
        {
        }

        void IActionItem.Activate()
        {
            Console.WriteLine("The date is {0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }
    }
}