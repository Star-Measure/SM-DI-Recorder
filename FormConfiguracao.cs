using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Win32;
using System.IO;

namespace SMDIRecorder
{
    public partial class FormConfiguracao : Form
    {
        public GroupBox groupBox1;

        FormMessage FormMessage = new FormMessage();       

        public FormConfiguracao()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {            
            try
            {
                string[] Ports = SerialPort.GetPortNames();

                clGlobal.NomeArquivoIni = "Config.ini";

                // Caso não exista o diretório de Serviços atendidos, o cria
                if (!(System.IO.Directory.Exists(clGlobal.STR_DiretorioParaArquivosIni)))
                {
                    System.IO.Directory.CreateDirectory(clGlobal.STR_DiretorioParaArquivosIni);
                }

                if (System.IO.File.Exists(@clGlobal.STR_DiretorioParaArquivosIni + clGlobal.NomeArquivoIni))
                {

                    System.IO.File.Delete(clGlobal.STR_DiretorioParaArquivosIni + clGlobal.NomeArquivoIni);
                }
                
                // Arquivo deve ser criado
                clGlobal.SaidaIni = System.IO.File.Open(clGlobal.STR_DiretorioParaArquivosIni + clGlobal.NomeArquivoIni, System.IO.FileMode.Create);
                clGlobal.ArquivoIni = new System.IO.StreamWriter(clGlobal.SaidaIni);
                clGlobal.ArquivoIni.WriteLine("[Protocolo]");
                if (clGlobal.BOL_ProtocoloMultiponto)
                {
                    clGlobal.ArquivoIni.WriteLine("Multiponto = 1");
                }
                else
                {
                    clGlobal.ArquivoIni.WriteLine("Multiponto = 0");
                }
                clGlobal.ArquivoIni.WriteLine("");
                clGlobal.ArquivoIni.WriteLine("[COMM]");
                if (rbSerial.Checked)
                {
                    clGlobal.ArquivoIni.WriteLine("HW = Serial");
                    clGlobal.ENUM_TipoHW = clGlobal.enumTipoHW.eSerial;
                    clGlobal.eSerialRS485 = false;
                }
                else if (rbRS485.Checked)
                {
                    clGlobal.ArquivoIni.WriteLine("HW = RS485");
                    clGlobal.ENUM_TipoHW = clGlobal.enumTipoHW.eSerial;
                    clGlobal.eSerialRS485 = true;
                }
                clGlobal.ArquivoIni.WriteLine("");
                clGlobal.ArquivoIni.WriteLine("[Serial]");
                if((clGlobal.PortaSerialEscolhida == null)||(clGlobal.PortaSerialEscolhida == "NULL")||(clGlobal.PortaSerialEscolhida == "null"))
                {
                    clGlobal.ArquivoIni.WriteLine("Porta = NULL");
                }
                else
                {
                    clGlobal.ArquivoIni.WriteLine("Porta = " + clGlobal.PortaSerialEscolhida);
                }
                clGlobal.ArquivoIni.Close();
                clGlobal.SaidaIni.Close();
            }
            catch (Exception erro)
            {
                // Mensagem de erro ao tentar criar arquivo ini
                //MessageBox.Show("Erro ao criar arquivo ini : " + erro.Message, "Erro");
                clGlobal.AtualizaMsgCaixaTexto("Erro ao criar arquivo ini.");
            }

            /*
            try
            {
                try
                {
                    // Verificar se registro existe
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MGE\Configura_MGE", true);
                    if (registryKey != null)
                    {
                        // Registro Existe;
                        // Grava o caminho na SubChave GravaRegistro

                        MessageBox.Show("Registro Existe");

                        //Testa se Multiponto existe
                        String[] Registros = registryKey.GetValueNames();

                        if (clGlobal.BOL_ProtocoloMultiponto)
                        {
                            registryKey.SetValue("Multiponto", 1, RegistryValueKind.DWord);                            
                        }
                        else
                        {
                            registryKey.SetValue("Multiponto", 0, RegistryValueKind.DWord);
                        }
                        registryKey.SetValue("PortaSerial", clGlobal.PortaSerialEscolhida);

                        // fecha a Chave de Restistro registro
                        registryKey.Close();
                    }
                }
                catch (Exception erro)
                {
                    // Mensagem de erro ao tentar ler chave de registro
                    MessageBox.Show("Erro no Leitura do Registro: " + erro.Message);
                }

            }
            catch (Exception erro)
            {
                // Mensagem de erro ao tentar criar chave de registro
                MessageBox.Show("Erro no gravação do Registro: " + erro.Message);
            }
            */

            if (rbSerial.Checked)
            {
                clGlobal.LinhasCaixaTexto[2] = "Interface serial selecionada";
            }
            else if (rbRS485.Checked)
            {
                clGlobal.LinhasCaixaTexto[2] = "Interface RS485 selecionada";
            }

            // fecha a Chave de Restistro registro
            this.Close();
        }

        private void RBMultiponto_CheckedChanged(object sender, EventArgs e)
        {
            if (RBMultiponto.Checked)
            {
                clGlobal.BOL_ProtocoloMultiponto = true;
            }
            else
            {
                clGlobal.BOL_ProtocoloMultiponto = false;
            }
            RBNBR14522.Checked = !clGlobal.BOL_ProtocoloMultiponto;
            clGlobal.BOL_Protocolo_SM = false;
            clGlobal.BOL_ProtocoloCodi = !clGlobal.BOL_ProtocoloMultiponto;

        }

        private void RBNBR14522_CheckedChanged(object sender, EventArgs e)
        {
            if (RBNBR14522.Checked)
            {
                clGlobal.BOL_ProtocoloMultiponto = false;
            }
            else
            {
                clGlobal.BOL_ProtocoloMultiponto = true;
            }
            RBMultiponto.Checked = clGlobal.BOL_ProtocoloMultiponto;
            clGlobal.BOL_Protocolo_SM = false;
            clGlobal.BOL_ProtocoloCodi = !clGlobal.BOL_ProtocoloMultiponto;
        }

        public void CreateGroupBox(string GroupName, string boxName, int x, int y, int width, int height)
        {
            if (groupBox1 != null)
            {
                //Caso já exista um group box, remove
                this.Controls.Remove(groupBox1);
            }

            string[] Ports = SerialPort.GetPortNames();

            groupBox1 = new GroupBox();
            groupBox1.Name = GroupName;
            groupBox1.Text = boxName;
            groupBox1.Location = new Point(x, y);
            groupBox1.Size = new Size(width, height);
            groupBox1.Font = new Font("Microsof Sans Serif", 11, FontStyle.Regular, GraphicsUnit.Point);
            this.Controls.Add(groupBox1);
            groupBox1.Visible = true;
            groupBox1.Enabled = true;
        }


        private void FormConfiguracao_Shown(object sender, EventArgs e)
        {
            int i = 0;

            clGlobal.MessageText = "Carregando portas de comunicação...";
            clGlobal.MessageWarning = "Aviso";

            FormMessage.Width = clGlobal.MessageText.Length * 12 + 10;
            FormMessage.Left = (clGlobal.LarguraTela - FormMessage.Width) / 2;
            FormMessage.Visible = true;
            FormMessage.Refresh();

            if (clGlobal.BOL_ProtocoloMultiponto)
            {
                RBMultiponto.Checked = true;
                RBNBR14522.Checked = false;
            }
            else
            {
                RBMultiponto.Checked = false;
                RBNBR14522.Checked = true;
            }

            //As informações abaixo foram carregadas quando da abertura do software
            if (clGlobal.ENUM_TipoHW == clGlobal.enumTipoHW.eSerial)
            {
                if (clGlobal.eSerialRS485)
                {
                    rbRS485.Checked = true;
                }
                else
                {
                    rbSerial.Checked = true;
                }
            }
            
            if (rbSerial.Checked || rbRS485.Checked)
            {
                string[] Ports = SerialPort.GetPortNames();

                if (Ports.Length > 0)
                {

                    //MessageBox.Show("Quantidade de Portas Encontradas : " + Ports.Length);

                    CreateGroupBox("gbPortaSerial", "Portas Seriais", GBProtocolo.Left, GBProtocolo.Bottom + 5, (Ports.Length * 140), (Ports.Length * 40) + 30);
                    Refresh();

                    string[] PortasSeriaisDisponiveis = new string[Ports.Length];
                    string PortaAtual = "NULL";
                    clGlobal.SerialCom.Close();
                    foreach (String NomePortas in Ports)
                    {
                        clGlobal.SerialCom.PortName = NomePortas;
                        try
                        {
                            clGlobal.SerialCom.Open();
                            Refresh();
                        }
                        catch (Exception)
                        {
                            //throw;
                            //MessageBox.Show("Erro Serial - Função: AbreComunicacao");
                            //MessageBox.Show("ReadByte()");
                            if (clGlobal.PortaSerialEscolhida == NomePortas)
                            {
                                clGlobal.PortaSerialEscolhida = "NULL";
                            }
                        }
                        if (clGlobal.SerialCom.IsOpen == true)
                        {
                            PortasSeriaisDisponiveis[i++] = NomePortas;
                            if (clGlobal.PortaSerialEscolhida == NomePortas)
                            {
                                PortaAtual = clGlobal.PortaSerialEscolhida;
                            }
                            clGlobal.SerialCom.Close();
                            Refresh();
                        }
                    }
                    string[] NomePortasSeriais = new string[i];
                    if (i > 0)
                    {
                        Array.Copy(PortasSeriaisDisponiveis, NomePortasSeriais, i);
                        if (PortaAtual == "NULL")
                        {
                            clGlobal.PortaSerialEscolhida = PortasSeriaisDisponiveis[0];
                        }
                    }
                    else
                    {
                        clGlobal.PortaSerialEscolhida = "NULL";
                    }

                    i = 0;

                    //ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");

                    try
                    {
                        int MaiorTexto = 0;

                        //foreach (ManagementObject queryObj in searcher.Get())
                        //{
                        //    NomePortasSeriais[i++] = queryObj["Caption"].ToString();
                        //}

                        Array.Sort(NomePortasSeriais);

                        for (int x = 0; x < NomePortasSeriais.Length; x++)
                        {
                            RadioButton rdo = new RadioButton();
                            //rdo.Name = NomePortasSeriais[x].Substring(NomePortasSeriais[x].Length - 5, 4);
                            rdo.Name = NomePortasSeriais[x];
                            rdo.Text = NomePortasSeriais[x];
                            if (rdo.Text.Length > MaiorTexto)
                            {
                                MaiorTexto = rdo.Text.Length;
                            }
                            rdo.AutoSize = true;
                            rdo.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
                            rdo.Location = new Point(10, ((30 * x) + 40));
                            rdo.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                            groupBox1.Controls.Add(rdo);
                            Refresh();
                            if (rdo.Name.Contains(clGlobal.PortaSerialEscolhida))
                            {
                                rdo.Checked = true;
                            }
                        }

                        //MessageBox.Show("Tela");

                        //groupBox1.Height += 10;

                        if (NomePortasSeriais.Length > 0)
                        {
                            //this.Width = (MaiorTexto * 10);
                            this.Height = groupBox1.Top + groupBox1.Height + btFechar.Height + 70;
                            btCancelar.Top = groupBox1.Bottom + 20;
                            btFechar.Top = groupBox1.Bottom + 20;
                            //groupBox1.Width = this.Width - 40;
                            picSairConfiguracao.Left = this.Width - 40;
                        }
                    }
                    catch (Exception err)
                    {
                        //MessageBox.Show("Falha na porta serial:" + err, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clGlobal.AtualizaMsgCaixaTexto("Falha na porta serial.");
                        return;
                    }
                }
                else
                {
                    CreateGroupBox("gbPortaSerial", "Portas Seriais", 15, 140, 80, 50);
                    Refresh();
                }
            }

            FormMessage.Visible = false;

            /*
            int i = 0;

            if (clGlobal.BOL_ProtocoloMultiponto)
            {
                RBMultiponto.Checked = true;
                RBNBR14522.Checked = false;
            }
            else
            {
                RBMultiponto.Checked = false;
                RBNBR14522.Checked = true;
            }

            if(clGlobal.HW == "Serial")
            {
                rbSerial.Checked = true;
            }
            else if(clGlobal.HW == "Bluetooth")
            {
                rbBLE.Checked = true;
            }
            else if(clGlobal.HW == "Ethernet")
            {
                rbEthernet.Checked = true;
            }

            if (rbSerial.Checked)
            {
                string[] Ports = SerialPort.GetPortNames();

                if (Ports.Length > 0)
                {

                    //MessageBox.Show("Quantidade de Portas Encontradas : " + Ports.Length);

                    CreateGroupBox("gbPortaSerial", "Portas Seriais", GBProtocolo.Left, GBProtocolo.Bottom + 5, (Ports.Length * 140), (Ports.Length * 40) + 30);

                    string[] NomePortasSeriais = new string[Ports.Length];

                    foreach (String NomePortas in Ports)
                    {
                        NomePortasSeriais[i++] = NomePortas;
                    }

                    i = 0;

                    //ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");

                    try
                    {
                        int MaiorTexto = 0;

                        //foreach (ManagementObject queryObj in searcher.Get())
                        //{
                        //    NomePortasSeriais[i++] = queryObj["Caption"].ToString();
                        //}

                        Array.Sort(NomePortasSeriais);

                        for (int x = 0; x < NomePortasSeriais.Length; x++)
                        {
                            RadioButton rdo = new RadioButton();
                            //rdo.Name = NomePortasSeriais[x].Substring(NomePortasSeriais[x].Length - 5, 4);
                            rdo.Name = NomePortasSeriais[x];
                            rdo.Text = NomePortasSeriais[x];
                            if (rdo.Text.Length > MaiorTexto)
                            {
                                MaiorTexto = rdo.Text.Length;
                            }
                            rdo.AutoSize = true;
                            rdo.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
                            rdo.Location = new Point(10, ((30 * x) + 40));
                            rdo.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                            groupBox1.Controls.Add(rdo);
                            if (rdo.Name.Contains(clGlobal.PortaSerialEscolhida))
                            {
                                rdo.Checked = true;
                            }
                        }

                        //MessageBox.Show("Tela");

                        //groupBox1.Height += 10;

                        if (NomePortasSeriais.Length > 0)
                        {
                            //this.Width = (MaiorTexto * 10);
                            this.Height = groupBox1.Top + groupBox1.Height + btFechar.Height + 70;
                            btCancelar.Top = groupBox1.Bottom + 20;
                            btFechar.Top = groupBox1.Bottom + 20;
                            //groupBox1.Width = this.Width - 40;
                            picSairConfiguracao.Left = this.Width - 40;
                        }
                    }
                    catch (Exception err)
                    {
                        //MessageBox.Show("Falha na porta serial:" + err, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clGlobal.AtualizaMsgCaixaTexto("Falha na porta serial.");
                        return;
                    }
                }
                else
                {
                    CreateGroupBox("gbPortaSerial", "Portas Seriais", 15, 140, 80, 50);
                }
            }
            else if (rbEthernet.Checked)
            {
                CreateGroupBox("gbEthernet", "Ethernet", GBProtocolo.Left, GBProtocolo.Bottom + 5, (GBHardware.Right - GBProtocolo.Left), 80);
            }
            */
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            //clGlobal.PortaSerialEscolhida = btn.Text.Substring(btn.Text.Length - 5, 4);
            clGlobal.PortaSerialEscolhida = btn.Text;
        }

        private void FormConfiguracao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rbSerial.Checked || rbRS485.Checked)
            {
                if (clGlobal.PortaSerialEscolhida == null)
                {
                    //MessageBox.Show("Selecione uma porta serial", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clGlobal.AtualizaMsgCaixaTexto("Selecione uma porta serial.");
                    e.Cancel = true;
                }
                else
                {
                    groupBox1.Dispose();
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picSairConfiguracao_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbSerial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSerial.Checked)
            {
                int i = 0;

                string[] Ports = SerialPort.GetPortNames();

                if (Ports.Length > 0)
                {

                    //MessageBox.Show("Quantidade de Portas Encontradas : " + Ports.Length);

                    for (int s = 0; s < this.Controls.Count; s++)
                    {
                        if (this.Controls[s].Text == "Ethernet")
                        {
                            this.Controls.Remove(this.Controls[s]);
                        }
                    }

                    CreateGroupBox("gbPortaSerial", "Portas Seriais", GBProtocolo.Left, GBProtocolo.Bottom + 5, (Ports.Length * 140), (Ports.Length * 40) + 30);

                    string[] NomePortasSeriais = new string[Ports.Length];

                    foreach (String NomePortas in Ports)
                    {
                        NomePortasSeriais[i++] = NomePortas;
                    }

                    i = 0;

                    //ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");

                    try
                    {
                        int MaiorTexto = 0;

                        //foreach (ManagementObject queryObj in searcher.Get())
                        //{
                        //    NomePortasSeriais[i++] = queryObj["Caption"].ToString();
                        //}

                        Array.Sort(NomePortasSeriais);

                        for (int x = 0; x < NomePortasSeriais.Length; x++)
                        {
                            RadioButton rdo = new RadioButton();
                            //rdo.Name = NomePortasSeriais[x].Substring(NomePortasSeriais[x].Length - 5, 4);
                            rdo.Name = NomePortasSeriais[x];
                            rdo.Text = NomePortasSeriais[x];
                            if (rdo.Text.Length > MaiorTexto)
                            {
                                MaiorTexto = rdo.Text.Length;
                            }
                            rdo.AutoSize = true;
                            rdo.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
                            rdo.Location = new Point(10, ((30 * x) + 40));
                            rdo.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                            groupBox1.Controls.Add(rdo);
                            if (rdo.Name.Contains(clGlobal.PortaSerialEscolhida))
                            {
                                rdo.Checked = true;
                            }
                        }

                        //MessageBox.Show("Tela");

                        //groupBox1.Height += 10;

                        if (NomePortasSeriais.Length > 0)
                        {
                            //this.Width = (MaiorTexto * 10);
                            this.Height = groupBox1.Top + groupBox1.Height + btFechar.Height + 70;
                            btCancelar.Top = groupBox1.Bottom + 20;
                            btFechar.Top = groupBox1.Bottom + 20;
                            //groupBox1.Width = this.Width - 40;
                            picSairConfiguracao.Left = this.Width - 40;
                        }
                    }
                    catch (Exception err)
                    {
                        //MessageBox.Show("Falha na porta serial:" + err, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clGlobal.AtualizaMsgCaixaTexto("Falha na porta serial.");
                        return;
                    }
                }
                else
                {
                    CreateGroupBox("gbPortaSerial", "Portas Seriais", 15, 140, 80, 50);
                }
            }
        }

        private void rbRS485_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRS485.Checked)
            {
                int i = 0;

                string[] Ports = SerialPort.GetPortNames();

                if (Ports.Length > 0)
                {

                    //MessageBox.Show("Quantidade de Portas Encontradas : " + Ports.Length);

                    for (int s = 0; s < this.Controls.Count; s++)
                    {
                        if (this.Controls[s].Text == "Ethernet")
                        {
                            this.Controls.Remove(this.Controls[s]);
                        }
                    }

                    CreateGroupBox("gbPortaSerial", "Portas Seriais", GBProtocolo.Left, GBProtocolo.Bottom + 5, (Ports.Length * 140), (Ports.Length * 40) + 30);

                    string[] NomePortasSeriais = new string[Ports.Length];

                    foreach (String NomePortas in Ports)
                    {
                        NomePortasSeriais[i++] = NomePortas;
                    }

                    i = 0;

                    //ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");

                    try
                    {
                        int MaiorTexto = 0;

                        Array.Sort(NomePortasSeriais);

                        for (int x = 0; x < NomePortasSeriais.Length; x++)
                        {
                            RadioButton rdo = new RadioButton();
                            rdo.Name = NomePortasSeriais[x];
                            rdo.Text = NomePortasSeriais[x];
                            if (rdo.Text.Length > MaiorTexto)
                            {
                                MaiorTexto = rdo.Text.Length;
                            }
                            rdo.AutoSize = true;
                            rdo.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Point);
                            rdo.Location = new Point(10, ((30 * x) + 40));
                            rdo.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                            groupBox1.Controls.Add(rdo);
                            if (rdo.Name.Contains(clGlobal.PortaSerialEscolhida))
                            {
                                rdo.Checked = true;
                            }
                        }

                        if (NomePortasSeriais.Length > 0)
                        {
                            this.Height = groupBox1.Top + groupBox1.Height + btFechar.Height + 70;
                            btCancelar.Top = groupBox1.Bottom + 20;
                            btFechar.Top = groupBox1.Bottom + 20;
                            picSairConfiguracao.Left = this.Width - 40;
                        }
                    }
                    catch (Exception err)
                    {
                        return;
                    }
                }
                else
                {
                    CreateGroupBox("gbPortaSerial", "Portas Seriais", 15, 140, 80, 50);
                }
            }
        }

        private void mtbIP_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
