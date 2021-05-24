using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Menus.interfaces;

namespace Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            //InterfaceMenu();
           //DelegateMenu();
        }

        public static void InterfaceMenu()
        {
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
            SubMenu menu = new SubMenu("Main Menu");
            MainMenu mainMenu = new MainMenu(menu);
            mainMenu.AddSubMenuToTheMainMenu(versionAndCountSpacesMenu);
            mainMenu.AddSubMenuToTheMainMenu(dateTimeMenu);
            mainMenu.Show();
        }

        //public static void DelegateMenu()
        //{
        //    Menus.Delegates.SubMenu subMainMenu = new Menus.Delegates.SubMenu("Main Menu");
        //    Menus.Delegates.MainMenu delegatesMain = new Menus.Delegates.MainMenu(subMainMenu);
        //    Menus.Delegates.SubMenu dateTimeMenu = new Menus.Delegates.SubMenu("Show Date/Time");
        //    Menus.Delegates.SubMenu versionAndCountSpacesMenu = new Menus.Delegates.SubMenu("Version and Spaces");
        //    Menus.Delegates.ButtonShowTime showTime = new Menus.Delegates.ButtonShowTime();
        //    Menus.Delegates.ButtonShowDate showDate = new Menus.Delegates.ButtonShowDate();
        //    Menus.Delegates.ButtonCountSpaces countSpaces = new Menus.Delegates.ButtonCountSpaces();
        //    Menus.Delegates.ButtonShowVersion showVersion = new Menus.Delegates.ButtonShowVersion();
        //    versionAndCountSpacesMenu.AddSubMenuItem(showVersion);
        //    versionAndCountSpacesMenu.AddSubMenuItem(countSpaces);
        //    dateTimeMenu.AddSubMenuItem(showDate);
        //    dateTimeMenu.AddSubMenuItem(showTime);
        //    delegatesMain.AddSubMenu(versionAndCountSpacesMenu);
        //    delegatesMain.AddSubMenu(dateTimeMenu);

        //    showTime.Selected as  += delegateTest.CollectionOfMethods_ShowTime;
        //    showDate.OperationChoosen += delegateTest.CollectionOfMethods_ShowDate;
        //    countDigits.OperationChoosen += delegateTest.CollectionOfMethods_CountDigits;
        //    showVersion.OperationChoosen += delegateTest.CollectionOfMethods_ShowVersion;

        //    delegatesMain.Show();
        //}
    }
}
