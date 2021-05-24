using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Menus.Delegates
{
    public class ButtonSubMenu : MenuItem
    {
        private const string k_MainTitle = "Main Menu";
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";
        private const byte k_EndCurrentLevel = 0;
        private readonly Hashtable r_MenuItems;
        private byte m_CurrentIdx = 1;
        private string m_FirstOptionInSubMenu;

        public ButtonSubMenu(string i_Title) : base(i_Title)
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

        internal override void DoWhenSelected(object i_SubMenu)
        {
            this.SelectedMenuItem += buttonSubMenu_SelectedMenuItem;
            OnSelected(this);
            this.SelectedMenuItem -= buttonSubMenu_SelectedMenuItem;
        }

        internal void ShowSubMenu(object i_sender)
        {
            buttonSubMenu_SelectedMenuItem(i_sender);
        }

        /// A recursive function that show's the menus
        private void buttonSubMenu_SelectedMenuItem(object i_sender)
        {
            bool continueToShow = true;
            string PreviousTitle = (i_sender as MenuItem).Title;

            while (continueToShow)
            {
                string userChoice = string.Empty;
                byte userChoiceByte;

                decideAndUpdateIfExitOrBackAsFirstOption();
                printCurrentSubMenu(PreviousTitle);
                try
                {
                    userChoice = getUserChoice();
                    validateUserChoice(userChoice);
                    userChoiceByte = byte.Parse(userChoice);
                    Console.Clear();
                    if (r_MenuItems[userChoiceByte] is MenuItem)
                    {
                        (r_MenuItems[userChoiceByte] as MenuItem).DoWhenSelected(r_MenuItems[userChoiceByte]);

                        if (!(r_MenuItems[userChoiceByte] is ButtonSubMenu))
                        {
                            printsInTheEndOfAction();
                        }
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

        // Get user's input
        private string getUserChoice()
        {
            string userChoice = string.Empty;

            Console.Write("Please enter your choice 1-{0} or 0 for {1}: ", r_MenuItems.Count - 1, m_FirstOptionInSubMenu);
            userChoice = Console.ReadLine();

            return userChoice;
        }

        // Validation on users choice
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