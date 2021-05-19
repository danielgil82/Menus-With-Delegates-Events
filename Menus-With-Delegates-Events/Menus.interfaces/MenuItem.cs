using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public abstract class MenuItem
    {
        private string m_Title;

        public string Title
        {
            get { return m_Title; }

            set { m_Title = value; }
        }
    }
}