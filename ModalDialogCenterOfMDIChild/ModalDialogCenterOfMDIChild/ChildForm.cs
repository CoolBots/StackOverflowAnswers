using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModalDialogCenterOfMDIChild
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        private void invokeDialogButton_Click(object sender, EventArgs e)
        {
            var dialogForm = new DialogForm();
            dialogForm.StartPosition = FormStartPosition.Manual;

            //Get the actual position of the MDI Parent form in screen coords
            Point screenLocation = Parent.PointToScreen(Parent.Location);

            //Adjust for position of the MDI Child form in screen coords
            screenLocation.X += Location.X;
            screenLocation.Y += Location.Y;

            dialogForm.Location = new Point(screenLocation.X + (Width - dialogForm.Width) / 2,
                                            screenLocation.Y + (Height - dialogForm.Height) / 2);

            dialogForm.ShowDialog(this);
        }
    }
}
