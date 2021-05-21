using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class ButtonShowTime : ActionItem
    {
        private const string k_Title = "ShowTime";

        public ButtonShowTime() : base(k_Title)
        {

        }

        public override void ActivateFunction()
        {
            Console.WriteLine("The time now is {0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
        }
    }
}