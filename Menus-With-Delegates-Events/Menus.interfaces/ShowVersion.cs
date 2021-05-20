using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class ShowVersion : MenuItem, IActionItem
    {
        private const string k_Title = "ShowVersion";
        
        public ShowVersion(): base(k_Title)
        {
        }

        void IActionItem.Activate()
        {
            Console.WriteLine("Version: 21.1.4.8930");
        }
    }
}