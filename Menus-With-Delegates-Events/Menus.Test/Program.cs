using System;
using System.Collections.Generic;
using System.Text;
using Menus.interfaces;

namespace Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
          // MainMenu mainMenu = new MainMenu("Main Menu");
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
            mainMenu.AddSubMenu(versionAndCountSpacesMenu);
            mainMenu.AddSubMenu(dateTimeMenu);
            mainMenu.Show();
           

        }
        
    }
}
