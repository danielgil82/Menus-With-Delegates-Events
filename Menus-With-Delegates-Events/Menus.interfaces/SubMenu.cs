﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace Menus.interfaces
{
    public class SubMenu : MenuItem
    {
       // private static byte m_SubMenusCurrentLevel = 1;
        private byte m_CurrentIdx = 1;
        private const byte k_EndCurrentLevel = 0;
        private readonly Hashtable r_MenuItems;
        private string m_FirstOptionInSubMenu;
        //private const byte k_FirstLevel = 1;
        private const string k_MainTitle = "Main Menu";
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";
        
        public SubMenu(string i_Title):base(i_Title)
        {
            //Title = i_Title;
            r_MenuItems = new Hashtable();
            r_MenuItems.Add(k_EndCurrentLevel, null);//הוספה של 0 בהתחלה 
        }

        public void AddSubMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(m_CurrentIdx, i_MenuItem);
            m_CurrentIdx++;
        }

        public void PrintCurrentSubMenu(string i_PreviousTitle)
        {
           // Console.WriteLine("The current level is: {0}", m_SubMenusCurrentLevel);
            Console.WriteLine(i_PreviousTitle);
            Console.WriteLine("=============================");
            for (byte i = 1; i < r_MenuItems.Count; i++)
            {
                Console.WriteLine("{0}) {1}", i, (r_MenuItems[i] as MenuItem).Title);
                
            }
            Console.WriteLine("{0}) {1}", k_EndCurrentLevel, m_FirstOptionInSubMenu);//שורה 0 תמיד חזור או יציאה

        }

        //פונק שמראה את כל התתי תפריטים
        public void ShowSubMenu(string i_PreviousTitle)
        {
            bool continueToShow = true;
            while (continueToShow)
            {
                string userChoice = string.Empty;
                byte userChoiceByte;

                DecideAndUpdateIfExitOrBackAsFirstOption();
                PrintCurrentSubMenu(i_PreviousTitle);
                try
                {
                    userChoice = GetUserChoice();
                    ValidateUserChoice(userChoice);
                    userChoiceByte = byte.Parse(userChoice);
                    Console.Clear();
                    if (r_MenuItems[userChoiceByte] is SubMenu)
                    {
                       // m_SubMenusCurrentLevel++;// הגדלה של מספר השלב כאשר נכנסים לתת תפריט
                        (r_MenuItems[userChoiceByte] as SubMenu).ShowSubMenu((r_MenuItems[userChoiceByte] as MenuItem).Title);
                    }
                    else if (r_MenuItems[userChoiceByte] is IActionItem)
                    {
                        (r_MenuItems[userChoiceByte] as IActionItem).Activate();
                        PrintsInTheEndOfAction();
                    }
                    else if (userChoiceByte == k_EndCurrentLevel)
                    {
                        continueToShow = false;
                       // m_SubMenusCurrentLevel--; //הקטנה של מספר השלב כאשר הלולאה נשברת
                       if (m_FirstOptionInSubMenu == k_Exit)
                       {
                            Console.WriteLine("Exited main menu, goodbye...");
                            Thread.Sleep(1000);
                       }
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    PrintsInTheEndOfAction();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    PrintsInTheEndOfAction();
                }
            }
        }

        public void PrintsInTheEndOfAction()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        //קבלת קלט מהמשתמש
        public string GetUserChoice()
        {
            string userChoice = string.Empty;

            Console.Write("Please enter your choice 1-{0} or 0 for {1}:", r_MenuItems.Count-1, m_FirstOptionInSubMenu);
            userChoice = Console.ReadLine();

            return userChoice;
        }

        //וולידציה על הקלט של המשתמש
        public void ValidateUserChoice(string i_UserChoice)
        {
            byte numberForParse;
            if (!byte.TryParse(i_UserChoice, out numberForParse))
            {
                throw new FormatException("invalid choice");
            }

            if (!(numberForParse >= k_EndCurrentLevel && numberForParse <= r_MenuItems.Count - 1))
            {
                throw new ValueOutOfRangeException(r_MenuItems.Count - 1, 0);
            }
        }

        public void DecideAndUpdateIfExitOrBackAsFirstOption()
        {
            if (Title == k_MainTitle)
            {
                m_FirstOptionInSubMenu = k_Exit;
            }
            else
            {
                m_FirstOptionInSubMenu = k_Back;
            }
        }
    }
}