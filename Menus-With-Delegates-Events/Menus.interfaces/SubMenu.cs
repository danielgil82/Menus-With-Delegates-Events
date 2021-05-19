using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class SubMenu : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems;
        
        public SubMenu(string i_Title)
        {
            Title = i_Title;
            r_MenuItems = new List<MenuItem>();
        }
    }
}