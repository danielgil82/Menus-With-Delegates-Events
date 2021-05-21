using System;
using System.Collections.Generic;
using System.Text;

namespace Menus.Delegates
{
    public delegate void SelectedEventHandler();

    public class ActionItem : MenuItem
    {
        public event SelectedEventHandler Selected;

        public ActionItem(string i_Title) : base(i_Title)
        {
        }

        /// <summary>
        /// Added this function to be intermediate between the main and OnSelected due to it's protection level.
        /// </summary>
        public override void SelectedItem()
        {
            OnSelected();
        }

        protected virtual void OnSelected()
        {
            // call a pointer to function, to let others know that I was clicked:
            if (Selected != null)
            {
                Selected.Invoke();
            }
        }
    }
}