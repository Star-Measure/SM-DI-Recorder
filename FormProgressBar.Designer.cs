namespace SMDIRecorder
{
    partial class FormProgressBar
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
            this.pbPercentual = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbPercentual
            // 
            this.pbPercentual.Location = new System.Drawing.Point(50, 33);
            this.pbPercentual.MarqueeAnimationSpeed = 10;
            this.pbPercentual.Name = "pbPercentual";
            this.pbPercentual.Size = new System.Drawing.Size(270, 40);
            this.pbPercentual.Step = 1;
            this.pbPercentual.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbPercentual.TabIndex = 0;
            // 
            // FormProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 107);
            this.Controls.Add(this.pbPercentual);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "% Progresso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProgressBar_FormClosing);
            this.Load += new System.EventHandler(this.FormProgressBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbPercentual;
    }
}