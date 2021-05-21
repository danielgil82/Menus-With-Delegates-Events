using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Menus.Delegates
{
    public abstract class MenuItem
    {
        
        
        private readonly string r_Title;

        public abstract void SelectedItem();

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public string Title
        {
            get { return r_Title; }
        }

      
    }
}