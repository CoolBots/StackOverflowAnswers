using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIFormRefreshAllChildren
{
    public partial class mainForm : Form
    {
        Random rnd = new Random();

        public mainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) 
            => Application.Exit();

        /// <summary>
        /// Raised when a child form notified parent of changes
        /// </summary>
        public event EventHandler ChildFormChanged;

        /// <summary>
        /// This event handler will notify all child forms that one form has changed.
        /// </summary>
        /// <param name="sender">The child form that has changed</param>
        /// <param name="e">Any event arguments passed by the child form tht has changed</param>
        public void NotifyAllChildren(object sender, EventArgs e)
            => ChildFormChanged?.Invoke(sender, e);

        private void createNewFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Generate either Type1 or Type2 form, just to demo different forms
            bool isType1 = rnd.Next(0, 10) < 5;

            MDIChildBase newChild = isType1 ? new MDIChild1() as MDIChildBase : new MDIChild2() as MDIChildBase;
            newChild.MdiParent = this;

            //Parent-child event subscription. 
            //This is the key to the communication between MDI Parent container and all children
            newChild.FormChanged += NotifyAllChildren;
            ChildFormChanged += newChild.ProcessChange;

            newChild.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            => MessageBox.Show("This is an example application\nto demo event-based communication\nbetween MDI Parent and MDI Children");

    }
}
