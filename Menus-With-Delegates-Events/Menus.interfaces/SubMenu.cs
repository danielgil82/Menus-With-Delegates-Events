using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace Menus.interfaces
{
    public class SubMenu : MenuItem
    {
        private byte m_SubMenusCurrentLevel;
        private byte m_CurrentIdx = 1;
        private const byte k_BackOrExit = 0;
        private readonly Hashtable r_MenuItems;

        public SubMenu(string i_Title)
        {
            Title = i_Title;
            r_MenuItems = new Hashtable();
        }

        public void AddSubMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(m_CurrentIdx, i_MenuItem);
            m_CurrentIdx++;
        }

        public void printCurrentSubMenu()
        {
            Console.WriteLine("The current level is: {0}", m_SubMenusCurrentLevel);
            Console.WriteLine("=============================");

            //foreach (byte currentIndex in r_MenuItems.Keys)
            //{
            //    Console.WriteLine("{0}) {1}" ,currentIndex , (r_MenuItems[currentIndex] as MenuItem).Title);
            //}

            //for (int i = r_MenuItems.Count - 1 ; i > 0 ; i++)
            //{
            //    Console.WriteLine("{0}) {1}", r_MenuItems[i] , (r_MenuItems[i] as MenuItem).Title);
            //}
        }

    }
}