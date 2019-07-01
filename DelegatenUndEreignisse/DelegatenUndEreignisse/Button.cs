using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        // Variante "Lang"
        //private EventHandler clickEventHandler;
        //public event EventHandler ClickEvent
        //{
        //    add
        //    {
        //        clickEventHandler += value;
        //    }
        //    remove
        //    {
        //        clickEventHandler -= value;
        //    }
        //}

        // Variante "kurz"
        public event EventHandler ClickEvent;


        public void Click()
        {
            if(ClickEvent != null)
                ClickEvent(this,EventArgs.Empty);
        }
    }
}
