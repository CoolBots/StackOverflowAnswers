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

        public virtual void ProcessChange(object sender, EventArgs e)
        {
            if((sender as Form) != this)
            {
                BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            }
        }

        protected void NotifyParent() => FormChanged?.Invoke(this, EventArgs.Empty);

    }
}