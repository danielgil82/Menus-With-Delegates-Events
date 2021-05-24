using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class MainMenu
    {
        private const string k_MainTitle = "Main Menu";
        private const byte k_FirstLevel = 0;
        private SubMenu m_MainMenu;

        public MainMenu()
        {
            m_MainMenu = new SubMenu(k_MainTitle);
        }

        public void Show()
        {
            m_MainMenu.ShowSubMenu(m_MainMenu.Title, k_FirstLevel);
        }

        public void AddSubMenu(MenuItem i_Item)
        {
            m_MainMenu.AddSubMenuItem(i_Item);
        }
    }
}