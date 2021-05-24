using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public class ButtonShowVersion : MenuItem
    {
        private const string k_Title = "ShowVersion";

        public ButtonShowVersion() : base(k_Title)
        {
        }

        internal override void DoWhenSelected(object i_Object)
        {
            this.SelectedMenuItem += buttonShowVersion_SelectedMenuItem;
            OnSelected(this);
            this.SelectedMenuItem -= buttonShowVersion_SelectedMenuItem;
        }

        private void buttonShowVersion_SelectedMenuItem(object i_Object)
        {
            Console.WriteLine("Version: 21.1.4.8930");
        }
    }
}