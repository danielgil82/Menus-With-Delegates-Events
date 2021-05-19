using System;
using System.Collections.Generic;
using System.Text;
using Menus.interfaces;

namespace Menus.Test
{
    public class Program
    {
        private const int k_First = 1;
        public static void Main(string[] args)
        {
          //  MainMenu mainMenu = new MainMenu("Main Menu");
            SubMenu dateTimeMenu = new SubMenu("Show Date / Time");
       //     SubMenu versionAndCountDigitsMenu = new SubMenu("Version and Digits");
            ShowTime showTime = new ShowTime();
            ShowDate showDate = new ShowDate();
            CountSpaces countDigits = new CountSpaces();
            ShowVersion showVersion = new ShowVersion();

            dateTimeMenu.AddSubMenuItem(showVersion);
            dateTimeMenu.AddSubMenuItem(countDigits);
            dateTimeMenu.AddSubMenuItem(showDate);
            dateTimeMenu.AddSubMenuItem(showTime);
           
            
            dateTimeMenu.printCurrentSubMenu();
          
            Console.ReadKey();
        }
        
    }
}
