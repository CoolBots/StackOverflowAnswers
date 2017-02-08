namespace MDIFormRefreshAllChildren
{
    partial class MDIChild1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.typeStuffLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // typeStuffLabel
            // 
            this.typeStuffLabel.AutoSize = true;
            this.typeStuffLabel.Location = new System.Drawing.Point(25, 48);
            this.typeStuffLabel.Name = "typeStuffLabel";
            this.typeStuffLabel.Size = new System.Drawing.Size(59, 13);
            this.typeStuffLabel.TabIndex = 1;
            this.typeStuffLabel.Text = "Type Stuff:";
            // 
            // MDIChild1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 107);
            this.Controls.Add(this.typeStuffLabel);
            this.Controls.Add(this.textBox1);
            this.Name = "MDIChild1";
            this.Text = "MDI Child (type1)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label typeStuffLabel;
    }
}