using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Menus.Delegates
{
    public delegate void SelectedEventHandler(object sender);

    public abstract class MenuItem
    {
        private readonly string r_Title;

        public event SelectedEventHandler SelectedMenuItem;

        protected MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        internal abstract void DoWhenSelected(object i_Object);

        protected virtual void OnSelected(object sender)
        {
            if (SelectedMenuItem != null)
            {
                SelectedMenuItem.Invoke(sender);
            }
        }

        internal string Title
        {
            get { return r_Title; }
        }
    }
}