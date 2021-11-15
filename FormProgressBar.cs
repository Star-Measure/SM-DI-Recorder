using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SMDIRecorder
{
    public partial class FormProgressBar : Form
    {
        public FormProgressBar()
        {
            InitializeComponent();
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
            pbPercentual.Maximum = 100;
            pbPercentual.Step = 1;
            pbPercentual.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void FormProgressBar_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void AtualizaPercentual(double ValorPercentual)
        {
            pbPercentual.Value = (int) ValorPercentual;
            this.Refresh();
        }

        public void AtualizaMensagem(string Message)
        {
            this.Text = Message;
            this.Refresh();
        }
    }
}
