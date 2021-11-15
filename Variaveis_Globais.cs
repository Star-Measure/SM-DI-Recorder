using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMDIRecorder
{
    class Variaveis_Globais
    {
        #region Atributos
        private static string vCliente;
        private static string vCidade;
        private static string vFase;
        private static string vTipo_Servico;
        private static string vClasse;
        private static string vGrupo;
        private static string vPosicao;
        private static string vUsuario;
        private static string vPerfilUsuario;
        private static string vUrl;
        private static string vMessageText;
        private static string vMessageWarning;
        private static string vMessageWarningPercentual;

        private static bool bLoginError;
        private static bool bFecharLogin;
        private static bool bServidor;
        private static bool bSaidasPerifericas;
        private static bool bGravouIU;

        private static int vAltInicialMenuPrincipal;
        private static int vLarguraTela;
        private static int vLoginCodigoUsuario;
        private static int vStsDiagnose;
        
        private static double vPercentual;

        public static List<String> ListaProdutos;

        public struct stDadosCliente
        {
            public static int Id;
            public static string CNPJ;
            public static string RazaoSocial;
            public static string Endereco;
            public static string Cidade;
            public static string Estado;
            public static string Telefone;
            public static bool LeituraCorreta;
        }

        public struct stDadosModelo
        {
            public static int Id;
            public static int Codigo;
            public static string Revisao;
            public static string Nome;
            public static string Descricao;
            public static byte NumeroFases;
            public static byte NumeroFios;
            public static byte NumeroElementos;
            public static byte NumeroMostradores;
            public static string Nominal;
            public static string Maxima;
            public static string Classe;
            public static byte FrequenciaNominal;
            public static string KhModelo;
            public static string KhExatidao;
            public static int TensaoNominal1;
            public static int TensaoNominal2;
            public static bool QuatroQuadrante;
            public static bool TemMM;
            public static bool TemIU;
            public static bool TemMostrador;
            public static bool TemRadio;
            public static bool TemBLE;
            public static bool TemPortaOtica;
            public static bool TemPortaAux;
            public static bool TemCorteReligue;
            public static bool TemMultiponto;
            public static bool TemDLMS;
            public static bool TemINMETRO;
            public static bool TemBurnIn;
            public static bool TemTecla;
            public static bool TemBateria;
            public static bool TemDiagnose;
            public static bool TemTensaoAplicada;
            public static bool Medidor;
            public static string TemMarcaLaser;
            public static byte NumeroLacres;
            public static string Modulo1;
            public static string Modulo2;
            public static string Modulo3;
            public static byte PrefixoIU;
            public static bool LeituraCorreta;
        }

        private static string vDatabase = Constants.DATABASE;
        string[] comunicado;

        public static string Database
        {
            get { return vDatabase; }
            set { vDatabase = value; }
        }


        public static string user = "";
        public struct stDadosOrdemProducao
        {
            public static int Id;
            public static String Numero;
            public static int QtdItems;
            public static DateTime Data;
            public static String NroPV;
            public static int CodModelo;
            public static byte TensaoExat1;
            public static byte TensaoExat2;
            public static string MarcaLaser;
            public static string RotaFirmware;
            public static string RotaProgMed;
            public static string RotaProgCom;
            public static string RotaParametros;
            public static byte QtdPorCaixa;
            public static byte CaixaPorPallet;
            public static string PedCliente;
            public static string CodMaterial;
            public static bool NumeracaoCliente;
            public static int MatriculaUsuario;
            public static bool LeituraCorreta;
        }

        public struct stProdutos
        {
            public static int Id;
            public static String NroSerie;
            public static byte NroEstacao;
            public static int NroIU;
            public static String NroIUPainel;
            public static int NroLote;
            public static byte NroAmostra;
            public static String NroCliente;
            public static String StrCliente;
            public static String NroMemoria;
            public static String NroModulo1;
            public static String NroModulo2;
            public static String NroModulo3;
            public static byte CasModulo;
            public static DateTime DataHoraCM;
            public static byte StsDiagnose;        
            public static byte StsRadio;
            public static byte StsBle;
            public static byte StsGeracao;
            public static byte StsExatidao;
            public static byte StsTenAplicada;
            public static byte StsSaidas;
            public static byte StsBurnIn;
            public static byte StsTenInferior;
            public static byte StsPartida;
            public static byte StsMostrador;
            public static byte StsBateria;
            public static byte StsTecla;
            public static byte StsMultiponto;
            public static byte StsCorteReligue;
            public static byte StsMarcaLaser;
            public static byte NroCelular;
            public static String NroLacre1;
            public static String NroLacre2;
            public static String NroLacre3;
            public static String NroLacre4;
            public static bool FuncionalFinalOK;
            public static bool InspFinalOK;
            public static DateTime DataHoraIF;
            public static int MatUsuIF;
            public static bool LeituraCorreta;
        }

        public struct stFuncionalFinal
        {
            public static int Id;
            public static String NroSerie;
            public static byte NroEstacao;
            public static byte StsRadio;
            public static byte StsBle;
            public static byte StsPortaOptica;
            public static byte StsPortaAux;
            public static byte StsCorteReligue;
            public static byte StsMultiponto;
            public static byte StsDlms;
            public static string VersaoMedidor;
            public static string VersaoPO;
            public static string VersaoBoot;
            public static byte Local;
            public static string Temperatura;
            public static DateTime Data;
            public static bool EnsaioOK;
            public static int NroClienteOK;
            public static int MatriculaUsuario;
            public static bool LeituraCorreta;
        }
        #endregion

        #region Propriedade

        public static bool Servidor
        {
            get { return bServidor; }
            set { bServidor = value; }
        }

        public static bool LoginError
        {
            get { return bLoginError; }
            set { bLoginError = value; }
        }

        public static bool FecharLogin
        {
            get { return bFecharLogin; }
            set { bFecharLogin = value; }
        }

        public static bool SaidasPerifericas
        {
            get { return bSaidasPerifericas; }
            set { bSaidasPerifericas = value; }
        }

        public static bool GravouIU
        {
            get { return bGravouIU; }
            set { bGravouIU = value; }
        }

        public static int AltIncialMenuPrincipal
        {
            get { return vAltInicialMenuPrincipal; }
            set { vAltInicialMenuPrincipal = value; }
        }

        public static int StsDiagnose
        {
            get { return vStsDiagnose; }
            set { vStsDiagnose = value; }
        }

        public static int LarguraTela
        {
            get { return vLarguraTela; }
            set { vLarguraTela = value; }
        }

        public static int LoginCodUsuario
        {
            get { return vLoginCodigoUsuario; }
            set { vLoginCodigoUsuario = value; }
        }

        public static double ValorPercentual
        {
            get { return vPercentual; }
            set { vPercentual = value; }
        }

        public static string MessageText
        {
            get { return vMessageText; }
            set { vMessageText = value; }
        }

        public static string MessageWarning
        {
            get { return vMessageWarning; }
            set { vMessageWarning = value; }
        }

        public static string MessageWarningPercentual
        {
            get { return vMessageWarningPercentual; }
            set { vMessageWarningPercentual = value; }
        }

        public static string Cliente
        {
            get { return vCliente; }
            set { vCliente = value; }
        }

        public static string Cidade
        {
            get { return vCidade; }
            set { vCidade = value; }
        }
        public static string Fase
        {
            get { return vFase; }
            set { vFase = value; }
        }
        public static string Tipo_Servico
        {
            get { return vTipo_Servico; }
            set { vTipo_Servico = value; }
        }
        public static string Classe
        {
            get { return vClasse; }
            set { vClasse = value; }
        }
        public static string Posicao
        {
            get { return vPosicao; }
            set { vPosicao = value; }
        }
        public static string Grupo
        {
            get { return vGrupo; }
            set { vGrupo = value; }
        }

        public static string Usuario
        {
            get { return vUsuario; }
            set { vUsuario = value; }
        }

        public static string PerfilUsuario
        {
            get { return vPerfilUsuario; }
            set { vPerfilUsuario = value; }
        }

        public static string Url
        {
            get { return vUrl; }
            set { vUrl = value; }
        }
        #endregion
    }
}