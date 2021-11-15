using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMDIRecorder
{
    public partial class FormMessage : Form
    {
        public FormMessage()
        {
            InitializeComponent();
        }

        private void FormMessage_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == true)
            {
                labelMessage.Text = clGlobal.MessageText;
                labelMessage.ForeColor = Color.Black;
                labelMessage.BringToFront();
                this.Text = clGlobal.MessageWarning;
                this.Width = labelMessage.Text.Length * 15 + 15;

                int ScreenWidth = 0;
                int ScreenHeight = 0;
                int PosicaoInicial = 0;

                ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
                ScreenHeight = Screen.PrimaryScreen.Bounds.Height;

                PosicaoInicial = (ScreenWidth - this.Width) / 2;
                this.Left = PosicaoInicial;
                this.Refresh();
            }

        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            
        }

        private void labelMessage_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
