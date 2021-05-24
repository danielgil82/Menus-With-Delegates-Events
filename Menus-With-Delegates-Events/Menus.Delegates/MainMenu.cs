using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class MainMenu
    {
        private const string k_MainTitle = "Main Menu";
        //private const byte k_FirstLevel = 0;
        private ButtonSubMenu m_ButtonSubMenu;

        public MainMenu()
        {
            m_ButtonSubMenu = new ButtonSubMenu(k_MainTitle);
        }

        public void AddSubMenu(MenuItem i_Item)
        {
            m_ButtonSubMenu.AddSubMenuItem(i_Item);
        }

        public void Show()
        {
            m_ButtonSubMenu.ShowSubMenu(m_ButtonSubMenu);
        }
    }
}