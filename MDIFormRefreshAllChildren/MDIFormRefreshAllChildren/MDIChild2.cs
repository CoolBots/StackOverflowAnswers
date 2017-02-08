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
    public partial class MDIChild2 : MDIChildBase
    {
        public MDIChild2()
        {
            InitializeComponent();
        }

        private void clickMeButton_Click(object sender, EventArgs e) 
            => base.NotifyParent(); //Raise the FormChanged event via the base class
    }
}
