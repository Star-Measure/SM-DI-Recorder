namespace SMDIRecorder
{
    static class Constants
    {
        //############# - VERSÃO DO SOFTWARE - #############
        public const string SOFTWARE_VERSION = "V1.0.0.4";

        // Constantes para acesso ao Banco de Dados da aplicação
        public const string ENDERECO_SERVIDOR   = "PRODSERV";
        public const string ENDERECO_SERVIDOR_REMOTO = "starmeasure.ddns.net";
        public const string PORTASERVIDOR       = "1234";
        public const string DATABASE            = "smp";
        public const string USUARIO_DATABASE    = "SMProduction";
        public const string SENHA_DATABASE      = "SMP@xyzmge123";
        public const string STRING_CONEXAO = ("server=" + ENDERECO_SERVIDOR +
                                                    "; port=" + PORTASERVIDOR +
                                                    "; User Id=" + USUARIO_DATABASE +
                                                    "; database=" + DATABASE +
                                                    "; password=" + SENHA_DATABASE);
        public const string STRING_CONEXAO_REMOTA = ("server=" + ENDERECO_SERVIDOR_REMOTO +
                                                    "; port=" + PORTASERVIDOR +
                                                    "; User Id=" + USUARIO_DATABASE +
                                                    "; database=" + DATABASE +
                                                    "; password=" + SENHA_DATABASE);
        public const string QUARTO_QUADRANTE    = "Quarto Quadrante";
        public const string MEMORIA_MASSA       = "Memória de Massa";
        public const string IU                  = "IU";
        public const string MOSTRADOR           = "Mostrador";
        public const string RADIO               = "Rádio";
        public const string BLE                 = "BLE";
        public const string PORTA_OTICA         = "Porta Ótica";
        public const string PORTA_AUXILIAR      = "Porta Auxiliar";
        public const string CORTE_RELIGUE       = "Corte e Religue";
        public const string MULTIPONTO          = "Multiponto";
        public const string DLMS                = "DLMS";
        public const string INMETRO             = "INMETRO";
        public const string BURNIN              = "BurnIn";
        public const string MEDIDOR             = "Medidor";
    }
}
