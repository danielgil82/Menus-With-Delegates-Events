using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.interfaces
{
    public class MainMenu
    {
        private SubMenu m_MainMenu;

        public MainMenu(SubMenu i_SubMainMenu)
        {
            m_MainMenu = i_SubMainMenu;
        }

        public void Show()
        {
            m_MainMenu.ShowSubMenu(m_MainMenu.Title);
        }

        public void AddSubMenu(MenuItem i_Item)
        {
            m_MainMenu.AddSubMenuItem(i_Item);
        }

    }
}