using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RadminGrantsEditor
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        public void SetText(string text)
        {
            lSplashText.Text = text;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            this.Top = (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2;
            this.Left = (SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2;
        }
    }
}
