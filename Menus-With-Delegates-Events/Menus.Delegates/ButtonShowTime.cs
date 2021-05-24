using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class ButtonShowTime : MenuItem
    {
        private const string k_Title = "ShowTime";

        public ButtonShowTime() : base(k_Title)
        {
        }

        internal override void DoWhenSelected(object i_Object)
        {
            this.SelectedMenuItem += buttonShowTime_SelectedMenuItem;
            OnSelected(this);
            this.SelectedMenuItem -= buttonShowTime_SelectedMenuItem;
        }

        private void buttonShowTime_SelectedMenuItem(object i_Objec)
        {
            Console.WriteLine("The time now is {0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
        }
    }
}