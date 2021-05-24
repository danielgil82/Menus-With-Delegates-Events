using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class ButtonShowDate : MenuItem
    {
        private const string k_Title = "ShowDate";

        public ButtonShowDate() : base(k_Title)
        {
        }

        internal override void DoWhenSelected(object i_Object)
        {
            this.SelectedMenuItem += new SelectedEventHandler(buttonShowDate_SelectedMenuItem);
            OnSelected(this);
            this.SelectedMenuItem -= new SelectedEventHandler(buttonShowDate_SelectedMenuItem);
        }

        private void buttonShowDate_SelectedMenuItem(object i_Object)
        {
            Console.WriteLine("The date is {0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }
    }
}