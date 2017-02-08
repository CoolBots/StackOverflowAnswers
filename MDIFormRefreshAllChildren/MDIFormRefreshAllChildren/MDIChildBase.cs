using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIFormRefreshAllChildren
{
    public class MDIChildBase : Form
    {
        Random rnd = new Random();

        public event EventHandler<EventArgs> FormChanged;

        /// <summary>
        /// This event handler will be called by the MDI Parent's ChildFormChanged event
        /// </summary>
        /// <param name="sender">The child form that has changed. Can be this form.</param>
        /// <param name="e">Event arguments passed by the child form that has changed</param>
        public virtual void ProcessChange(object sender, EventArgs e)
        {
            //Only process change if this form is not the one causing this event to trigger in the first place.
            if((sender as Form) != this)
            {
                BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            }
        }

        /// <summary>
        /// Only the owning form can invoke the event. This is a pass-through function
        /// used to invoke the FormChanged event, to be called by an MDI Child form upon changes
        /// that other child forms need to be notified of.
        /// </summary>
        protected void NotifyParent() => FormChanged?.Invoke(this, EventArgs.Empty);

    }
}