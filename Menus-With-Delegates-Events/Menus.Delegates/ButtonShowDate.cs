using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class ButtonShowDate : MenuItem
    {
       // public delegate void ClickEventHandler(object sender, ClickEventArgs e);

        private const string k_Title = "ShowDate";

        public ButtonShowDate() : base(k_Title)
        {
        }

        public override void ActivateFunction()
        {
            Console.WriteLine("The date is {0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }
    }
}