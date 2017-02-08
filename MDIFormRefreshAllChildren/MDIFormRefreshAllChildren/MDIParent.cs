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

        public event EventHandler ChildFormChanged;

        public void NotifyAllChildren(object sender, EventArgs e)
            => ChildFormChanged?.Invoke(sender, e);

        private void createNewFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isType1 = rnd.Next(0, 10) < 5;

            MDIChildBase newChild = isType1 ? new MDIChild1() as MDIChildBase : new MDIChild2() as MDIChildBase;
            newChild.MdiParent = this;

            newChild.FormChanged += NotifyAllChildren;
            ChildFormChanged += newChild.ProcessChange;

            newChild.Show();
        }
    }
}
