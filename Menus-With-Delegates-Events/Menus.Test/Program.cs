using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using Menus.Delegates;
using Menus.interfaces;
using MainMenu = Menus.interfaces.MainMenu;
using SubMenu = Menus.interfaces.SubMenu;

namespace Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InterfaceMenu();
            DelegateMenu();
        }

        public static void InterfaceMenu()
        {
            MainMenu mainMenu = new MainMenu();
            SubMenu dateTimeMenu = new SubMenu("Show Date/Time");
            SubMenu versionAndCountSpacesMenu = new SubMenu("Version and Spaces");
            ShowTime showTime = new ShowTime();
            ShowDate showDate = new ShowDate();
            CountSpaces countSpaces = new CountSpaces();
            ShowVersion showVersion = new ShowVersion();

            versionAndCountSpacesMenu.AddSubMenuItem(showVersion);
            versionAndCountSpacesMenu.AddSubMenuItem(countSpaces);
            dateTimeMenu.AddSubMenuItem(showDate);
            dateTimeMenu.AddSubMenuItem(showTime);
            mainMenu.AddSubMenu(versionAndCountSpacesMenu);
            mainMenu.AddSubMenu(dateTimeMenu);
            mainMenu.Show();
        }

        public static void DelegateMenu()
        {
            Menus.Delegates.MainMenu delegatesMain = new Menus.Delegates.MainMenu();
            Menus.Delegates.ButtonSubMenu dateTimeMenu = new Menus.Delegates.ButtonSubMenu("Show Date/Time");
            Menus.Delegates.ButtonSubMenu versionAndCountSpacesMenu = new Menus.Delegates.ButtonSubMenu("Version and Spaces");
            Menus.Delegates.ButtonShowTime showTime = new Menus.Delegates.ButtonShowTime();
            Menus.Delegates.ButtonShowDate showDate = new Menus.Delegates.ButtonShowDate();
            Menus.Delegates.ButtonCountSpaces countSpaces = new Menus.Delegates.ButtonCountSpaces();
            Menus.Delegates.ButtonShowVersion showVersion = new Menus.Delegates.ButtonShowVersion();

            versionAndCountSpacesMenu.AddSubMenuItem(showVersion);
            versionAndCountSpacesMenu.AddSubMenuItem(countSpaces);
            dateTimeMenu.AddSubMenuItem(showDate);
            dateTimeMenu.AddSubMenuItem(showTime);
            delegatesMain.AddSubMenu(versionAndCountSpacesMenu);
            delegatesMain.AddSubMenu(dateTimeMenu);
            delegatesMain.Show();
        }
    }
}
