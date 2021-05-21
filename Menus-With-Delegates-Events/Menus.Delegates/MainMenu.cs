using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class MainMenu
    {
        public ButtonShowDate showDate;
        public ButtonCountSpaces countSpaces;
        private SubMenu m_subMenu;


        public MainMenu(SubMenu i_SubMainMenu)
        {
            m_subMenu = i_SubMainMenu;

            //showDate = new ButtonShowDate();
            //showDate.Selected += new MenuItem.SelectedEventHandler(showDate.ActivateFunction);
            //countSpaces = new ButtonCountSpaces();
            //countSpaces.Selected += new MenuItem.SelectedEventHandler(countSpaces.ActivateFunction);

            foreach (MenuItem menuItem in m_subMenu.MenuItems as MenuItem)
            {
                m_subMenu.Selected += new MenuItem.SelectedEventHandler(menuItem.ActivateFunction);
            }
        }




        
        public void AddSubMenu(MenuItem i_Item)
        {
            m_subMenu.AddSubMenuItem(i_Item);
        }

        public void Show()
        {
            m_subMenu.ActivateFunction();
        }
        
    }
}