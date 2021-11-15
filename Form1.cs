using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMDIRecorder
{
    public partial class FormPrincipal : Form
    {
        string NomeArquivoBinario = "";

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void gravarIUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMessage FormMensagem = new FormMessage();

            clGlobal.MessageWarning = "Gravação de IU";
            Variaveis_Globais.GravouIU = false;

            String IU = Variaveis_Globais.stProdutos.NroIUPainel;

            if ((IU.Length == 11) && (clGlobal.ArquivoOriginalSDI != ""))
            {
                // Tamanho do IU correto.
                byte[] BufferIU = new byte[5];

                BufferIU[4] = Byte.Parse(IU.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                BufferIU[3] = Byte.Parse(IU.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
                BufferIU[2] = Byte.Parse(IU.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
                BufferIU[1] = Byte.Parse(IU.Substring(7, 2), System.Globalization.NumberStyles.HexNumber);
                BufferIU[0] = Byte.Parse(IU.Substring(9, 2), System.Globalization.NumberStyles.HexNumber);

                try
                {
                    String ArquivoTemporario = "";

                    if (File.Exists(clGlobal.ArquivoOriginalSDI))
                    {
                        ArquivoTemporario = clGlobal.ArquivoOriginalSDI.Substring(0, clGlobal.ArquivoOriginalSDI.Length - 4) + "_";
                        ArquivoTemporario += clGlobal.ArquivoOriginalSDI.Substring(clGlobal.ArquivoOriginalSDI.Length - 4, 4);
                        File.Copy(clGlobal.ArquivoOriginalSDI, ArquivoTemporario);
                    }
                    
                    FileStream file = new FileStream(ArquivoTemporario, FileMode.Open);

                    using (BinaryWriter writer = new BinaryWriter(file))
                    {
                        writer.BaseStream.Seek(0x7800, SeekOrigin.Begin);
                        writer.Write(BufferIU, 0, 5);
                    }

                    if (File.Exists(ArquivoTemporario))
                    {
                        File.Delete(clGlobal.ArquivoOriginalSDI);
                        File.Copy(ArquivoTemporario, clGlobal.ArquivoOriginalSDI);
                        File.Delete(ArquivoTemporario);
                    }

                    tbNroSerie.Text = "";

                    clGlobal.MessageText = "Sucesso na gravação do arquivo binário.";
                    Variaveis_Globais.GravouIU = true;
                }
                catch (Exception error)
                {
                    clGlobal.MessageText = "Erro no gravação do arquivo binário.";
                }
                FormMensagem.Width = clGlobal.MessageText.Length * 12 + 10;
                FormMensagem.Visible = true;
                FormMensagem.BringToFront();
                FormMensagem.Refresh();
                System.Threading.Thread.Sleep(2000);
                FormMensagem.Visible = false;
            }
        }

        private void portaSerialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfiguracao FormPortaSerial = new FormConfiguracao();

            FormPortaSerial.ShowDialog();             
        }

        private void tbIU_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private bool PesquisaProduto(object sender, EventArgs e)
        {
            FormProgressBar FormPercentual = new FormProgressBar();

            MySqlConnection conexao = null;

            MySqlCommand comandoSQL = null;
            MySqlDataAdapter adaptador = null;
            DataSet dataset = null;

            MySqlCommand comandoSQLProdutos = null;
            MySqlDataAdapter adaptadorProdutos = null;
            DataSet datasetProdutos = null;

            MySqlCommand comandoSQLModelos = null;
            MySqlDataAdapter adaptadorModelos = null;
            DataSet datasetModelos = null;

            String StrComando = "";
            String StrOrdemProducao = "";

            Variaveis_Globais.stProdutos.LeituraCorreta = false;

            if ((tbNroSerie.Text != "") && (tbNroSerie.Text.Length >= 11) && (tbNroSerie.Text.Length <= 20))
            {
                try
                {
                    if (Variaveis_Globais.Servidor == true)
                    {
                        conexao = new MySqlConnection(Constants.STRING_CONEXAO);
                    }
                    else
                    {
                        conexao = new MySqlConnection(Constants.STRING_CONEXAO_REMOTA);
                    }

                    if (conexao.State == ConnectionState.Closed)
                    {
                        conexao.Open();
                    }

                    // *************************************
                    // ***** Procura a Ordem Produção ******
                    // *************************************
                    StrOrdemProducao = tbNroSerie.Text.Substring(0, 6);

                    StrComando = string.Format("Select * from `" + Constants.DATABASE + "`.`SM_OrdemProducao` where SM_OP_Numero = '" + StrOrdemProducao + "';");
                    comandoSQL = conexao.CreateCommand();
                    comandoSQL.CommandText = StrComando;

                    adaptador = new MySqlDataAdapter(comandoSQL);
                    dataset = new DataSet();
                    adaptador.Fill(dataset);

                    if ((dataset.Tables.Count == 1) && (dataset.Tables[0].Rows.Count == 1))
                    {
                        Variaveis_Globais.stDadosOrdemProducao.Id = int.Parse(dataset.Tables[0].Rows[0]["SM_OP_Id"].ToString());
                        Variaveis_Globais.stDadosOrdemProducao.QtdItems = int.Parse(dataset.Tables[0].Rows[0]["SM_OP_Quantidade"].ToString());
                        Variaveis_Globais.stDadosOrdemProducao.CodModelo = int.Parse(dataset.Tables[0].Rows[0]["SM_OP_CodModelo"].ToString());
                        Variaveis_Globais.stDadosOrdemProducao.Numero = dataset.Tables[0].Rows[0]["SM_OP_Numero"].ToString();
                    }
                    else
                    {
                        // Erro ao localizar Ordem de Produção
                        EscreveMensagem("Erro", "Ordem de Produção não localizada. ", true, 1000);
                        return false;
                    }

                    dataset.Dispose();
                    adaptador.Dispose();
                    comandoSQL.Dispose();

                    // ***************************
                    // ***** Procura Modelo ******
                    // ***************************
                    StrComando = string.Format("Select * from `" + Constants.DATABASE + "`.`SM_Modelos` where SM_MD_Codigo = '" + Variaveis_Globais.stDadosOrdemProducao.CodModelo.ToString() + "';");
                    comandoSQLModelos = conexao.CreateCommand();
                    comandoSQLModelos.CommandText = StrComando;

                    adaptadorModelos = new MySqlDataAdapter(comandoSQLModelos);
                    datasetModelos = new DataSet();
                    adaptadorModelos.Fill(datasetModelos);

                    if ((datasetModelos.Tables.Count == 1) && (datasetModelos.Tables[0].Rows.Count == 1))
                    {
                        Variaveis_Globais.stDadosModelo.Id = int.Parse(datasetModelos.Tables[0].Rows[0]["SM_MD_Id"].ToString());
                        Variaveis_Globais.stDadosModelo.Nome = datasetModelos.Tables[0].Rows[0]["SM_MD_Nome"].ToString();
                        Variaveis_Globais.stDadosModelo.Descricao = datasetModelos.Tables[0].Rows[0]["SM_MD_Descricao"].ToString();
                        Variaveis_Globais.stDadosModelo.Classe = datasetModelos.Tables[0].Rows[0]["SM_MD_Classe"].ToString();
                        Variaveis_Globais.stDadosModelo.FrequenciaNominal = byte.Parse(datasetModelos.Tables[0].Rows[0]["SM_MD_FreqNominal"].ToString());
                        Variaveis_Globais.stDadosModelo.Nominal = datasetModelos.Tables[0].Rows[0]["SM_MD_Nominal"].ToString();
                        Variaveis_Globais.stDadosModelo.Maxima = datasetModelos.Tables[0].Rows[0]["SM_MD_Maxima"].ToString();
                        Variaveis_Globais.stDadosModelo.TensaoNominal1 = int.Parse(datasetModelos.Tables[0].Rows[0]["SM_MD_TenNominal1"].ToString());
                        Variaveis_Globais.stDadosModelo.TensaoNominal2 = int.Parse(datasetModelos.Tables[0].Rows[0]["SM_MD_TenNominal2"].ToString());
                        Variaveis_Globais.stDadosModelo.KhExatidao = datasetModelos.Tables[0].Rows[0]["SM_MD_KhExatidao"].ToString();
                        Variaveis_Globais.stDadosModelo.KhModelo = datasetModelos.Tables[0].Rows[0]["SM_MD_KhModelo"].ToString();
                    }
                    else
                    {
                        // Erro ao localizar modelo
                        EscreveMensagem("Erro", "Modelo de equipamento não localizado. ", true, 1000);
                        return false;
                    }

                    datasetModelos.Dispose();
                    adaptadorModelos.Dispose();
                    comandoSQLModelos.Dispose();

                    // ******************************
                    // ***** Procura o produto ******
                    // ******************************
                    Variaveis_Globais.stProdutos.Id = 0;

                    StrComando = string.Format("Select * from `" + Constants.DATABASE + "`.`SM_Produtos` where SM_PD_NroSerie = '" + tbNroSerie.Text + "';");
                    comandoSQLProdutos = conexao.CreateCommand();
                    comandoSQLProdutos.CommandText = StrComando;

                    adaptadorProdutos = new MySqlDataAdapter(comandoSQLProdutos);
                    datasetProdutos = new DataSet();
                    adaptadorProdutos.Fill(datasetProdutos);

                    if ((datasetProdutos.Tables.Count == 1) && (datasetProdutos.Tables[0].Rows.Count == 1))
                    {
                        // Achou o Produto
                        Variaveis_Globais.stProdutos.Id = int.Parse(datasetProdutos.Tables[0].Rows[0]["SM_PD_Id"].ToString());
                        if (Variaveis_Globais.stProdutos.Id == 0)
                        {
                            EscreveMensagem("Erro", "Produto não encontrado.", true, 1000);
                            adaptadorProdutos.Dispose();
                            comandoSQLProdutos.Dispose();
                            datasetProdutos.Dispose();
                            conexao.Close();
                            return false;
                        }

                        if (bool.Parse(datasetProdutos.Tables[0].Rows[0]["SM_PD_CasModulo"].ToString()))
                        {
                            Variaveis_Globais.stProdutos.CasModulo = 1;
                        }
                        else
                        {
                            Variaveis_Globais.stProdutos.CasModulo = 0;
                        }

                        if (Variaveis_Globais.stProdutos.CasModulo == 0)
                        {
                            EscreveMensagem("Erro", "Produto não passou na etapa anterior.", true, 1000);
                            tbNroSerie.Text = "";
                            adaptadorProdutos.Dispose();
                            comandoSQLProdutos.Dispose();
                            datasetProdutos.Dispose();
                            conexao.Close();
                            return false;
                        }

                        if (datasetProdutos.Tables[0].Rows[0]["SM_PD_NroSerie"] != null)
                        {
                            Variaveis_Globais.stProdutos.NroSerie = datasetProdutos.Tables[0].Rows[0]["SM_PD_NroSerie"].ToString();
                        }
                        else
                        {
                            Variaveis_Globais.stProdutos.NroSerie = "";
                        }

                        if (datasetProdutos.Tables[0].Rows[0]["SM_PD_NroIUPainel"] != null)
                        {
                            Variaveis_Globais.stProdutos.NroIUPainel = datasetProdutos.Tables[0].Rows[0]["SM_PD_NroIUPainel"].ToString();
                        }
                        else
                        {
                            Variaveis_Globais.stProdutos.NroIUPainel = "";
                        }

                        if (datasetProdutos.Tables[0].Rows[0]["SM_PD_NroLote"] != null)
                        {
                            Variaveis_Globais.stProdutos.NroLote = int.Parse(datasetProdutos.Tables[0].Rows[0]["SM_PD_NroLote"].ToString());
                        }
                        else
                        {
                            Variaveis_Globais.stProdutos.NroLote = 0;
                        }

                        if (datasetProdutos.Tables[0].Rows[0]["SM_PD_NroCliente"] != null)
                        {
                            Variaveis_Globais.stProdutos.NroCliente = datasetProdutos.Tables[0].Rows[0]["SM_PD_NroCliente"].ToString();
                        }
                        else
                        {
                            Variaveis_Globais.stProdutos.NroCliente = "";
                        }

                        if (datasetProdutos.Tables[0].Rows[0]["SM_PD_StrCliente"] != null)
                        {
                            Variaveis_Globais.stProdutos.StrCliente = datasetProdutos.Tables[0].Rows[0]["SM_PD_StrCliente"].ToString();
                        }
                        else
                        {
                            Variaveis_Globais.stProdutos.StrCliente = "";
                        }

                        if (datasetProdutos.Tables[0].Rows[0]["SM_PD_NroMemoria"] != null)
                        {
                            Variaveis_Globais.stProdutos.NroMemoria = datasetProdutos.Tables[0].Rows[0]["SM_PD_NroMemoria"].ToString();
                        }
                        else
                        {
                            Variaveis_Globais.stProdutos.NroMemoria = "";
                        }

                        Variaveis_Globais.stProdutos.LeituraCorreta = true;

                        datasetProdutos.Dispose();
                        adaptadorProdutos.Dispose();
                        comandoSQLProdutos.Dispose();
                    }
                    else
                    {
                        // Erro ao localizar produto
                        EscreveMensagem("Erro", "Produto não localizado. ", true, 1000);
                        return false;
                    }
                }
                catch (InvalidCastException)
                {
                    // Erro na escrita do banco
                    EscreveMensagem("Erro", "Erro ao numerar cliente. ", true, 1000);
                    return false;
                }
            }
            
            return true;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            clGlobal.PastaExecutavel = Directory.GetCurrentDirectory();

            // Cria ou abre o SMIntegrity.ini
            string PastaAtual = Directory.GetCurrentDirectory();

            if (!(System.IO.Directory.Exists(PastaAtual + "\\Arquivos Binarios\\")))
            {
                System.IO.Directory.CreateDirectory(PastaAtual + "\\Arquivos Binarios\\");
            }

            if (!(System.IO.Directory.Exists(PastaAtual + "\\Relatórios\\")))
            {
                System.IO.Directory.CreateDirectory(PastaAtual + "\\Relatórios\\");
            }

            var MyIni = new IniFile(clGlobal.STR_DiretorioParaArquivosIni + "SM DI Recorder.ini");

            if (!MyIni.KeyExists("Arquivo Original DI", "Config"))
            {
                MyIni.Write("Arquivo Original DI", PastaAtual + "\\Arquivos Binarios\\", "Config");
            }
            else
            {
                clGlobal.ArquivoOriginalSDI = MyIni.Read("Arquivo Original DI", "Config");
                clGlobal.NomeArquivoOriginalSDI = Path.GetFileName(clGlobal.ArquivoOriginalSDI);
                clGlobal.DiretorioArquivoOriginalSDI = Path.GetDirectoryName(clGlobal.ArquivoOriginalSDI);
            }

            if (!MyIni.KeyExists("Log", "Path"))
            {
                MyIni.Write("Log", PastaAtual + "\\Relatórios\\", "Path");
                clGlobal.PastaDestinoRelatorios = PastaAtual + "\\Relatórios\\";
            }
            else
            {
                clGlobal.PastaDestinoRelatorios = MyIni.Read("Log", "Path");
            }

            if (!MyIni.KeyExists("Bin Files", "Path"))
            {
                MyIni.Write("Bin Files", PastaAtual + "\\Arquivos Binarios\\", "Path");
                clGlobal.PastaDestinoArquivosBinarios = PastaAtual + "\\Arquivos Binarios\\";
            }
            else
            {
                clGlobal.PastaDestinoArquivosBinarios = MyIni.Read("Bin Files", "Path");
            }

            try
            {
                clGlobal.NomeArquivoIni = "Config.ini";

                // Caso não exista o diretório de Serviços atendidos, o cria
                if (!(System.IO.Directory.Exists(clGlobal.STR_DiretorioParaArquivosIni)))
                {
                    System.IO.Directory.CreateDirectory(clGlobal.STR_DiretorioParaArquivosIni);
                }

                if (System.IO.File.Exists(@clGlobal.STR_DiretorioParaArquivosIni + clGlobal.NomeArquivoIni))
                {
                    // Ler configurações de comunicação
                    LeConfigComunicacao();
                }
                else
                {
                    // Não exsite arquivo, deve ser criado
                    clGlobal.SaidaIni = System.IO.File.Open(clGlobal.STR_DiretorioParaArquivosIni + clGlobal.NomeArquivoIni, System.IO.FileMode.Create);
                    clGlobal.ArquivoIni = new System.IO.StreamWriter(clGlobal.SaidaIni);
                    clGlobal.ArquivoIni.WriteLine("[Protocolo]");
                    clGlobal.ArquivoIni.WriteLine("Multiponto = 1");
                    clGlobal.ArquivoIni.WriteLine("");
                    clGlobal.ArquivoIni.WriteLine("[COMM]");
                    clGlobal.ArquivoIni.WriteLine("HW =");
                    clGlobal.ArquivoIni.WriteLine("");
                    clGlobal.ArquivoIni.WriteLine("[Serial]");
                    clGlobal.ArquivoIni.WriteLine("Porta =");
                    clGlobal.ArquivoIni.Close();
                    clGlobal.SaidaIni.Close();
                }
            }
            catch (Exception erro)
            {
                // Mensagem de erro ao tentar abrir ou criar arquivo ini
                //MessageBox.Show("Erro ao abrir/criar arquivo ini : " + erro.Message, "Erro");
                clGlobal.AtualizaMsgCaixaTexto("Erro ao abrir/criar arquivo ini.");
            }

            IPHostEntry ipHost = null;

            TcpListener server = new TcpListener(IPAddress.Any, 1000);

            this.Text = "SMDIRecorder - Ver. " + ProductVersion;

            PingReply oPing;

            FormMessage FormMensagem = new FormMessage();

            // Testa se encontra o Servidor;
            clGlobal.MessageText = "Verificando Rede... ";
            clGlobal.MessageWarning = "Aviso";
            FormMensagem.StartPosition = FormStartPosition.CenterScreen;
            FormMensagem.Width = clGlobal.MessageText.Length * 15 + 15;
            FormMensagem.Left = (Screen.PrimaryScreen.Bounds.Width - FormMensagem.Width) / 2;
            FormMensagem.Visible = true;
            FormMensagem.Refresh();
            for (int x = 0; x < 2; x++)
            {
                System.Threading.Thread.Sleep(250);
                oPing = new Ping().Send("192.168.25.3", 5000);

                if (oPing.Status == IPStatus.Success)
                {
                    // Encontrou servidor
                    // Falta conferir o nome
                    try
                    {
                        ipHost = Dns.GetHostEntry("192.168.25.3");
                    }
                    catch
                    {
                        // Não encontrou Host.
                        Variaveis_Globais.Servidor = false;
                        break;
                    }

                    string hostNome = ipHost.HostName;
                    if ((hostNome.Contains("PRODSERV")) || (hostNome.Contains("mgers2016")))
                    {
                        // Encontrou o servidor
                        Variaveis_Globais.Servidor = true;
                        //EscreveMensagem("Aviso", "Rede Interna SMP. ", true, 1000);
                        break;
                    }
                    else
                    {
                        // Não encontrou o nome do servidor
                        Variaveis_Globais.Servidor = false;
                        //EscreveMensagem("Aviso", "Rede Externa SMP - starmeasure.ddns.net. ", true, 1000);
                    }
                }
                else
                {
                    // Não encontrou o ip = 192.168.0.29
                    Variaveis_Globais.Servidor = false;
                    //EscreveMensagem("Aviso", "Rede Externa SMP - starmeasure.ddns.net. ", true, 1000);
                }
            }
            FormMensagem.Visible = false;

            if (Variaveis_Globais.Servidor == true)
            {
                EscreveMensagem("Aviso", "Rede Interna SMP. ", true, 2000);
                FormMensagem.Refresh();
            }
            else
            {
                EscreveMensagem("Aviso", "Rede Externa SMP - starmeasure.ddns.net. ", true, 2000);
                FormMensagem.Refresh();
            }
        }
        private void LeConfigComunicacao()
        {
            clGlobal.EntradaIni = System.IO.File.ReadAllLines(clGlobal.STR_DiretorioParaArquivosIni + clGlobal.NomeArquivoIni);

            if (clGlobal.EntradaIni.Length > 0)
            {
                // Arquivo contem linhas

                if (clGlobal.EntradaIni[1].Length > 12)
                {
                    if (clGlobal.EntradaIni[0] == "[Protocolo]")
                    {
                        // Linha Protocolo Existe
                        if (clGlobal.EntradaIni[1].Substring(13) == "1")
                        {
                            clGlobal.BOL_ProtocoloMultiponto = true;
                        }
                        else if (clGlobal.EntradaIni[1].Substring(13) == "0")
                        {
                            clGlobal.BOL_ProtocoloMultiponto = false;
                        }
                    }
                }
                else
                {
                    // Erro na linha
                    clGlobal.BOL_ProtocoloMultiponto = false;
                }
                clGlobal.BOL_ProtocoloCodi = !clGlobal.BOL_ProtocoloMultiponto;

                if (clGlobal.EntradaIni.Length > 3)
                {
                    // Arquivo tem mais de 3 linhas
                    if (clGlobal.EntradaIni[4].Length > 5)
                    {
                        if (clGlobal.EntradaIni[3] == "[COMM]")
                        {
                            // HW Existe
                            clGlobal.HW = clGlobal.EntradaIni[4].Substring(5, (clGlobal.EntradaIni[4].Length - 5));
                            if (clGlobal.HW == "Serial")
                            {
                                clGlobal.ENUM_TipoHW = clGlobal.enumTipoHW.eSerial;
                                clGlobal.eSerialRS485 = false;
                            }
                            else if (clGlobal.HW == "Bluetooth")
                            {
                                clGlobal.ENUM_TipoHW = clGlobal.enumTipoHW.eBluetooth;
                            }
                            else if (clGlobal.HW == "Ethernet")
                            {
                                clGlobal.ENUM_TipoHW = clGlobal.enumTipoHW.eEthernet;
                            }
                            else if (clGlobal.HW == "RS485")
                            {
                                clGlobal.ENUM_TipoHW = clGlobal.enumTipoHW.eSerial;
                                clGlobal.eSerialRS485 = true;
                            }
                            else
                            {
                                clGlobal.ENUM_TipoHW = clGlobal.enumTipoHW.eNenhum;
                            }
                        }
                    }
                    else
                    {
                        clGlobal.HW = "NULL";
                    }
                }

                if (clGlobal.EntradaIni.Length > 6)
                {
                    // Arquivo tem mais de 3 linhas
                    if (clGlobal.EntradaIni[7].Length > 8)
                    {
                        if (clGlobal.EntradaIni[6] == "[Serial]")
                        {
                            // Linha Serial Existe
                            clGlobal.PortaSerialEscolhida = clGlobal.EntradaIni[7].Substring(8);
                        }
                    }
                    else
                    {
                        clGlobal.PortaSerialEscolhida = "NULL";
                    }
                }
            }
            else
            {
                clGlobal.BOL_ProtocoloMultiponto = false;
                clGlobal.PortaSerialEscolhida = "NULL";
            }
            clGlobal.BOL_ProtocoloCodi = !clGlobal.BOL_ProtocoloMultiponto;
        }

        private void seleçãoDeArquivoBinárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ArquivoOriginal;

            ArquivoOriginal = new OpenFileDialog();

            FormMessage FormMensagem = new FormMessage();

            ArquivoOriginal.Filter = "Arquivo Binario|*.bin";
            ArquivoOriginal.Title = "Selecione um arquivo binario.";
            ArquivoOriginal.InitialDirectory = Directory.GetCurrentDirectory() + "\\Arquivos Binarios\\";

            if (ArquivoOriginal.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clGlobal.ArquivoOriginalSDI = ArquivoOriginal.FileName;
                clGlobal.NomeArquivoOriginalSDI = Path.GetFileName(ArquivoOriginal.FileName);
                clGlobal.DiretorioArquivoOriginalSDI = Path.GetDirectoryName(ArquivoOriginal.FileName);

                // Cria ou abre o SMIntegrity.ini
                var MyIni = new IniFile(clGlobal.STR_DiretorioParaArquivosIni + "SM DI Recorder.ini");

                MyIni.Write("Arquivo Original DI", clGlobal.ArquivoOriginalSDI, "Config");

                clGlobal.BOL_ArquivoBinarioSelecionado = true;

                clGlobal.MessageText = "Arquivo .ini atualizado.";
                clGlobal.MessageWarning = "Aviso";

                FormMensagem.Visible = true;
                FormMensagem.Show();
                FormMensagem.BringToFront();
                FormMensagem.Refresh();
                System.Threading.Thread.Sleep(2500);
                FormMensagem.Visible = false;
            }

            ArquivoOriginal.Dispose();
        }

        private void definiçãoDeDiretórioDeRelatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog PastaDestino;
            string NomePastaDestino = "";

            PastaDestino = new FolderBrowserDialog();

            PastaDestino.SelectedPath = System.IO.Directory.GetCurrentDirectory();

            if (PastaDestino.ShowDialog() == DialogResult.OK)
            {
                NomePastaDestino = PastaDestino.SelectedPath;
            }

            clGlobal.PastaDestinoRelatorios = NomePastaDestino;

            // Cria ou abre o SMIntegrity.ini
            var MyIni = new IniFile(clGlobal.STR_DiretorioParaArquivosIni + "SM DI Recorder.ini");

            MyIni.Write("Log", clGlobal.PastaDestinoRelatorios, "Path");
        }

        private void definiçãoDeDiretórioDeArquivosBináriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog PastaDestino;
            string NomePastaDestino = "";

            PastaDestino = new FolderBrowserDialog();

            PastaDestino.SelectedPath = System.IO.Directory.GetCurrentDirectory();

            if (PastaDestino.ShowDialog() == DialogResult.OK)
            {
                NomePastaDestino = PastaDestino.SelectedPath;
            }

            clGlobal.PastaDestinoArquivosBinarios = NomePastaDestino;

            // Cria ou abre o SMIntegrity.ini
            var MyIni = new IniFile(clGlobal.STR_DiretorioParaArquivosIni + "SM DI Recorder.ini");

            MyIni.Write("Bin Files", clGlobal.PastaDestinoArquivosBinarios, "Path");
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox FormSobre = new AboutBox();
            FormSobre.ShowDialog();
        }

        private void gravarDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] BufferIULido = new byte[5];
            String IULido = "";

            EscreveMensagem("Aviso", "Gravando DI pelo JLink...", true, 2000);
            System.Diagnostics.Process.Start("load_DI.bat");

            System.Threading.Thread.Sleep(5000);

            EscreveMensagem("Aviso", "Lendo DI pelo JLink...", true, 2000);
            System.Diagnostics.Process.Start("read_DI.bat");

            EscreveMensagem("Aviso", "Aguardando finalizar leitura...", true, 5000);
            System.Threading.Thread.Sleep(5000);

            try
            {
                String ArquivoTemporario = "";

                ArquivoTemporario = clGlobal.PastaDestinoArquivosBinarios + "\\SDI.bin";
                if (File.Exists(ArquivoTemporario))
                {
                    FileStream file = new FileStream(ArquivoTemporario, FileMode.Open);

                    using (BinaryReader reader = new BinaryReader(file))
                    {
                        reader.BaseStream.Seek(0x7800, SeekOrigin.Begin);
                        reader.Read(BufferIULido, 0, 5);
                        IULido = BufferIULido[4].ToString("X" + 2) + "-";
                        IULido += BufferIULido[3].ToString("X" + 2);
                        IULido += BufferIULido[2].ToString("X" + 2);
                        IULido += BufferIULido[1].ToString("X" + 2);
                        IULido += BufferIULido[0].ToString("X" + 2);
                    }

                    if(IULido == Variaveis_Globais.stProdutos.NroIUPainel)
                    {
                        // Gravação do DI realizada com sucesso
                        EscreveMensagem("Aviso", "Gravação do DI realizada com sucesso.", true, 4000);
                    }
                    else
                    {
                        // Erro na gravação do DI
                        EscreveMensagem("Erro", "Erro na gravação do DI.", true, 4000);
                    }

                    File.Delete(ArquivoTemporario);
                }
            }
            catch (Exception error)
            {
                EscreveMensagem("Erro", "Erro na gravação do DI.", true, 4000);
            }
        }

        private void tbNroSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)Keys.Enter)
            {
                PesquisarNroSM(sender, e);
            }
        }

        private void PesquisarNroSM(object sender, EventArgs e)
        {
            bool bEncontrouProduto = false;

            String NroSerieAux = tbNroSerie.Text;
            bool bCarregouNroSerie = false;

            EscreveMensagem("Aviso", "Pesquisando Produto...", true, 1000);

            bEncontrouProduto = PesquisaProduto(sender, e);

            if ((Variaveis_Globais.stProdutos.LeituraCorreta)&&(bEncontrouProduto))
            {
                bCarregouNroSerie = true;
                // Gravar IU no arquivo binário
                gravarIUToolStripMenuItem_Click(sender, e);

                // Gravar DI
                if (Variaveis_Globais.GravouIU)
                {
                    gravarDIToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void EscreveMensagem(string Aviso, string Mensagem, bool Apagar, int Tempo)
        {
            FormMessage FormMensagem = new FormMessage();

            clGlobal.MessageText = Mensagem;
            clGlobal.MessageWarning = Aviso;
            FormMensagem.StartPosition = FormStartPosition.CenterScreen;
            FormMensagem.Width = clGlobal.MessageText.Length * 16 + 15;
            FormMensagem.Left = (clGlobal.LarguraTela - FormMensagem.Width) / 2;
            FormMensagem.Visible = true;
            FormMensagem.Refresh();
            FormMensagem.BringToFront();
            System.Threading.Thread.Sleep(Tempo);
            if (Apagar)
            {
                FormMensagem.Visible = false;
            }
        }
    }
}
