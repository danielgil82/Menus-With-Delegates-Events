using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public abstract class MenuItem
    {
        private readonly string r_Title;

        public string Title
        {
            get { return r_Title; }
        }

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }
    }
}