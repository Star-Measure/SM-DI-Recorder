namespace SMDIRecorder
{
    partial class FormConfiguracao
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
            this.GBProtocolo = new System.Windows.Forms.GroupBox();
            this.RBMultiponto = new System.Windows.Forms.RadioButton();
            this.RBNBR14522 = new System.Windows.Forms.RadioButton();
            this.btFechar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GBHardware = new System.Windows.Forms.GroupBox();
            this.rbSerial = new System.Windows.Forms.RadioButton();
            this.rbRS485 = new System.Windows.Forms.RadioButton();
            this.picSairConfiguracao = new System.Windows.Forms.PictureBox();
            this.GBProtocolo.SuspendLayout();
            this.GBHardware.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSairConfiguracao)).BeginInit();
            this.SuspendLayout();
            // 
            // GBProtocolo
            // 
            this.GBProtocolo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.GBProtocolo.Controls.Add(this.RBMultiponto);
            this.GBProtocolo.Controls.Add(this.RBNBR14522);
            this.GBProtocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBProtocolo.Location = new System.Drawing.Point(20, 62);
            this.GBProtocolo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBProtocolo.Name = "GBProtocolo";
            this.GBProtocolo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBProtocolo.Size = new System.Drawing.Size(177, 130);
            this.GBProtocolo.TabIndex = 0;
            this.GBProtocolo.TabStop = false;
            this.GBProtocolo.Text = "Protocolo";
            // 
            // RBMultiponto
            // 
            this.RBMultiponto.AutoSize = true;
            this.RBMultiponto.Checked = true;
            this.RBMultiponto.Location = new System.Drawing.Point(20, 46);
            this.RBMultiponto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RBMultiponto.Name = "RBMultiponto";
            this.RBMultiponto.Size = new System.Drawing.Size(118, 28);
            this.RBMultiponto.TabIndex = 1;
            this.RBMultiponto.TabStop = true;
            this.RBMultiponto.Text = "Multiponto";
            this.RBMultiponto.UseVisualStyleBackColor = true;
            this.RBMultiponto.CheckedChanged += new System.EventHandler(this.RBMultiponto_CheckedChanged);
            // 
            // RBNBR14522
            // 
            this.RBNBR14522.AutoSize = true;
            this.RBNBR14522.Enabled = false;
            this.RBNBR14522.Location = new System.Drawing.Point(20, 80);
            this.RBNBR14522.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RBNBR14522.Name = "RBNBR14522";
            this.RBNBR14522.Size = new System.Drawing.Size(125, 28);
            this.RBNBR14522.TabIndex = 0;
            this.RBNBR14522.Text = "NBR 14522";
            this.RBNBR14522.UseVisualStyleBackColor = true;
            this.RBNBR14522.Visible = false;
            this.RBNBR14522.CheckedChanged += new System.EventHandler(this.RBNBR14522_CheckedChanged);
            // 
            // btFechar
            // 
            this.btFechar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFechar.Location = new System.Drawing.Point(292, 330);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(160, 37);
            this.btFechar.TabIndex = 1;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = false;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(73, 330);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(160, 37);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Configuração";
            // 
            // GBHardware
            // 
            this.GBHardware.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.GBHardware.Controls.Add(this.rbSerial);
            this.GBHardware.Controls.Add(this.rbRS485);
            this.GBHardware.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBHardware.Location = new System.Drawing.Point(219, 62);
            this.GBHardware.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBHardware.Name = "GBHardware";
            this.GBHardware.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBHardware.Size = new System.Drawing.Size(177, 130);
            this.GBHardware.TabIndex = 2;
            this.GBHardware.TabStop = false;
            this.GBHardware.Text = "Hardware";
            // 
            // rbSerial
            // 
            this.rbSerial.AutoSize = true;
            this.rbSerial.Checked = true;
            this.rbSerial.Location = new System.Drawing.Point(25, 28);
            this.rbSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSerial.Name = "rbSerial";
            this.rbSerial.Size = new System.Drawing.Size(78, 28);
            this.rbSerial.TabIndex = 1;
            this.rbSerial.TabStop = true;
            this.rbSerial.Text = "Serial";
            this.rbSerial.UseVisualStyleBackColor = true;
            this.rbSerial.CheckedChanged += new System.EventHandler(this.rbSerial_CheckedChanged);
            // 
            // rbRS485
            // 
            this.rbRS485.AutoSize = true;
            this.rbRS485.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rbRS485.Location = new System.Drawing.Point(25, 64);
            this.rbRS485.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbRS485.Name = "rbRS485";
            this.rbRS485.Size = new System.Drawing.Size(86, 28);
            this.rbRS485.TabIndex = 5;
            this.rbRS485.Text = "RS485";
            this.rbRS485.UseVisualStyleBackColor = true;
            this.rbRS485.CheckedChanged += new System.EventHandler(this.rbRS485_CheckedChanged);
            // 
            // picSairConfiguracao
            // 
            this.picSairConfiguracao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSairConfiguracao.Enabled = false;
            this.picSairConfiguracao.Image = global::SMDIRecorder.Properties.Resources.btSair;
            this.picSairConfiguracao.Location = new System.Drawing.Point(464, 16);
            this.picSairConfiguracao.Margin = new System.Windows.Forms.Padding(4);
            this.picSairConfiguracao.Name = "picSairConfiguracao";
            this.picSairConfiguracao.Size = new System.Drawing.Size(32, 30);
            this.picSairConfiguracao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSairConfiguracao.TabIndex = 4;
            this.picSairConfiguracao.TabStop = false;
            this.picSairConfiguracao.Visible = false;
            this.picSairConfiguracao.Click += new System.EventHandler(this.picSairConfiguracao_Click);
            // 
            // FormConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(513, 382);
            this.Controls.Add(this.GBHardware);
            this.Controls.Add(this.picSairConfiguracao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.GBProtocolo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguracao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfiguracao_FormClosing);
            this.Shown += new System.EventHandler(this.FormConfiguracao_Shown);
            this.GBProtocolo.ResumeLayout(false);
            this.GBProtocolo.PerformLayout();
            this.GBHardware.ResumeLayout(false);
            this.GBHardware.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSairConfiguracao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBProtocolo;
        private System.Windows.Forms.RadioButton RBMultiponto;
        private System.Windows.Forms.RadioButton RBNBR14522;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picSairConfiguracao;
        private System.Windows.Forms.GroupBox GBHardware;
        private System.Windows.Forms.RadioButton rbSerial;
        private System.Windows.Forms.RadioButton rbRS485;
    }
}