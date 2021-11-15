namespace SMDIRecorder
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portaSerialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleçãoDeArquivoBinárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definiçãoDeDiretórioDeRelatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gravarIUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gravarDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tbNroSerie = new System.Windows.Forms.TextBox();
            this.lblNroSerie = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçãoToolStripMenuItem,
            this.operaçãoToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(723, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portaSerialToolStripMenuItem,
            this.seleçãoDeArquivoBinárioToolStripMenuItem,
            this.definiçãoDeDiretórioDeRelatóriosToolStripMenuItem,
            this.definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem});
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.configuraçãoToolStripMenuItem.Text = "Configuração";
            // 
            // portaSerialToolStripMenuItem
            // 
            this.portaSerialToolStripMenuItem.Name = "portaSerialToolStripMenuItem";
            this.portaSerialToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.portaSerialToolStripMenuItem.Text = "Porta Serial";
            this.portaSerialToolStripMenuItem.Click += new System.EventHandler(this.portaSerialToolStripMenuItem_Click);
            // 
            // seleçãoDeArquivoBinárioToolStripMenuItem
            // 
            this.seleçãoDeArquivoBinárioToolStripMenuItem.Name = "seleçãoDeArquivoBinárioToolStripMenuItem";
            this.seleçãoDeArquivoBinárioToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.seleçãoDeArquivoBinárioToolStripMenuItem.Text = "Seleção de Arquivo Binario";
            this.seleçãoDeArquivoBinárioToolStripMenuItem.Click += new System.EventHandler(this.seleçãoDeArquivoBinárioToolStripMenuItem_Click);
            // 
            // definiçãoDeDiretórioDeRelatóriosToolStripMenuItem
            // 
            this.definiçãoDeDiretórioDeRelatóriosToolStripMenuItem.Name = "definiçãoDeDiretórioDeRelatóriosToolStripMenuItem";
            this.definiçãoDeDiretórioDeRelatóriosToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.definiçãoDeDiretórioDeRelatóriosToolStripMenuItem.Text = "Definição de Diretório de Relatórios";
            this.definiçãoDeDiretórioDeRelatóriosToolStripMenuItem.Click += new System.EventHandler(this.definiçãoDeDiretórioDeRelatóriosToolStripMenuItem_Click);
            // 
            // definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem
            // 
            this.definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem.Name = "definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem";
            this.definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem.Size = new System.Drawing.Size(381, 26);
            this.definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem.Text = "Definição de Diretório de Arquivos Binarios";
            this.definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem.Click += new System.EventHandler(this.definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem_Click);
            // 
            // operaçãoToolStripMenuItem
            // 
            this.operaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gravarIUToolStripMenuItem,
            this.gravarDIToolStripMenuItem});
            this.operaçãoToolStripMenuItem.Name = "operaçãoToolStripMenuItem";
            this.operaçãoToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.operaçãoToolStripMenuItem.Text = "Operação";
            this.operaçãoToolStripMenuItem.Visible = false;
            // 
            // gravarIUToolStripMenuItem
            // 
            this.gravarIUToolStripMenuItem.Name = "gravarIUToolStripMenuItem";
            this.gravarIUToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.gravarIUToolStripMenuItem.Text = "Gravar IU";
            this.gravarIUToolStripMenuItem.Visible = false;
            this.gravarIUToolStripMenuItem.Click += new System.EventHandler(this.gravarIUToolStripMenuItem_Click);
            // 
            // gravarDIToolStripMenuItem
            // 
            this.gravarDIToolStripMenuItem.Name = "gravarDIToolStripMenuItem";
            this.gravarDIToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.gravarDIToolStripMenuItem.Text = "Gravar DI";
            this.gravarDIToolStripMenuItem.Visible = false;
            this.gravarDIToolStripMenuItem.Click += new System.EventHandler(this.gravarDIToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(29, 48);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(633, 39);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Entre com o número de série do produto:";
            // 
            // tbNroSerie
            // 
            this.tbNroSerie.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroSerie.Location = new System.Drawing.Point(265, 127);
            this.tbNroSerie.Margin = new System.Windows.Forms.Padding(2);
            this.tbNroSerie.MaxLength = 12;
            this.tbNroSerie.Name = "tbNroSerie";
            this.tbNroSerie.Size = new System.Drawing.Size(264, 45);
            this.tbNroSerie.TabIndex = 3;
            this.tbNroSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroSerie_KeyPress);
            // 
            // lblNroSerie
            // 
            this.lblNroSerie.AutoSize = true;
            this.lblNroSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSerie.Location = new System.Drawing.Point(29, 126);
            this.lblNroSerie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNroSerie.Name = "lblNroSerie";
            this.lblNroSerie.Size = new System.Drawing.Size(274, 39);
            this.lblNroSerie.TabIndex = 2;
            this.lblNroSerie.Text = "Número de Série";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 195);
            this.Controls.Add(this.lblNroSerie);
            this.Controls.Add(this.tbNroSerie);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "SM DI Recorder";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleçãoDeArquivoBinárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox tbNroSerie;
        private System.Windows.Forms.ToolStripMenuItem portaSerialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gravarIUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gravarDIToolStripMenuItem;
        private System.Windows.Forms.Label lblNroSerie;
        private System.Windows.Forms.ToolStripMenuItem definiçãoDeDiretórioDeRelatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem;
    }
}

