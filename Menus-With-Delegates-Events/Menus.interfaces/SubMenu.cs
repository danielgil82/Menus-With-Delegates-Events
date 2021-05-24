using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace Menus.interfaces
{
    public class SubMenu : MenuItem
    {
        private const string k_MainTitle = "Main Menu";
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";
        private const byte k_EndCurrentLevel = 0;
        private readonly Hashtable r_MenuItems;
        private byte m_CurrentIdx = 1;
        private string m_FirstOptionInSubMenu;

        public SubMenu(string i_Title) : base(i_Title)
        {
            r_MenuItems = new Hashtable();
            r_MenuItems.Add(k_EndCurrentLevel, null);
        }

        public void AddSubMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(m_CurrentIdx, i_MenuItem);
            m_CurrentIdx++;
        }

        private void printCurrentSubMenu(string i_PreviousTitle)
        {
            Console.WriteLine(i_PreviousTitle);
            Console.WriteLine("=============================");
            for (byte i = 1; i < r_MenuItems.Count; i++)
            {
                Console.WriteLine("{0}) {1}", i, (r_MenuItems[i] as MenuItem).Title);
            }

            Console.WriteLine("{0}) {1}", k_EndCurrentLevel, m_FirstOptionInSubMenu);
        }

        internal void ShowSubMenu(string i_PreviousTitle)
        {
            bool continueToShow = true;

            while (continueToShow)
            {
                string userChoice = string.Empty;
                byte userChoiceByte;

                decideAndUpdateIfExitOrBackAsFirstOption();
                printCurrentSubMenu(i_PreviousTitle);
                try
                {
                    userChoice = getUserChoice();
                    validateUserChoice(userChoice);
                    userChoiceByte = byte.Parse(userChoice);
                    Console.Clear();
                    if (r_MenuItems[userChoiceByte] is SubMenu)
                    {
                        (r_MenuItems[userChoiceByte] as SubMenu).ShowSubMenu((r_MenuItems[userChoiceByte] as MenuItem).Title);
                    }
                    else if (r_MenuItems[userChoiceByte] is IActionItem)
                    {
                        (r_MenuItems[userChoiceByte] as IActionItem).Activate();
                        printsInTheEndOfAction();
                    }
                    else if (userChoiceByte == k_EndCurrentLevel)
                    {
                        continueToShow = false;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    printsInTheEndOfAction();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    printsInTheEndOfAction();
                }
            }
        }

        private void printsInTheEndOfAction()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private string getUserChoice()
        {
            string userChoice = string.Empty;

            Console.Write("Please enter your choice 1-{0} or 0 for {1}: ", r_MenuItems.Count - 1, m_FirstOptionInSubMenu);
            userChoice = Console.ReadLine();

            return userChoice;
        }

        private void validateUserChoice(string i_UserChoice)
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

        private void decideAndUpdateIfExitOrBackAsFirstOption()
        {
            m_FirstOptionInSubMenu = Title == k_MainTitle ? k_Exit : k_Back;
        }
    }
}