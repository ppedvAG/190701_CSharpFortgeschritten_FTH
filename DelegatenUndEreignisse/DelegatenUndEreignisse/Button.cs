using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        public EventHandler ClickEventHandler;

        public void Click()
        {
            if(ClickEventHandler != null)
                ClickEventHandler(this,EventArgs.Empty);
        }
    }
}
