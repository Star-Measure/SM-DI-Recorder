using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Security.Cryptography;

namespace SMDIRecorder
{
    public class clGlobal
    {
        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceFrequency(out long lpFrequency);

        //Absoluto
        public const Int32 SMBaseProgramSize = 0x4E000;
        public const Int32 SDIProgramaSize = 0x7800;

        public const Int32 ProgramInitPosition = 0x00000;
        //public const Int32 ProgramBufferSize = 0x4D000;
        public const Int32 ProgramBufferSize = 0x4E000;

        //public const Int32 CRCInitPosition = 0x4D000;
        //public const Int32 CRCInitPosition = 0x4DFFC;
        //public const Int32 CRCBufferSize = 0x1000;
        //public const Int32 CRCBufferSize = 0x04;

        public const Int32 ParameterInitPosition = 0x4E000;
        public const Int32 ParameterBufferSize = 0x1000;

        public const Int32 ConfigInitPosition = 0x4F000;
        public const Int32 ConfigBufferSize = 0x1000;

        public const Int32 LogInitPosition = 0x50000;
        public const Int32 LogBufferSize = 0x30000;

        //Extend
        public const Int32 ExtendBootstrapIni = 0x0000;
        public const Int32 ExtendBootstrapFim = 0x03FF;

        public const Int32 ExtendProgramIni = 0x05000;
        public const Int32 ExtendProgramFim = 0x3DFFF;

        public const Int32 ExtendLivreIni = 0x40000;
        public const Int32 ExtendLivreFim = 0x7FFFF;

        public const Int32 ExtendAreaExtIni = 0x00000;
        public const Int32 ExtendAreaExtFim = 0x38FFF;

        //SCR
        public const Int32 SMSCRProgramSize = 0x7F00;

        public const Int32 ProgramSCRInitPosition = 0x00000;
        public const Int32 ProgramSCRBufferSize = 0x7F00;

        // DI
        public const Int32 ProgramSDIInitPosition = 0x00000;
        public const Int32 ProgramSDIBufferSize = 0x7800; //(0x7BFB + 1);

        //public const Int32 CRCSDIInitPosition = 0x7800; //0x7BFC;
        //public const Int32 CRCSDIBufferSize = 0x04;

        public const Int32 IUSDIInitPosition = 0x7800; //0x7BFC;
        public const Int32 IUSDIBufferSize = 0x400;

        public const Int32 CanalSDIInitPosition = 0x7C00;
        public const Int32 CanalSDIBufferSize = 0x400;

        public const Int32 IUDI_ADDR = 0x7800;
        public const Int32 IUDI_SIZE = 0x400;

        public const Int32 CHANNEL_ADDR = 0x7C00;
        public const Int32 CHANNEL_SIZE = 0x400;

        public const Int32 cte_Numero_Medidores = 35;

        public static SerialPort SerialCom = new SerialPort();

        public const Int32 cte_TamBloco = 256;
        public const int cte_MaxAusente = 2;

        public const Int32 cte_HMAC_KEY_TAMANHO = 64;
        public const Int32 cte_HMAC_HASH_ALEA_TAMANHO = 32;
        public const Int32 cte_HMAC_KEY_HASH_TAMANHO = cte_HMAC_KEY_TAMANHO + cte_HMAC_HASH_ALEA_TAMANHO;

        public const Int32 cte_SENHA_METODO_ABNT = 0;
        public const Int32 cte_SENHA_METODO_MD5 = 1;
        public const Int32 cte_SENHA_METODO_STR = 2;
        public const Int32 cte_SENHA_METODO_HMAC = 3;

        // Definição de tipos de eventos
        public const Int32 cte_COD_EVENTO_CARGA = 0x01;
        public const Int32 cte_COD_EVENTO_QEE = 0x02;
        public const Int32 cte_COD_EVENTO_TRAFO = 0x03;
        public const Int32 cte_COD_EVENTO_FALTA = 0x04;
        public const Int32 cte_COD_EVENTO_OC = 0x05;

        // Definição de Exibição de Interfaces
        public const string cte_INTSW_INDIFINIDO = "Indefinido";
        public const string cte_INTSW_NENHUMA = "Nenhuma";
        public const string cte_INTSW_BLE_RN4871 = "BLE_RN4871";
        public const string cte_INTSW_BLE_1082 = "BLE_EMB1082";
        public const string cte_INTSW_RS232 = "RS232";
        public const string cte_INTSW_RS485 = "RS485";
        public const string cte_INTSW_REMOTA = "Remota";

        // Definição de Exibição de Protocolos
        public const string cte_PROTOCOLO_INDEFINIDO = "Indefinido";
        public const string cte_PROTOCOLO_MULTIPONTO = "Multiponto";
        public const string cte_PROTOCOLO_STARMEASURE = "StarMeasure";
        public const string cte_PROTOCOLO_RTU = "Modbus RTU";
        public const string cte_PROTOCOLO_DLMS = "DLMS";

        // SubCodigos para Carga
        public const Int32 cte_SUBCOD_CARGA_PORTA_OPTICA = 0X00;    // 00 – Porta óptica (interface default)
        public const Int32 cte_SUBCOD_CARGA_JTAG = 0X01;            // 01 – JTAG (na fábrica ou engenharia)
        public const Int32 cte_SUBCOD_CARGA_RESTAURACAO = 0X02;     // 02 – Restauração do backup feita pelo Boot
        public const Int32 cte_SUBCOD_CARGA_VIA_BLE = 0X03;         // 03 – Bluetooth
        public const Int32 cte_SUBCOD_CARGA_VIA_REMOTA = 0X04;      // 04 – Remota Conectada numa Porta Serial
        public const Int32 cte_SUBCOD_CARGA_BACKUP = 0X05;           // 05 – BackUp do PO
        public const Int32 cte_SUBCOD_CARGA_ATUALIZACAO = 0X06;     // 06 – Atualizacao do PO

        // SubCodigos para QEE
        public const Int32 cte_SUBCOD_QEE_VTCD = 0x01;
        public const Int32 cte_SUBCOD_QEE_VTLD = 0x02;
        public const Int32 cte_SUBCOD_QEE_FREQ = 0x03;

        public const Int32 cte_QEE_TIPO_INTE_MOM = 0x00;
        public const Int32 cte_QEE_TIPO_INTE_TEMP = 0x01;
        public const Int32 cte_QEE_TIPO_AFUN_MOM = 0x02;
        public const Int32 cte_QEE_TIPO_AFUN_TEMP = 0x03;
        public const Int32 cte_QEE_TIPO_ELEV_MOM = 0x04;
        public const Int32 cte_QEE_TIPO_ELEV_TEMP = 0x05;

        // Subcodigos para Trafo
        public const Int32 cte_SUBCOD_TRAFO_SOB_CORRENTE = 0x01;
        public const Int32 cte_SUBCOD_TRAFO_SOB_TENSAO = 0x02;
        public const Int32 cte_SUBCOD_TRAFO_SUB_TENSAO = 0x03;
        public const Int32 cte_SUBCOD_TRAFO_SOB_TEMP = 0x04;

        // SubCodigos para Faltas de Energia
        public const Int32 cte_SUBCOD_FALTA_POWER_UP = 0x00;
        public const Int32 cte_SUBCOD_FALTA_BACKUP_MODE = 0x01;
        public const Int32 cte_SUBCOD_FALTA_WD_INTERNO = 0x02;
        public const Int32 cte_SUBCOD_FALTA_SOFT_RESET = 0x03;
        public const Int32 cte_SUBCOD_FALTA_WD_EXTERNO = 0x04;
        public const Int32 cte_SUBCOD_FALTA_NORMAL = 0x08;

        // SubCodigos para Ocorrencias SM
        public const Int32 cte_ID_SENHA_PROX_EXP = 0;
        public const Int32 cte_ID_SENHA_EXP = 1;
        public const Int32 cte_ID_PERIODO_PROT = 2;
        //3 a 7 reservados para carga de programa SM
        public const Int32 cte_ID_REFERENCIA = 8;
        public const Int32 cte_ID_RESET_WD = 9;
        public const Int32 cte_ID_BATERIA_BAIXA = 10;
        public const Int32 cte_ID_SENSOR_PAINEL = 11;
        public const Int32 cte_ID_ESTADO_RELE = 12;
        public const Int32 cte_ID_RESET_EXTERNO = 13;
        public const Int32 cte_ID_SENSOR_BLOCO = 14;
        public const Int32 cte_ID_SENSOR_MAG = 15;
        public const Int32 cte_ID_CRC32_PROG = 16;
        public const Int32 cte_ID_SEM_PARAMETROS = 17;
        public const Int32 cte_ID_SEM_CFGAJUSTE = 18;
        public const Int32 cte_ID_REC_PARAMETROS = 19;
        public const Int32 cte_ID_REC_CFGAJUSTE = 20;
        public const Int32 cte_ID_PERDEU_RTC = 21;
        public const Int32 cte_ID_REC_REGISTRO = 22;
        public const Int32 cte_ID_SEM_AJUSTE_RTC = 23;
        public const Int32 cte_ID_I2C_OUT = 24;
        public const Int32 cte_ID_TIMEOUT_CR = 25;
        public const Int32 cte_ID_FLASH_BUSY = 26;
        public const Int32 cte_ID_TIMEOUT_COM = 27;
        public const Int32 cte_ID_SPI_RF = 28;
        public const Int32 cte_ID_SPI_RTC = 29;
        public const Int32 cte_ID_SPI_FLASH = 30;
        public const Int32 cte_ID_CORRENTE_TCS = 31;
        public const Int32 cte_ID_BALANCO = 32;
        public const Int32 cte_ID_CARGA_SAIDA_NA = 33;
        public const Int32 cte_ID_SENSOR_TEMP_OUT = 34;
        public const Int32 cte_ID_SENSOR_PO = 35;
        public const Int32 cte_ID_SENSOR_UART1 = 36;
        public const Int32 cte_ID_SENSOR_UART2 = 37;
        public const Int32 cte_ID_OC_CNT = 38;

        // Strings das ocorrências
        public static string[] StrOcSM =
        {
            "Senha próxima de expirar\t\t",
            "Senha expirada\t\t\t\t",
            "Período de proteção\t\t\t",
            "Reservado\t\t\t\t",
            "Reservado\t\t\t\t",
            "Reservado\t\t\t\t",
            "Reservado\t\t\t\t",
            "Reservado\t\t\t\t",
            "Erro tensão de referência\t\t",
            "Ocorreu reset\t\t\t\t",
            "Bateria baixa\t\t\t\t",
            "Abertura do painel\t\t\t",
            "Ocorrência relés\t\t\t",
            "Reset externo\t\t\t\t",
            "Abertura do bloco de terminais\t\t",
            "Detecção de campo magnético\t\t",
            "Erro integridade\t\t\t",
            "Sem parâmetros\t\t\t",
            "Sem configuração/ajuste\t\t",
            "Recuperou parâmetros\t\t\t",
            "Recuperou ajuste e configuração\t",
            "Perdeu RTC\t\t\t\t",
            "Recuperou registros\t\t\t",
            "Sem ajuste RTC\t\t\t\t",
            "Falha comunicação I2C\t\t\t",
            "Falha comunicação módulo relés\t",
            "Erro escrita da flash externa\t\t",
            "Falha comunicação interna\t\t",
            "Falha SPI módulo RF\t\t\t",
            "Falha SPI RTC\t\t\t\t",
            "Falha SPI flash externa\t\t\t",
            "Desvio corrente\t\t\t\t",
            "Balanço energético\t\t\t",
            "Saída não utilizada com carga\t\t",
            "Falha sensor temperatura\t\t",
            "Acionamento sensor porta óptica\t",
            "Acionamento sensor UART1\t\t",
            "Acionamento sensor UART2\t\t"
        };

        //Definições dos Postos Horários
        public const Int32 cte_PH_Geral = 0;
        public const Int32 cte_PH_Ponta = 1;
        public const Int32 cte_PH_ForaPonta = 2;
        public const Int32 cte_PH_Reservado = 3;
        public const Int32 cte_PH_QuartoPosto = 4;
        public const Int32 cte_Numero_PH = 5;
        public const Int32 cte_Qtd_PH = 4;
        public static byte NumeroSegmentosHorarios = 0;
        public static byte CondicaoSegmentosHorariosSabados = 2;
        public static byte CondicaoSegmentosHorariosDomingos = 2;
        public static byte CondicaoSegmentosHorariosFeriados = 2;
        public static byte SelecaoConjuntoDadosQEE = 0;

        public const Int32 cte_Numero_Horario_Verao = 15;
        public const Int32 cte_Numero_Feriados = 82;
        public const Int32 cte_Numero_Fatura = 12;
        public const Int32 cte_Numero_Display = 12;
        public const Int32 cte_Numero_Fases = 3;
        public const Int32 cte_Numero_Elementos = 15;
        public const Int32 cte_Numero_Faltas_Energia = 20;
        public const Int32 cte_Numero_Dias_Semana = 7;

        public const Int32 cte_TAMANHODEFAULTTRANSMITIR = 64 + 2;
        public const Int32 cte_TAMANHODEFAULTRECEBER = 256 + 2;
        public const Int32 cte_TAMANHODEFAULTTRANSMITIR_PROTOCOLO_SM = 18 + 130 + 2;
        public const Int32 cte_TAMANHODEFAULTRECEBER_PROTOCOLO_SM = 18 + 130 + 2;
        public const Int32 cte_TAMANHOMAXIMOTRANSMITIR = 1024 + 11 + 2;
        public const Int32 cte_TAMANHOMAXIMORECEBER = (10 * 256) + 2;

        public const Int32 ctBitMQ = 16;              // Bit 4: Medidor de qualidade (1 - Indica que o medidor é de qualidade)
        public const Int32 ctBitpCP = 128;            // Bit 7: Parâmetros de Compensação de perdas
        public const Int32 ctBitAlarmes = 2;          // BitFlag 9 (Bit 2 do octeto 254): Disponibilidade de registros de alarmes
        public const Int32 ctBitRegCargaProg = 4;     // BitFlag 10 (Bit 3 do octeto 254): Disponibilidade de registros de cargas de programa


        public const Int32 cte_ctCodigoDeErroMinimoARecuperar = 0x30;
        public const Int32 cte_ctCodigoDeErroMaximoARecuperar = 0x70;

        public const Int32 cte_ctNumeroTotalDeComandos = 270;
        public const Int32 cte_ctNumeroMaximoDePalavrasDaMemoriaDeMassa = 999 * 166;
        public const Int32 cte_ctTamanhoDoBufferDeDadosLidosLC = 1024 * 2500;    //2,5 Mega
        public const Int32 cte_ctTamanhoDoBufferDeDadosEscritos = 128 * 1024;

        public const Int32 IU_LEITORA = 12345678;

        public const Int32 DEFEITO_BATERIA = 0x30;              // Bateria com defeito
        public const Int32 ERRO_INTEGRIDADE = 0x31;             // Erro na integridade do programa
        public const Int32 DEFEITO_RELOGIO = 0x33;              // Relogio com defeito
        public const Int32 SENHA_INVALIDA = 0x36;               // Senha inválida
        public const Int32 ACAO_WATCHDOG = 0x37;                // Acão do WatchDog
        public const Int32 PROTECAO_FECHAMENTO_FATURA = 0x45;   // Fechamento de fatura no período de proteção
        public const Int32 ALTERACAO_PARAMETRO_INVALIDO = 0x46; // Alteração com parâmetro inválido.
        public const Int32 OCORRENCIA_ESPECIFICA_MEDIDOR = 0xAB;// Ocorrências específicas do medidor

        public const Int32 SENHA_ENVIADA_OK = 0x00;                     // Senha OK
        public const Int32 SENHA_ENVIADA_PROXIMO_EXPIRAR = 0x01;        // Senha próximo de expirar
        public const Int32 SENHA_ENVIADA_EXPIRADA = 0x02;               // Senha expirada
        public const Int32 MEDIDOR_PERIODO_PROTECAO_SENHA_ENVIADA_INVALIDA = 0x03;
        public const Int32 SENHA_ENVIADA_INVALIDA = 0x04;

        public const Int32 MEDIDOR_PERIODO_PROTECAO = 0x01;         // Medidor em período de proteção contra acesso não autorizado.
        public const Int32 SENHA_EXPIRADA = 0x02;                   // Senha expirada
        public const Int32 COMANDO_NAO_SUPORTADO = 0x03;            // Medidor selecionado não suporta comando.
        public const Int32 TAMANHO_DADOS_INVALIDO = 0x04;           // Erro no tamanho de dados inválidos
        public const Int32 DESATIVACAO_HOSPEDEIRO_INVALIDO = 0x05;  // Tentativa de desativação do medidor hospedeiro
        public const Int32 ATIVACAO_MEDIDOR_INEXISTENTE = 0x06;     // Tentativa de ativação de medidor inexistente
        public const Int32 ATIVACAO_ELEMENTOS_DUPLICADOS = 0x07;    // Tentativa de ativação de elementos duplicados
        public const Int32 UC_MEDIDOR_INVALIDA = 0x08;              // UC do medidor inválida
        public const Int32 IU_INVALIDO = 0x09;                      // IU do dispositivo indicador inválida
        public const Int32 UC_REPETIDA = 0x10;                      // UC do do medidor  repetida
        public const Int32 IU_REPETIDO = 0x11;                      // IU do dispositivo indicador repetido
        public const Int32 COD_DISPLAY_INEXISTENTE = 0x12;          // Código do display inexistente
        public const Int32 COD_ATIVOS_INVALIDOS = 0x13;             // Erro nos códigos ativos no medidor hospedeiro
        public const Int32 DATA_HORA_INVALIDA = 0x14;               // Data-Hora inválida.
        public const Int32 DATA_INVALIDA = 0x15;                    // Data inválida.
        public const Int32 DATA_FUTURA_INVALIDA = 0x16;             // Data de início dos postos futuros menor que data atual
        public const Int32 ERRO_HORARIO_INICIO_POSTOS = 0x17;       // Erro no horário do início dos postos.
        public const Int32 POSTOS_HORARIOS_REPETIDOS = 0x18;        // Postos horários repetidos.
        public const Int32 FERIADOS_REPETIDOS = 0x19;               // Feriados Repetidos.
        public const Int32 ERRO_INICIO_HORARIO_VERAO = 0x20;        // Erro na data de início de horário de verão
        public const Int32 ERRO_SEQUENCIA_HORARIO_VERAO = 0x21;     // Erro na sequencia das datas de início do horário de verão
        public const Int32 SENHA_REPETIDA = 0x22;                   // Senha repetida;
        public const Int32 SUB_SENHA_INVALIDA = 0x23;               // Senha inválida;
        public const Int32 ERRO_DATA_EXPIRACAO = 0x24;              // Data Expiração menor que data atual;
        public const Int32 ERRO_DATA_AVISO = 0x25;                  // Data aviso maior que a data atual;
        public const Int32 BLOQUEIO_SENHA_ATIVADO = 0x26;           // Bloqueio de senha ativado
        public const Int32 MEDIDOR_SEM_RELE = 0x27;                 // Medidor não possui relé
        public const Int32 MEDIDOR_INATIVO = 0x28;                  // Medidor inativo
        public const Int32 PARAMETRO_NAO_SUPORTADO = 0x29;          // Parâmetro não suportado pelo comando

        public const Int32 ABERTURA_SENSOR_PAINEL = 0x01;           // Abertura do sensor do painel
        public const Int32 OCORRENCIA_MODULO_RELES = 0x02;          // OcorrÊncia no módulo de relés
        public const Int32 FALHA_TENSAO_REFERENCIA = 0x03;          // Falha na tensão de referência
        public const Int32 FALHA_MODULO_I2C = 0x04;                 // Falha no módulo I2C
        public const Int32 FALHA_MODULO_SPI = 0x05;                 // Falha no módulo SPI
        public const Int32 FALHA_ACESSO_RELES = 0x06;               // Falha no acesso ao módulo de relés
        public const Int32 MEDIDOR_SEM_PARAMETROS = 0x07;           // Medidor sem parâmetros
        public const Int32 MEDIDOR_RECUPEROU_PARAMETROS = 0x08;     // Medidor recuperou parâmetros
        public const Int32 MEDIDOR_RECUPEROU_CONFIGURACAO = 0x09;   // Medidor recuperou configuração e ajustes
        public const Int32 SENHA_PROXIMA_EXPIRAR = 0x10;            // Senha próxima de expirar
        public const Int32 SUB_SENHA_EXPIRADA = 0x11;               // Senha expirada
        public const Int32 SUB_PERIODO_PROTECAO = 0x12;             // Medidor em periodo de proteção contra acesso não autorizado
        public const Int32 FALHA_RTC = 0x13;                        // Falha na escrita do RTC
        public const Int32 FALHA_LEITURA_SENHA = 0x14;              // Falha na leitura das informações de senha
        public const Int32 FALHA_LEITURA_FILAS = 0x15;              // Falha na leitura das filas
        public const Int32 FALHA_COMANDO_CORTE = 0x16;              // Falha na execução do comando de corte
        public const Int32 FALHA_COMANDO_RELIGAMENTO = 0x17;        // Falha na execução do comando de religamento
        public const Int32 FALHA_COMM_SPI_MODULO_RF = 0x18;         // Falha na comunicação SPI com o módulo RF
        public const Int32 FALHA_COMM_SPI_RTC = 0x19;               // Falha na comunicação SPI com o RTC
        public const Int32 FALHA_COMM_SPI_MEMORIA_FLASH = 0x20;     // Falha na comunicação SPI com a Memória Flash externa
        public const Int32 OCORRENCIA_BALANCO_ENERGETICO = 0x21;    // Ocorrência no balança energético
        public const Int32 SAIDA_NAO_UTILIZADA_COM_CARGA = 0x22;    // Saída não utilizada com carga
        public const Int32 FALHA_CONFIGURACAO_REMOTA = 0x23;        // Falha na configuração da remota
        public const Int32 DETECCAO_CAMPO_MAGNETICO = 0x24;         // Detecção de campo magnético externo
        public const Int32 DESVIO_CORRENTES_TC = 0x25;              // Desvio de correntes medido pelo TC
        public const Int32 RESET_EXTERNO = 0x26;                    // Reset Externo
        public const Int32 MEDIDOR_SEM_CONFIGURACAO = 0x27;         // Medidor Sem Configuração
        public const Int32 MEDIDOR_RECUPEROU_REGISTROS = 0x28;      // Medidor recuperou registros
        public const Int32 MEDIDOR_SEM_AJUSTE_RTC = 0x29;           // Medidor sem ajuste de RTC
        public const Int32 ACIONAMENTO_SENSOR_PO = 0x30;            // Acionamento do sensor da porta óptica
        public const Int32 ACIONAMENTO_SENSOR_UART1 = 0x31;         // Acionamento do sensor da UART1
        public const Int32 ACIONAMENTO_SENSOR_UART2 = 0x32;         // Acionamento do sensor da UART2

        //Comandos SM
        //Leitura
        public const Int32 CMD_RD_REG = 0x01;                       // Leitura dos registradores de energia dos medidores
        public const Int32 CMD_RD_VERIFICACAO = 0x02;               // Leitura dos registros de fatura dos medidores (verificação)
        public const Int32 CMD_RD_RECUPERACAO = 0x03;               // Leitura dos registros de fatura dos medidores (recuperação)
        public const Int32 CMD_RD_GRD = 0x04;                       // Leitura das grandezas
        public const Int32 CMD_RD_CFG = 0x05;                       // Leitura da configuração
        public const Int32 CMD_RD_PARAM = 0x06;                     // Leitura dos parâmetros atuais 
        public const Int32 CMD_RD_LOG = 0x07;	                    // Leitura dos registros de alterações de parâmetros
        public const Int32 CMD_RD_OC = 0x08;                        // Leitura das ocorrências do medidor
        public const Int32 CMD_RD_OC_FALTA = 0x09;                  // Leitura das ocorrências de falta de energia
        public const Int32 CMD_RD_RELE_ESTADO = 0x0A;       	    // Leitura dos estados lógico e físico dos relés
        public const Int32 CMD_RD_RANDOM = 0x7F;	                // Leitura de número aleatório
        //Parametrização medidores de tarifação
        public const Int32 CMD_WR_PAR_MED_UC_IU_DI = 0x81;          // Ativação dos medidores
        public const Int32 CMD_WR_PAR_DISPLAY = 0x82;               // Parametrização dos códigos ativos nos mostradores
        public const Int32 CMD_WR_PAR_DATAHORA = 0x83;              // Parametrização de data/hora
        public const Int32 CMD_WR_PAR_POSTOS_ATUAIS = 0x84;         // Parametrização de postos horários Conjunto 1
        public const Int32 CMD_WR_PAR_POSTOS_FUTUROS = 0x85;        // Parametrização de postos horários Conjunto 2
        public const Int32 CMD_WR_PAR_FERIADOS = 0x86;              // Parametrização de feriados
        public const Int32 CMD_WR_PAR_HORARIOVERAO = 0x87;          // Parametrização de horário de verão
        public const Int32 CMD_WR_PAR_FATURA_AUTO = 0x88;           // Parametrização da Fatura Automática
        public const Int32 CMD_WR_FECHA_FATURA = 0x89;              // Fechamento de fatura
        public const Int32 CMD_WR_CALIBRA = 0x8A;                   // Modo de especial
        public const Int32 CMD_WR_ALTERA_SENHA = 0x8B;              // Alteração de senha
        public const Int32 CMD_WR_CORTE_RELIGA = 0x8C;              // Corte/religamento da unidade consumidora    
        public const Int32 CMD_WR_DI = 0x8D;                        // Corte/religamento da unidade consumidora
        public const Int32 CMD_WR_PAR_SELF_READ = 0x8E;             // Parametrização de SelfRead
        public const Int32 CMD_WR_ALTERA_TAR_REAT_ATUAL = 0x8F;     // Alteração da Tarifa de Reativos Atual
        public const Int32 CMD_WR_ALTERA_TAR_REAT_FUTURA = 0x90;    // Alteração da Tarifa de Reativos Futura
        public const Int32 CMD_WR_ALTERA_GRANDEZAS_MOSTRADOR = 0x91;// Parametrização da Apresentação das Grandezas no Mostrador
        public const Int32 CMD_WR_PAR_RTP_RTC = 0x92;               // Parametros da ligação indireta     
        //QEE
        public const Int32 CMD_WR_PAR_TENSAO_NOMINAL_LIGACAO = 0xB1;// Parametrização da Tensão Nominal e do Tipo de Ligação
        // Comunicação
        public const Int32 CMD_WR_ALTERA_PROTOCOLO = 0xC1;          // Alteração do protocolo da interface
        public const Int32 CMD_WR_ALTERA_CFG_MODEM = 0xC2;          // Alteração da configuração do modem
        public const Int32 CMD_WR_ALTERA_TIPO_SAIDA_KP = 0xC3;      // Parametrização do tipo de saída serial unidirecional e Kp
        // Combate a perdas
        public const Int32 CMD_WR_ALTERA_INTERVALO_MM = 0xD1;       // Alteração do Intervalo de MM
        public const Int32 CMD_WR_PAR_ENTRADAS_MED_GERAL = 0xD2;    // Parametrização das Entradas do Medidor Geral
        public const Int32 CMD_WR_PAR_RES_RAMAL = 0xD3;             // Parametrização da Resistência do Ramal
        public const Int32 CMD_WR_ZERA_REGISTRADORES = 0xD4;        // Zeramento de Registradores
        public const Int32 CMD_WR_PAR_CONST_TRAFO = 0xD5;           // Parametrização das Constantes do Trafo
        public const Int32 CMD_WR_PAR_MODO_TESTE = 0xD6;            // Modo Teste dos Alarmes
        // Diversos
        public const Int32 CMD_WR_PAR_CODIGO_CONSUMIDOR = 0xE1;     // Parametrização do Código do Consumidor
        public const Int32 CMD_WR_ALTERA_CFG_HARDWARE = 0xE2;       // Configuração de Hardware
        public const Int32 CMD_WR_ALTERA_HABILITA_OC = 0xE3;        // Alteração a respostas a ocorrências
        // Carga de Programa
        public const Int32 CMD_WR_ATUALIZACAO_CARGA_PO = 0xF1;      // Atualização de carga de programa

        // Mostradores
        public const int INDEX_DISPLAY_DATA                                             = 0;
        public const int INDEX_DISPLAY_HORA                                             = 1;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_GERAL                              = 2;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_PONTA                              = 3;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_RESERVADO                          = 4;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_FORA_PONTA                         = 5;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_QUARTO_POSTO                       = 6;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_PONTA                             = 7;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_RESERVADO                         = 8;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_FORA_PONTA                        = 9;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_QUARTO_POSTO                      = 10;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_PONTA                          = 11;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_RESERVADO                      = 12;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_FORA_PONTA                     = 13;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_QUARTO_POSTO                   = 14;
        public const int INDEX_DISPLAY_NUMERO_REPOSICOES_DEMANDA                        = 15;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_GERAL                   = 16;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_PONTA                   = 17;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_RESERVADO               = 18;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_FORA_PONTA              = 19;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_QUARTO_POSTO            = 20;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_GERAL                   = 21;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_GERAL            = 16;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_PONTA            = 17;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_RESERVADO        = 18;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_FORA_PONTA       = 19;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_QUARTO_POSTO     = 20;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_GERAL          = 21;
        public const int INDEX_DISPLAY_NUMERO_SERIE_MEDIDOR                             = 22;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_GERAL                             = 23;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_GERAL                          = 24;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_PONTA                   = 25;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_RESERVADO               = 26;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_FORA_PONTA              = 27;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_PONTA          = 25;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_RESERVADO      = 26;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_FORA_PONTA     = 27;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_GERAL                      = 28;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_PONTA                      = 29;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_RESERVADO                  = 30;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_FORA_PONTA                 = 31;
        public const int INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_QUARTO_POSTO               = 32;
        public const int INDEX_DISPLAY_NUMERO_UNIDADE_CONSUMIDORA                       = 33;
        public const int INDEX_DISPLAY_AUTO_TESTE_MOSTRADOR                             = 34;
        public const int INDEX_DISPLAY_POSTO_HORARIO                                    = 35;
        public const int INDEX_DISPLAY_CALL_DI                                          = 36;
        public const int INDEX_DISPLAY_UFER_TOTAL                                       = 37;
        public const int INDEX_DISPLAY_UFER_PONTA                                       = 38;
        public const int INDEX_DISPLAY_UFER_RESERVADO                                   = 39;
        public const int INDEX_DISPLAY_UFER_FORA_PONTA                                  = 40;
        public const int INDEX_DISPLAY_DMCR_PONTA                                       = 41;
        public const int INDEX_DISPLAY_DMCR_RESERVADO                                   = 42;
        public const int INDEX_DISPLAY_DMCR_FORA_PONTA                                  = 43;
        public const int INDEX_DISPLAY_DMCR_ACUMULADA_PONTA                             = 44;
        public const int INDEX_DISPLAY_DMCR_ACUMULADA_RESERVADO                         = 45;
        public const int INDEX_DISPLAY_DMCR_ACUMULADA_FORA_PONTA                        = 46;
        public const int INDEX_DISPLAY_DMCR_MAXIMA_GERAL                                = 47;
        public const int INDEX_DISPLAY_DMCR_ACUMULADA_GERAL                             = 48;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_PONTA                     = 49;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_RESERVADO                 = 50;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_FORA_PONTA                = 51;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_QUARTO_POSTO              = 52;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_PONTA                  = 53;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_RESERVADO              = 54;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_FORA_PONTA             = 55;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_QUARTO_POSTO           = 56;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_GERAL           = 57;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_PONTA           = 58;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_RESERVADO       = 59;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_FORA_PONTA      = 60;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_QUARTO_POSTO    = 61;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_GERAL         = 62;
        public const int INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_GERAL                     = 63;
        public const int INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_GERAL                  = 64;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_PONTA         = 65;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_RESERVADO     = 66;
        public const int INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_FORA_PONTA    = 67;
        public const int INDEX_DISPLAY_DRP_DRC                                          = 68;

        //Ordem de exibição das grandezas na lista
        public static int[] INDEX_CLBMostradoresMaxi = 
        {
            0, //INDEX_DISPLAY_DATA
            1, //INDEX_DISPLAY_HORA
            2, //INDEX_DISPLAY_ENERGIA_ATIVA_GERAL
            3, //INDEX_DISPLAY_ENERGIA_ATIVA_PONTA
            4, //INDEX_DISPLAY_ENERGIA_ATIVA_RESERVADO
            5, //INDEX_DISPLAY_ENERGIA_ATIVA_FORA_PONTA
            6, //INDEX_DISPLAY_ENERGIA_ATIVA_QUARTO_POSTO
            7, //INDEX_DISPLAY_DEMANDA_MAXIMA_PONTA
            8, //INDEX_DISPLAY_DEMANDA_MAXIMA_RESERVADO
            9, //INDEX_DISPLAY_DEMANDA_MAXIMA_FORA_PONTA
            10, //INDEX_DISPLAY_DEMANDA_MAXIMA_QUARTO_POSTO
            11, //INDEX_DISPLAY_DEMANDA_ACUMULADA_PONTA
            12, //INDEX_DISPLAY_DEMANDA_ACUMULADA_RESERVADO
            13, //INDEX_DISPLAY_DEMANDA_ACUMULADA_FORA_PONTA
            14, //INDEX_DISPLAY_DEMANDA_ACUMULADA_QUARTO_POSTO
            15, //INDEX_DISPLAY_NUMERO_REPOSICOES_DEMANDA
            16, //INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_GERAL
            17, //INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_PONTA
            18, //INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_RESERVADO
            19, //INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_FORA_PONTA
            20, //INDEX_DISPLAY_ENERGIA_REATIVA_POSITIVA_QUARTO_POSTO
            21, //INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_GERAL
            22, //INDEX_DISPLAY_NUMERO_SERIE_MEDIDOR
            23, //INDEX_DISPLAY_DEMANDA_MAXIMA_GERAL
            24, //INDEX_DISPLAY_DEMANDA_ACUMULADA_GERAL
            37, //INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_PONTA
            38, //INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_RESERVADO
            39, //INDEX_DISPLAY_ENERGIA_REATIVA_NEGATIVA_FORA_PONTA
            40, //INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_GERAL
            41, //INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_PONTA
            42, //INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_RESERVADO
            43, //INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_FORA_PONTA
            44, //INDEX_DISPLAY_ENERGIA_ATIVA_REVERSA_QUARTO_POSTO
            59, //INDEX_DISPLAY_NUMERO_UNIDADE_CONSUMIDORA
            65, //INDEX_DISPLAY_AUTO_TESTE_MOSTRADOR
            66, //INDEX_DISPLAY_POSTO_HORARIO
            67, //INDEX_DISPLAY_CALL_DI
            25, //INDEX_DISPLAY_UFER_TOTAL
            26, //INDEX_DISPLAY_UFER_PONTA
            27, //INDEX_DISPLAY_UFER_RESERVADO
            28, //INDEX_DISPLAY_UFER_FORA_PONTA
            29, //INDEX_DISPLAY_DMCR_PONTA
            30, //INDEX_DISPLAY_DMCR_RESERVADO
            31, //INDEX_DISPLAY_DMCR_FORA_PONTA
            32, //INDEX_DISPLAY_DMCR_ACUMULADA_PONTA
            33, //INDEX_DISPLAY_DMCR_ACUMULADA_RESERVADO
            34, //INDEX_DISPLAY_DMCR_ACUMULADA_FORA_PONTA
            35, //INDEX_DISPLAY_DMCR_MAXIMA_GERAL
            36, //INDEX_DISPLAY_DMCR_ACUMULADA_GERAL
            45, //INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_PONTA
            46, //INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_RESERVADO
            47, //INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_FORA_PONTA
            48, //INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_QUARTO_POSTO
            49, //INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_PONTA
            50, //INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_RESERVADO
            51, //INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_FORA_PONTA
            52, //INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_QUARTO_POSTO
            53, //INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_GERAL
            54, //INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_PONTA
            55, //INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_RESERVADO
            56, //INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_FORA_PONTA
            57, //INDEX_DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_QUARTO_POSTO
            58, //INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_GERAL
            60, //INDEX_DISPLAY_DEMANDA_MAXIMA_REVERSA_GERAL
            61, //INDEX_DISPLAY_DEMANDA_ACUMULADA_REVERSA_GERAL
            62, //INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_PONTA
            63, //INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_RESERVADO
            64, //INDEX_DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_FORA_PONTA
            68, //INDEX_DISPLAY_DRP_DRC
        };

        public const String DISPLAY_DATA = "DATA (COD. 01)";                                                                                    // Bit 0
        public const String DISPLAY_HORA = "HORA (COD. 02)";                                                                                    // Bit 1
        public const String DISPLAY_ENERGIA_ATIVA_GERAL = "ENERGIA ATIVA GERAL (COD. 03)";                                                      // Bit 2
        public const String DISPLAY_ENERGIA_ATIVA_PONTA = "ENERGIA ATIVA PONTA (COD. 04)";                                                      // Bit 3
        public const String DISPLAY_ENERGIA_ATIVA_RESERVADO = "ENERGIA ATIVA RESERVADO (COD. 06)";                                              // Bit 4
        public const String DISPLAY_ENERGIA_ATIVA_FORA_PONTA = "ENERGIA ATIVA FORA PONTA (COD. 08)";                                            // Bit 5
        public const String DISPLAY_ENERGIA_ATIVA_QUARTO_POSTO = "ENERGIA ATIVA QUARTO POSTO (COD. 09)";                                        // Bit 6
        public const String DISPLAY_DEMANDA_MAXIMA_PONTA = "DEMANDA MÁXIMA DIRETA PONTA (COD. 10)";                                             // Bit 7
        public const String DISPLAY_DEMANDA_MAXIMA_RESERVADO = "DEMANDA MÁXIMA DIRETA RESERVADO (COD. 12)";                                     // Bit 8
        public const String DISPLAY_DEMANDA_MAXIMA_FORA_PONTA = "DEMANDA MÁXIMA DIRETA FORA PONTA (COD. 14)";                                   // Bit 9
        public const String DISPLAY_DEMANDA_MAXIMA_QUARTO_POSTO = "DEMANDA MÁXIMA DIRETA QUARTO POSTO (COD. 15)";                               // Bit 10
        public const String DISPLAY_DEMANDA_ACUMULADA_PONTA = "DEMANDA ACUMULADA DIRETA PONTA (COD. 17)";                                       // Bit 11
        public const String DISPLAY_DEMANDA_ACUMULADA_RESERVADO = "DEMANDA ACUMULADA DIRETA RESERVADO (COD. 19)";                               // Bit 12
        public const String DISPLAY_DEMANDA_ACUMULADA_FORA_PONTA = "DEMANDA ACUMULADA DIRETA FORA PONTA (COD. 21)";                             // Bit 13
        public const String DISPLAY_DEMANDA_ACUMULADA_QUARTO_POSTO = "DEMANDA ACUMULADA DIRETA QUARTO POSTO (COD. 22)";                         // Bit 14
        public const String DISPLAY_NUMERO_REPOSICOES_DEMANDA = "NÚMERO DE REPOSIÇÕES DE DEMANDA (COD. 23)";                                    // Bit 15
        public const String DISPLAY_ENERGIA_REATIVA_POSITIVA_GERAL = "ENERGIA REATIVA POSITIVA GERAL (COD. 24)";                                // Bit 16
        public const String DISPLAY_ENERGIA_REATIVA_POSITIVA_PONTA = "ENERGIA REATIVA POSITIVA PONTA (COD. 25)";                                // Bit 17
        public const String DISPLAY_ENERGIA_REATIVA_POSITIVA_RESERVADO = "ENERGIA REATIVA POSITIVA RESERVADO (COD. 27)";                        // bit 18
        public const String DISPLAY_ENERGIA_REATIVA_POSITIVA_FORA_PONTA = "ENERGIA REATIVA POSITIVA FORA PONTA (COD. 29)";                      // Bit 19
        public const String DISPLAY_ENERGIA_REATIVA_POSITIVA_QUARTO_POSTO = "ENERGIA REATIVA POSITIVA QUARTO POSTO (COD. 30)";                  // Bit 20
        public const String DISPLAY_ENERGIA_REATIVA_NEGATIVA_GERAL = "ENERGIA REATIVA NEGATIVA GERAL (COD. 31)";                                // Bit 21
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_GERAL = "ENERGIA REATIVA INDUTIVA DIRETA GERAL (COD. 24)";                  // Bit 16
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_PONTA = "ENERGIA REATIVA INDUTIVA DIRETA PONTA (COD. 25)";                  // Bit 17
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_RESERVADO = "ENERGIA REATIVA INDUTIVA DIRETA RESERVADO (COD. 27)";          // bit 18
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_FORA_PONTA = "ENERGIA REATIVA INDUTIVA DIRETA FORA PONTA (COD. 29)";        // Bit 19
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_QUARTO_POSTO = "ENERGIA REATIVA INDUTIVA DIRETA QUARTO POSTO (COD. 30)";    // Bit 20
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_GERAL = "ENERGIA REATIVA CAPACITIVA DIRETA GERAL (COD. 31)";              // Bit 21
        public const String DISPLAY_NUMERO_SERIE_MEDIDOR = "NÚMERO DE SÉRIE DO MEDIDOR (COD. 33)";                                              // Bit 22
        public const String DISPLAY_DEMANDA_MAXIMA_GERAL = "DEMANDA MÁXIMA DIRETA GERAL (COD. 52)";                                             // Bit 23
        public const String DISPLAY_DEMANDA_ACUMULADA_GERAL = "DEMANDA ACUMULADA DIRETA GERAL (COD. 54)";                                       // Bit 24
        public const String DISPLAY_DEMANDA_ACUMULADA_GERAL_ATIVA = "DEMANDA ACUMULADA GERAL ENERGIA ATIVA (COD. 54)";                          // Bit 24
        ////////////////////
        //Maxi/Extend/Unique
        public const String DISPLAY_UFER_TOTAL = "UFER TOTAL (COD. 65)";                                                                        // Bit 37
        public const String DISPLAY_UFER_PONTA = "UFER PONTA (COD. 66)";                                                                        // Bit 38
        public const String DISPLAY_UFER_RESERVADO = "UFER RESERVADO (COD. 67)";                                                                // Bit 39
        public const String DISPLAY_UFER_FORA_PONTA = "UFER FORA PONTA (COD. 68)";                                                              // Bit 40
        public const String DISPLAY_DMCR_PONTA = "DMCR PONTA (COD. 69)";                                                                        // Bit 41
        public const String DISPLAY_DMCR_RESERVADO = "DMCR RESERVADO (COD. 70)";                                                                // Bit 42
        public const String DISPLAY_DMCR_FORA_PONTA = "DMCR FORA PONTA (COD. 71)";                                                              // Bit 43
        public const String DISPLAY_DMCR_ACUMULADA_PONTA = "DMCR ACUMULADA PONTA (COD. 73)";                                                    // Bit 44
        public const String DISPLAY_DMCR_ACUMULADA_RESERVADO = "DMCR ACUMULADA RESERVADO (COD. 74)";                                            // Bit 45
        public const String DISPLAY_DMCR_ACUMULADA_FORA_PONTA = "DMCR ACUMULADA FORA PONTA (COD. 75)";                                          // Bit 46
        public const String DISPLAY_DMCR_MAXIMA_GERAL = "DMCR MÁXIMA GERAL (COD. 78)";                                                          // Bit 47
        public const String DISPLAY_DMCR_ACUMULADA_GERAL = "DMCR ACUMULADA GERAL (COD. 80)";                                                    // Bit 48
        ////////////////////
        public const String DISPLAY_ENERGIA_REATIVA_NEGATIVA_PONTA = "ENERGIA REATIVA NEGATIVA PONTA (COD. 85)";                                // Bit 25
        public const String DISPLAY_ENERGIA_REATIVA_NEGATIVA_RESERVADO = "ENERGIA REATIVA NEGATIVA RESERVADO (COD. 86)";                        // Bit 26
        public const String DISPLAY_ENERGIA_REATIVA_NEGATIVA_FORA_PONTA = "ENERGIA REATIVA NEGATIVA FORA PONTA (COD. 87)";                      // Bit 27
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_PONTA = "ENERGIA REATIVA CAPACITIVA DIRETA PONTA (COD. 85)";              // Bit 25
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_RESERVADO = "ENERGIA REATIVA CAPACITIVA DIRETA RESERVADO (COD. 86)";      // Bit 26
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_FORA_PONTA = "ENERGIA REATIVA CAPACITIVA DIRETA FORA PONTA (COD. 87)";    // Bit 27
        public const String DISPLAY_ENERGIA_ATIVA_REVERSA_GERAL = "ENERGIA ATIVA REVERSA GERAL (COD. 103)";                                     // Bit 28
        public const String DISPLAY_ENERGIA_ATIVA_REVERSA_PONTA = "ENERGIA ATIVA REVERSA PONTA (COD. 104)";                                     // Bit 29
        public const String DISPLAY_ENERGIA_ATIVA_REVERSA_RESERVADO = "ENERGIA ATIVA REVERSA RESERVADO (COD. 106)";                             // Bit 30
        public const String DISPLAY_ENERGIA_ATIVA_REVERSA_FORA_PONTA = "ENERGIA ATIVA REVERSA FORA PONTA (COD. 108)";                           // Bit 31
        public const String DISPLAY_ENERGIA_ATIVA_REVERSA_QUARTO_POSTO = "ENERGIA ATIVA REVERSA QUARTO POSTO (COD. 109)";                       // Bit 32
        ////////////////////
        //Maxi/Extend/Unique
        public const String DISPLAY_DEMANDA_MAXIMA_REVERSA_PONTA = "DEMANDA MÁXIMA REVERSA PONTA (COD. 110)";                                   // Bit 49
        public const String DISPLAY_DEMANDA_MAXIMA_REVERSA_RESERVADO = "DEMANDA MÁXIMA REVERSA RESERVADO (COD. 112)";                           // Bit 50
        public const String DISPLAY_DEMANDA_MAXIMA_REVERSA_FORA_PONTA = "DEMANDA MÁXIMA REVERSA FORA PONTA (COD. 114)";                         // Bit 51
        public const String DISPLAY_DEMANDA_MAXIMA_REVERSA_QUARTO_POSTO = "DEMANDA MÁXIMA REVERSA QUARTO POSTO (COD. 115)";                     // Bit 52
        public const String DISPLAY_DEMANDA_ACUMULADA_REVERSA_PONTA = "DEMANDA ACUMULADA REVERSA PONTA (COD. 117)";                             // Bit 53
        public const String DISPLAY_DEMANDA_ACUMULADA_REVERSA_RESERVADO = "DEMANDA ACUMULADA REVERSA RESERVADO (COD. 119)";                     // Bit 54
        public const String DISPLAY_DEMANDA_ACUMULADA_REVERSA_FORA_PONTA = "DEMANDA ACUMULADA REVERSA FORA PONTA (COD. 121)";                   // Bit 55
        public const String DISPLAY_DEMANDA_ACUMULADA_REVERSA_QUARTO_POSTO = "DEMANDA ACUMULADA REVERSA QUARTO POSTO (COD. 122)";               // Bit 56
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_GERAL = "ENERGIA REATIVA INDUTIVA REVERSA GERAL (COD. 124)";               // Bit 57
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_PONTA = "ENERGIA REATIVA INDUTIVA REVERSA PONTA (COD. 125)";               // Bit 58
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_RESERVADO = "ENERGIA REATIVA INDUTIVA REVERSA RESERVADO (COD. 127)";       // bit 59
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_FORA_PONTA = "ENERGIA REATIVA INDUTIVA REVERSA FORA PONTA (COD. 129)";     // Bit 60
        public const String DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_QUARTO_POSTO = "ENERGIA REATIVA INDUTIVA REVERSA QUARTO POSTO (COD. 130)"; // Bit 61
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_GERAL = "ENERGIA REATIVA CAPACITIVA REVERSA GERAL (COD. 131)";           // Bit 62
        ////////////////////
        public const String DISPLAY_NUMERO_UNIDADE_CONSUMIDORA = "NÚMERO DA UNIDADE CONSUMIDORA (COD. 133)";                                    // Bit 33
        ////////////////////
        //Maxi/Extend/Unique
        public const String DISPLAY_DEMANDA_MAXIMA_REVERSA_GERAL = "DEMANDA MÁXIMA REVERSA GERAL (COD. 152)";                                   // Bit 63
        public const String DISPLAY_DEMANDA_ACUMULADA_REVERSA_GERAL = "DEMANDA ACUMULADA REVERSA GERAL (COD. 154)";                             // Bit 64
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_PONTA = "ENERGIA REATIVA CAPACITIVA REVERSA PONTA (COD. 185)";           // Bit 65
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_RESERVADO = "ENERGIA REATIVA CAPACITIVA REVERSA RESERVADO (COD. 186)";   // Bit 66
        public const String DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_FORA_PONTA = "ENERGIA REATIVA CAPACITIVA REVERSA FORA PONTA (COD. 187)"; // Bit 67
        ////////////////////
        public const String DISPLAY_AUTO_TESTE_MOSTRADOR = "AUTO TESTE MOSTRADOR (COD. 188)";                                                   // Bit 34
        public const String DISPLAY_POSTO_HORARIO = "POSTO HORÁRIO (COD. 198)";                                                                 // Bit 35
        public const String DISPLAY_CALL_DI = "CALL DI (COD. 199)";                                                                             // Bit 36
        ////////////////////
        //Maxi/Extend/Unique
        public const String DISPLAY_DRP_DRC = "DRP/DRC (COD. 75xx/77xx)";                                                                       // Bit 68

        //String dos mostradores Maxi
        public static string[] INDEX_StringMostradoresMaxi =
        {
            DISPLAY_DATA,
            DISPLAY_HORA,
            DISPLAY_ENERGIA_ATIVA_GERAL,
            DISPLAY_ENERGIA_ATIVA_PONTA,
            DISPLAY_ENERGIA_ATIVA_RESERVADO,
            DISPLAY_ENERGIA_ATIVA_FORA_PONTA,
            DISPLAY_ENERGIA_ATIVA_QUARTO_POSTO,
            DISPLAY_DEMANDA_MAXIMA_PONTA,
            DISPLAY_DEMANDA_MAXIMA_RESERVADO,
            DISPLAY_DEMANDA_MAXIMA_FORA_PONTA,
            DISPLAY_DEMANDA_MAXIMA_QUARTO_POSTO,
            DISPLAY_DEMANDA_ACUMULADA_PONTA,
            DISPLAY_DEMANDA_ACUMULADA_RESERVADO,
            DISPLAY_DEMANDA_ACUMULADA_FORA_PONTA,
            DISPLAY_DEMANDA_ACUMULADA_QUARTO_POSTO,
            DISPLAY_NUMERO_REPOSICOES_DEMANDA,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_GERAL,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_PONTA,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_RESERVADO,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_FORA_PONTA,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_DIRETA_QUARTO_POSTO,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_GERAL,
            DISPLAY_NUMERO_SERIE_MEDIDOR,
            DISPLAY_DEMANDA_MAXIMA_GERAL,
            DISPLAY_DEMANDA_ACUMULADA_GERAL,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_PONTA,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_RESERVADO,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_DIRETA_FORA_PONTA,
            DISPLAY_ENERGIA_ATIVA_REVERSA_GERAL,
            DISPLAY_ENERGIA_ATIVA_REVERSA_PONTA,
            DISPLAY_ENERGIA_ATIVA_REVERSA_RESERVADO,
            DISPLAY_ENERGIA_ATIVA_REVERSA_FORA_PONTA,
            DISPLAY_ENERGIA_ATIVA_REVERSA_QUARTO_POSTO,
            DISPLAY_NUMERO_UNIDADE_CONSUMIDORA,
            DISPLAY_AUTO_TESTE_MOSTRADOR,
            DISPLAY_POSTO_HORARIO,
            DISPLAY_CALL_DI,
            DISPLAY_UFER_TOTAL,
            DISPLAY_UFER_PONTA,
            DISPLAY_UFER_RESERVADO,
            DISPLAY_UFER_FORA_PONTA,
            DISPLAY_DMCR_PONTA,
            DISPLAY_DMCR_RESERVADO,
            DISPLAY_DMCR_FORA_PONTA,
            DISPLAY_DMCR_ACUMULADA_PONTA,
            DISPLAY_DMCR_ACUMULADA_RESERVADO,
            DISPLAY_DMCR_ACUMULADA_FORA_PONTA,
            DISPLAY_DMCR_MAXIMA_GERAL,
            DISPLAY_DMCR_ACUMULADA_GERAL,
            DISPLAY_DEMANDA_MAXIMA_REVERSA_PONTA,
            DISPLAY_DEMANDA_MAXIMA_REVERSA_RESERVADO,
            DISPLAY_DEMANDA_MAXIMA_REVERSA_FORA_PONTA,
            DISPLAY_DEMANDA_MAXIMA_REVERSA_QUARTO_POSTO,
            DISPLAY_DEMANDA_ACUMULADA_REVERSA_PONTA,
            DISPLAY_DEMANDA_ACUMULADA_REVERSA_RESERVADO,
            DISPLAY_DEMANDA_ACUMULADA_REVERSA_FORA_PONTA,
            DISPLAY_DEMANDA_ACUMULADA_REVERSA_QUARTO_POSTO,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_GERAL,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_PONTA,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_RESERVADO,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_FORA_PONTA,
            DISPLAY_ENERGIA_REATIVA_INDUTIVA_REVERSA_QUARTO_POSTO,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_GERAL,
            DISPLAY_DEMANDA_MAXIMA_REVERSA_GERAL,
            DISPLAY_DEMANDA_ACUMULADA_REVERSA_GERAL,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_PONTA,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_RESERVADO,
            DISPLAY_ENERGIA_REATIVA_CAPACITIVA_REVERSA_FORA_PONTA,
            DISPLAY_DRP_DRC,
        };

        public const String PARAMETRIZACAO_MOSTRADORES = "Parametrização dos cód. ativos nos mostradores.";
        public const String ATIVACAO_MEDIDORES = "Ativação de Medidores.";
        public const String PARAMETRIZACAO_DATA_HORA = "Parametrização de data/hora.";
        public const String PARAMETRIZACAO_POSTOS_HORARIOS = "Parametrização de postos horários.";
        public const String PARAMETRIZACAO_FERIADOS = "Parametrização de feriados.";
        public const String PARAMETRIZACAO_HORARIO_VERAO = "Parametrização de horário de verão.";
        public const String PARAMETRIZACAO_FATURA_AUTOMATICA = "Parametrização de fatura automática.";
        public const String MODO_CALIBRACAO_ESPECIAL = "Modo especial.";
        public const String FECHA_FATURA = "Fechamento de Fatura.";
        public const String ALTERACAO_SENHA = "Alteração de senha.";
        public const String CORTE_RELIGAMENTO = "Corte/religamento da unidade consumidora.";
        public const String COMANDO_INVALIDO = "Comando inválido.";
        public const String SEM_MEDIDOR_SELECIONADO = "Erro - Selecione um Medidor.";
        public const String ALTERACAO_TARIFA_REATIVOS_FUTURA = "Alteração de Tarifa de Reativos - Futura";
        public const String PARAMETRIZACAO_TENSAO_NOMINAL = "Parametrização QEE";
        public const String ZERAR_MM = "Limpar Memória de Massa";
        public const String PARAMETRIZACAO_CODIGO_CONSUMIDOR = "Parametrização do cód. consumidor";
        public const String ALTERACAO_INTERVALO_MM = "Alteração do Intervalo de MM";
        public const String ALTERACAO_TARIFA_REATIVOS_ATUAL = "Alteração de Tarifa de Reativos - Atual";
        public const String PARAMETRIZACAO_ENTRADAS_MEDIDOR_GERAL = "Parametriazação de Entradas do Med. Geral";
        public const String PARAMETRIZACAO_SELF_READ = "Parametrização de Self Read";
        public const String PARAMETRIZACAO_RESISTENCIA_RAMAL = "Parametrização da Resistência do Ramal";
        public const String ZERAR_REGISTRADORES = "Reset Registradores";
        public const String PARAMETRIZACAO_CONSTANTE_TRAFO = "Parametrização da Constantes do Transformador";
        public const String ZERAR_QEE = "Limpar memória de QEE";
        public const String ZERAR_TRAFO = "Limpar memória Trafo";
        public const String PARAMETRIZACAO_GRANDEZAS_MOSTRADOR = "Parametrização das Grandezas no Mostrador";
        public const String PARAMETRIZACAO_RTP_RTC = "Parametrização de ligaçãoi indireta";
        public const String PARAMETRIZACAO_CONDICAO_RESERVADO = "Parametrização da condição do Reservado";
        public const String TOTAL_GERAL_DIRETA = "Total Geral Direta (Wh)";
        public const String TOTAL_PONTA_DIRETA = "Total Ponta Direta (Wh)";
        public const String TOTAL_FORA_PONTA_DIRETA = "Total Fora Ponta Direta (Wh)";
        public const String TOTAL_RESERVADO_DIRETA = "Total Reservado Direta (Wh)";
        public const String TOTAL_TARIFA_D_DIRETA = "Total Tarifa D Direta (Wh)";
        public const String TOTAL_GERAL_REVERSA = "Total Geral Reversa (Wh)";
        public const String TOTAL_PONTA_REVERSA = "Total Ponta Reversa (Wh)";
        public const String TOTAL_FORA_PONTA_REVERSA = "Total Fora Ponta Reversa (Wh)";
        public const String TOTAL_RESERVADO_REVERSA = "Total Reservado Reversa (Wh)";
        public const String TOTAL_TARIFA_D_REVERSA = "Total Tarifa D Reversa (Wh)";
        public const String TOTAL_GERAL_REATIVA_POSITIVA = "Total Geral Reativa Positiva (VArh)";
        public const String TOTAL_PONTA_REATIVA_POSITIVA = "Total Ponta Reativa Positiva (VArh)";
        public const String TOTAL_FORA_PONTA_REATIVA_POSITIVA = "Total Fora Ponta Reativa Positiva (VArh)";
        public const String TOTAL_RESERVADO_REATIVA_POSITIVA = "Total Reservado Reativa Positiva (VArh)";
        public const String TOTAL_TARIFA_D_REATIVA_POSITIVA = "Total Tarifa D Reativa Positiva (VArh)";
        public const String TOTAL_GERAL_REATIVA_NEGATIVA = "Total Geral Reativa Negativa (VArh)";
        public const String TOTAL_PONTA_REATIVA_NEGATIVA = "Total Ponta Reativa Negativa (VArh)";
        public const String TOTAL_FORA_PONTA_REATIVA_NEGATIVA = "Total Fora Ponta Reativa Negativa (VArh)";
        public const String TOTAL_RESERVADO_REATIVA_NEGATIVA = "Total Reservado Reativa Negativa (VArh)";
        public const String TOTAL_TARIFA_D_REATIVA_NEGATIVA = "Total Tarifa D Reativa Negativa (VArh)";
        public const String PARAMETRIZACAO_PROTOCOLO = "Alteração do protocolo da interface";
        public const String PARAMETRIZACAO_CFG_HW = "Configuração de Hardware";
        public const String PARAMETRIZACAO_MODEM = "Altera a configuração do módulo de comunicação";
        public const String PARAMETRIZACAO_SAIDA_SERIAL_KP = "Parametrização da saida serial e Kp";
        public const String DADOS_DI = "Dados do dispositivo indicador individual";
        public const String ALTERACAO_RESPOSTAS_OCORRENCIAS = "Alteração do comportamento das ocorrências Multiponto-NS";
        public const String ATUALIZACAO_CARGA_PROGRAMA = "Atualização de Carga de Programa";
        public const String MODO_TESTE_ALARMES = "Modo teste dos alarmes";

        public const Int32 cte_coNenhumComando = 0;

        //Tipo de equipamentos baseados no IU
        public const Int32 cte_TipoEquipamentoABSOLUTO      = 0x01;
        public const Int32 cte_TipoEquipamentoDI            = 0x02;
        public const Int32 cte_TipoEquipamentoEasyTrafo     = 0x03;
        public const Int32 cte_TipoEquipamentoEasyVer1F     = 0x04;
        public const Int32 cte_TipoEquipamentoEasyVer3F     = 0x05;
        public const Int32 cte_TipoEquipamentoMaxi          = 0x06;
        public const Int32 cte_TipoEquipamentoEasyVolt      = 0x07;
        public const Int32 cte_TipoEquipamentoEasyTrafoL    = 0x08;
        public const Int32 cte_TipoEquipamentoNeutro        = 0x09;
        public const Int32 cte_TipoEquipamentoIPBR          = 0x0A;
        public const Int32 cte_TipoEquipamentoSMReader      = 0x90;
        public const Int32 cte_TipoEquipamentoSMReaderMob   = 0x91;
        public const Int32 cte_TipoEquipamentoCAS           = 0x92;
        public const Int32 cte_TipoEquipamentoM2M           = 0x93;
        public const Int32 cte_TipoEquipamentoV2COM         = 0x94;
        public const Int32 cte_TipoEquipamentoSSEGridtech   = 0x95;
        public const Int32 cte_TipoEquipamentoHoneywell     = 0x96;
        public const Int32 cte_TipoEquipamentoLandis        = 0x97;
        public const Int32 cte_TipoEquipamentoItron         = 0x98;
        public const Int32 cte_TipoEquipamentoLeitoraABNT   = 0x99;

        public const Int32 cte_ModeloSM1 = 0;
        public const Int32 cte_ModeloSM6 = 1;
        public const Int32 cte_ModeloSM12 = 2;
        public const Int32 cte_ModeloET3 = 3;       //easyTrafoI/easyTrafoL 3 TCs
        public const Int32 cte_ModeloET6 = 4;       //easyTrafoI 6 TCs
        public const Int32 cte_ModeloEV1 = 5;
        public const Int32 cte_ModeloEV3 = 6;
        public const Int32 cte_ModeloUnique20 = 7;
        public const Int32 cte_ModeloExtend120 = 8;
        public const Int32 cte_ModeloExtend240 = 9;
        public const Int32 cte_ModeloMaxi600 = 10;
        public const Int32 cte_ModeloEasyVolt = 11;
        public const Int32 cte_ModeloIPBR = 12;

        public const Int32 cte_coEnvioDeSenha = 0x11;
        public const Int32 cte_coPedidoDeStringDaSenha = 0x13;
        public const Int32 cte_coGrandezasInstantaneas = 0x14;
        public const Int32 cte_coCabecalhoDeRegistroDeMMS = 0x16;
        public const Int32 cte_coRegistroDeMMS = 0x17;
        public const Int32 cte_coLeituraDeParametrosComReposicao = 0x20;
        public const Int32 cte_coLeituraDeParametrosAtuais = 0x21;
        public const Int32 cte_coLeituraDeParametrosAnteriores = 0x22;
        public const Int32 cte_coRegistradoresAtuais = 0x23;
        public const Int32 cte_coRegistradoresAnteriores = 0x24;
        public const Int32 cte_coRegistrodDeFaltasDeEnergia = 0x25;
        public const Int32 cte_coMemoriaDeMassaAtuais = 0x26;
        public const Int32 cte_coMemoriaDeMassaAnteriores = 0x27;
        public const Int32 cte_coRegistroDeAlteracoes = 0x28;
        public const Int32 cte_coAlteracaoDaData = 0x29;
        public const Int32 cte_coEloNetEncapsuladoSimples = 0x2a;
        public const Int32 cte_coEloNetEncapsuladoComposto = 0x2b;
        public const Int32 cte_coAlteracaoDaHora = 0x30;
        public const Int32 cte_coAlteracaoDoIntervaloDeDemanda = 0x31;
        public const Int32 cte_coAlteracaoDosFeriados = 0x32;
        public const Int32 cte_coAlteracaoDasConstantes = 0x33;
        public const Int32 cte_coAltercaoDosSegmentosHorarios = 0x35;
        public const Int32 cte_coAlteracaoDaCondicaoDoReservado = 0x36;
        public const Int32 cte_coAlteracaoDaCondicaoDoErro = 0x37;
        public const Int32 cte_coInicializacao = 0x38;
        public const Int32 cte_coComandoNaoImplementado = 0x39;
        public const Int32 cte_coOcorrenciaNoRegistrador = 0x40;
        public const Int32 cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1 = 0x41;
        public const Int32 cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2 = 0x42;
        public const Int32 cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3 = 0x43;
        public const Int32 cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1 = 0x44;
        public const Int32 cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2 = 0x45;
        public const Int32 cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3 = 0x46;
        public const Int32 cte_coAlteracaoDaFormaDeCalculoDaDemanda = 0x47;
        public const Int32 cte_coParametrosParaTodaMemoriaDeMassa = 0x51;
        public const Int32 cte_coTodaMemoriaDeMassa = 0x52;
        public const Int32 cte_coAlteracaoDaVisualizacaoDasDemandasEmPonta = 0x56;
        public const Int32 cte_coAlteracaoDaVisualizacaoDosCodigosAdicionaisDoCanal2 = 0x59;
        public const Int32 cte_coRegistroDeConexao = 0x60;
        public const Int32 cte_coAlteracaoDaReposicaoAutomatica = 0x63;
        public const Int32 cte_coAlteracaoDoHorarioDeVerao = 0x64;
        public const Int32 cte_coAlteracaoDoConjunto2DeSegmentosHorarios = 0x65;
        public const Int32 cte_coAlteracaoDasGrandezasDosCanais = 0x66;
        public const Int32 cte_coAlteracaoDaTarifaDeReativos = 0x67;
        public const Int32 cte_coAlteracaoDoIntervaloDaMM = 0x73;
        public const Int32 cte_coAlteracaoDoTempoDeApresentacaoDoDisplay = 0x75;
        public const Int32 cte_coAlteracaoDaValidadeDosSegmentosSDF = 0x77;
        public const Int32 cte_coAlteracaoDoTipoDeTarifa = 0x78;
        public const Int32 cte_coAlteracaoDaVisualizacaoDosCodigosDoMostrador = 0x79;
        public const Int32 cte_coLeituraDeParametrosDeMedicao = 0x80;
        public const Int32 cte_coAlteracaoDaSaidaDeUsuario = 0x81;
        public const Int32 cte_coAlteracaoNumeroConsumidor = 0x87;
        public const Int32 cte_coLeituraDeParametrosDeCompensacaoDePerdas = 0x88;
        public const Int32 cte_coAlteracaoDoModoDeApresentacaoDasGrandezasNoMostrador = 0x90;
        public const Int32 cte_coAlteracaoDoPostoHorarioUniversal = 0x92;
        public const Int32 cte_coAlteracaoDasConstantesEModoDeOperacao = 0x93;
        public const Int32 cte_coAlteracaoTensaoNominalQEE = 0x95;
        public const Int32 cte_coAlteracaoConstantesModo2 = 0x95;
        public const Int32 cte_coEstendido = 0x98;

        public const Int32 cte_coProprietarioEstendidoMGE = 0xAB;
        public const Int32 cte_coProprietarioEstendido = 0xEB;
        public const Int32 cte_coLeituraConfiguracaoMedidorHospedeiro = 0xAA;
        public const Int32 cte_subcoLeituraConfiguracaoMedidorHospedeiro = 0x01;
        public const Int32 cte_coLeituraMedidoresAtivosENUC = 0xAB;
        public const Int32 cte_subcoLeituraMedidoresAtivosENUC = 0x02;
        public const Int32 cte_coAlteracaoMedidoresAtivosENUC = 0xAC;
        public const Int32 cte_subcoAlteracaoMedidoresAtivosENUC = 0x03;
        public const Int32 cte_coAlteracaoIdsRadios = 0xAD;

        public const Int32 cte_ComandoEB_LeituraConfiguracaoEasy = 0x01;
        public const Int32 cte_ComandoEB_ConfiguracaoNumeroEntradas = 0x02;
        public const Int32 cte_ComandoEB_ParametrosSelfRead = 0x03;
        public const Int32 cte_ComandoEB_LeituraRegistradoresAtuaisEasy = 0x04;
        public const Int32 cte_ComandoEB_LeituraMM = 0x05;
        public const Int32 cte_ComandoEB_LeituraSelfRead = 0x15;
        public const Int32 cte_ComandoEB_ResetRegistradoresEnergia = 0x07;
        public const Int32 cte_ComandoEB_AlteracaoResistenciaRamal = 0x08;
        public const Int32 cte_ComandoEB_LeituraParametrosEasy = 0x09;
        public const Int32 cte_ComandoEB_EasyCal = 0x10;
        public const Int32 cte_ComandoEB_LeituraDadosQEE = 0x11;
        public const Int32 cte_ComandoEB_LeituraIndicadoresQEE = 0x12;
        public const Int32 cte_ComandoEB_LeituraLogEventosQEE = 0x13;
        public const Int32 cte_ComandoEB_LeituraFaturasEasy = 0x14;

        public const Int32 cte_ComandoAB_LeituraConfiguracaoMedidorHospedeiro = 0x01;
        public const Int32 cte_ComandoAB_LeituraParametrizacaoMedidoresAtivos = 0x02;
        public const Int32 cte_ComandoAB_AlteracaoCodigoExibirDisplay = 0x04;
        public const Int32 cte_ComandoAB_AlteracaoModoCalibracaoSaida10 = 0x05;
        public const Int32 cte_ComandoAB_AlteracaoEstadoCorteReligamento = 0x06;
        public const Int32 cte_ComandoAB_LeituraEstadosReles = 0x07;
        public const Int32 cte_ComandoAB_AlteracaoProtocolo = 0x08;
        public const Int32 cte_ComandoAB_VerificacaoIntegridade = 0x09;
        public const Int32 cte_ComandoAB_AlteracaoCfgModem = 0x10;
        public const Int32 cte_ComandoAB_EnvioSenha = 0x11;
        public const Int32 cte_ComandoAB_AlteracaoSenha = 0x12;
        public const Int32 cte_ComandoAB_CfgHw = 0x13;
        public const Int32 cte_ComandoAB_LeituraRegistradoresAtuaisInstantaneos = 0x21;
        public const Int32 cte_ComandoAB_LeituraRegistradoresAlteracoesMedidor = 0x28;
        public const Int32 cte_ComandoAB_LeituraOcorrenciasMedidor = 0x40;
        public const Int32 cte_ComandoAB_LeituraMemoriaMassa_SM = 0x52;
        public const Int32 cte_ComandoAB_AlteracaoCondicaoReposicaoAutomatica = 0x63;
        public const Int32 cte_ComandoAB_ParametrizacaoHorarioVerao = 0x64;
        public const Int32 cte_ComandoAB_AlteracaoPostosUniversais = 0x92;

        public const Int32 cte_coLeituraDeEventosDeTensao = 0x98; //Comando Estendido
        public const Int32 cte_coLeituraDeParametrosDeQualidade = 0x55;
        public const Int32 cte_coLeituraDeParametrosDeMonitorQualidade = 0x50;
        public const Int32 cte_coLeituraDeDadosDeQualidade = 0x56;
        public const Int32 cte_coLeituraDeDadosDosAlarmes = 0x57;
        public const Int32 cte_coLeituraDeDadosDosRegDeCargaProg = 0x58;
        public const Int32 cte_coLeituraDoMonitorDeVTCD = 0x01;
        public const Int32 cte_coLeituraDoMonitorDeVTLD = 0x02;
        public const Int32 cte_coLeituraDoMonitorDeOscilografia = 0x03;

        public const Int32 cte_subcoAtivacaoMedidoresAtivos = 0x00;
        public const Int32 cte_subcoModificacaoIdsRadios = 0x01;

        public const Int32 cte_subcoLeituraParametrizacao = 0x00;
        public const Int32 cte_subcoLeituraConfiguracao = 0x01;

        public const Int32 cte_AtivaMedidor = 0x01;
        public const Int32 cte_DesativaMedidor = 0x00;

        public const Int32 cte_NumeroMaximoDeSubOperacoes = 32;

        public const Int32 cte_opPrimeira = 0;
        public const Int32 cte_opVerificacao = 0;
        public const Int32 cte_opVerificacaoResumida = 1;
        public const Int32 cte_opVerificacaoParcial = 2;
        public const Int32 cte_opRecuperacao = 3;
        public const Int32 cte_opRecuperacaoResumida = 4;
        public const Int32 cte_opFatura = 5;
        public const Int32 cte_opFaturaResumida = 6;
        public const Int32 cte_opVerificacaoDeGrandezas = 7;
        public const Int32 cte_opRecuperacaoDeGrandezas = 8;
        public const Int32 cte_opGrandezasParciais = 9;
        public const Int32 cte_opLeituraDe2140 = 10;
        public const Int32 cte_opVisParametrosAtuais = 11;
        public const Int32 cte_opVisParametrosAnteriores = 12;
        public const Int32 cte_opLerRegistradoresAtuais_ABNT23 = 13;
        public const Int32 cte_opLerRegistradoresAnteriores_ABNT24 = 14;
        public const Int32 cte_opVisPaginaFiscal = 15;
        public const Int32 cte_opVisFaltasDeEnergia = 16;
        public const Int32 cte_opLerVTCD = 17;
        public const Int32 cte_opLerVTLD = 18;
        public const Int32 cte_opLerOscilografia = 19;
        public const Int32 cte_opVisOscilografia = 20;
        public const Int32 cte_opGuardDadosCondErro = 21;
        public const Int32 cte_opLeituraDosDadosDosGruposDeCanais = 22;
        public const Int32 cte_opCorteReligamento = 23;
        public const Int32 cte_opLerAlarmes = 24;
        public const Int32 cte_opLerRegCargaProg = 25;
        public const Int32 cte_opLerData = 26;
        public const Int32 cte_opLerHora = 27;
        public const Int32 cte_opLerBateria = 28;
        public const Int32 cte_opLerModelo = 29;
        public const Int32 cte_opLerMedidoresAtivos = 30;
        public const Int32 cte_opLerConfiguracaoMedidorHospedeiro = 31;
        public const Int32 cte_opConfiguraMedidoresAtivos = 32;
        public const Int32 cte_opLerIdsRadios = 33;
        public const Int32 cte_opLerRegistradoresAtuais = 34;
        public const Int32 cte_opLerRegistradoresAtuaisInstantaneo = 35;
        public const Int32 cte_opLerRegistradoresUltimaReposicao = 36;
        public const Int32 cte_opAlteracaoMostradores = 37;
        public const Int32 cte_opAlteracaoData = 38;
        public const Int32 cte_opAlteracaoHora = 39;
        public const Int32 cte_opAlteracaoModoCalibracao = 40;
        public const Int32 cte_opAlteracaoCondicaoReposicaoAutomatica = 41;
        public const Int32 cte_opAlteracaoCondicaoReposicaoAutomaticaUnica = 42;
        public const Int32 cte_opAlteracaoHorarioVerao = 43;
        public const Int32 cte_opAlteracaoHorarioVeraoUnico = 44;
        public const Int32 cte_opAlteracaoSegmentosHorarios = 45;
        public const Int32 cte_opAlteracaoSegmentosHorariosSab = 46;
        public const Int32 cte_opLerAlterarFeriados = 47;
        public const Int32 cte_opVisParametrosAtuaisReverso = 48;
        public const Int32 cte_opVisOcorrencias = 49;
        public const Int32 cte_opLeituraRegistradoresAlteracoesMedidor = 50;
        public const Int32 cte_opEnvioSenha = 51;
        public const Int32 cte_opAlteracaoSenha = 52;
        public const Int32 cte_opAlteracaoPostosUniversais = 53;
        public const Int32 cte_opLeituraParametrosMedicao = 54;
        public const Int32 cte_opMudancaVisibilidade = 55;
        public const Int32 cte_opAlteracaoDaCondicaoDoErro = 56;
        public const Int32 cte_opAlteracaoIntervaloMM = 57;
        public const Int32 cte_opLeituraParametrosMM = 58;
        public const Int32 cte_opLeituraConfiguracaoEasy = 59;
        public const Int32 cte_opLeituraParametrosEasy = 60;
        public const Int32 cte_opConfiguracaoEntradas = 61;
        public const Int32 cte_opParametrosSelfRead = 62;
        public const Int32 cte_opLeituraRegistradoresAtuaisEasy = 63;
        public const Int32 cte_opLeituraMMET = 64;
        public const Int32 cte_opNumeroTrafo = 65;
        public const Int32 cte_opLeituraMMET_ABNT = 66;
        public const Int32 cte_opProtocoloSM = 67;
        public const Int32 cte_opInicioCargaProg = 68;
        public const Int32 cte_opTransfCargaProg = 69;
        public const Int32 cte_opMudancaVisibilidadeMM = 70;
        public const Int32 cte_opLeituraEstadoReles = 71;
        public const Int32 cte_opLeituraRegistrosAlteracoes = 72;
        public const Int32 cte_opLeituraLogPO = 73;
        public const Int32 cte_opAlteracaoResistenciaRamal = 74;
        public const Int32 cte_opLeituraSelfRead = 75;
        public const Int32 cte_opLeituraDadosQEE = 76;
        public const Int32 cte_opResetRegistradoresEnergia = 77;
        public const Int32 cte_opLeituraIndicadoresQEE = 78;
        public const Int32 cte_opLeituraLogEventosQEE = 79;
        public const Int32 cte_opAlteracaoTensaoNominalQEE = 80;
        public const Int32 cte_opAlteracaoTipoLigacaoQEE = 81;
        public const Int32 cte_opLeituraFaturasEasy = 82;
        public const Int32 cte_opEnvioSenhaAB = 83;
        public const Int32 cte_opAlteracaoSenhaAB = 84;
        public const Int32 cte_opPedidoDeStringDaSenha = 85;
        public const Int32 cte_opAlteracaoTarifaReativos = 86;
        public const Int32 cte_opAlteracaoConstantesModo2 = 87;
        public const Int32 cte_opCfgHw = 88;
        public const Int32 cte_opAlteracaoCfgModem = 89;
        public const Int32 cte_opLeituraMM_SM = 90;
        public const Int32 cte_opVerificacaoIntegridade = 91;
        public const Int32 cte_opUltima = 92;

        public const Int32 cte_AcaoAbortar = 1;
        public const Int32 cte_AcaoRetentar = 2;
        public const Int32 cte_AcaoIgnorar = 3;

        public const string NroTrafo_Desativado = "00000000000000";
        public const byte Easy_Bateria = (1 << 0);
        public const byte Easy_3Entradas = (1 << 1);
        public const byte Easy_KhNovo = (1 << 2);
        public const byte Easy_Bifasico = (1 << 2);
        public const byte Easy_BleNSABNT = (1 << 3);
        public const byte Easy_SensorTemp = (1 << 4);
        public const byte Easy_Com4TCs = (1 << 5);

        public const Int32 cte_DifTempoRelogios = 10;

        public const Int32 cte_Freq_Tipo_Normal = 0x00;     // Fora 59,9..60,1
        public const Int32 cte_Freq_Tipo_Disturbio = 0x01;  // Fora 59,5..60,5 mais de 30Seg
        public const Int32 cte_Freq_Tipo_30Seg = 0x02;      // Fora 58,5..62 mais de 30Seg
        public const Int32 cte_Freq_Tipo_10Seg = 0x03;      // Fora 57,5..63,5 mais de 10Seg
        public const Int32 cte_Freq_Tipo_Extremo = 0x04;    // Fora 56,5..66

        public const Int32 cte_Freq_Faixa_Inf = 0x00;
        public const Int32 cte_Freq_Faixa_Sup = 0x01;
        public const Int32 cte_Nro_Freq_Faixa = 0x02;

        public static Int16 ModeloMedidor = 0;
        public static byte Easy_Cfg_Old = 0;

        public static string lbModeloMedidor = "";
        public static string lbModeloGeralMedidor = "";
        public static string lbModeloEspecificoMedidor = "";
        public static string UCSelecionada = "";
        public static string modelo_str = "";

        public static SHA256 Sha256 = SHA256.Create();

        public static int TipoLogSelecionado = 0;
        public static int ResultadoPaginaFiscal = 0;
        public static int ResultadoCalibracao = 0;
        public static int EstadoReles = 0;
        public static int ContadorAtualizacaoIcones = 0;
        public static int ComandoAtual = 0;
        public static int TamanhoHashAleatoria = 0;
        public static int Debug = 0;

        public static byte[] HashAleatoria = new byte[240];
        public static byte[] HashGerada = new byte[96];
        public static byte[] Buff_Hash = new byte[32];
        public static byte MetodoSenha = 0;

        public static byte[] EstadoReleLido;
        public static byte IdSetas = 0;
        public static byte AcaoErro = 0;                                    // 1 - Abortar
                                                                            // 2 - Retentar
                                                                            // 3 - Ignorar
        public static byte ComandoCondicaoReposicaoDemanda = 0;
        public static byte ComandoCondicaoHorarioVerao = 0;
        public static byte ComandoCorteReligamento = 0;                     // 0 - Leitura; 1 - Escrita
        public static byte ComandoNumeroEntradas = 0;                       // 0 - Leitura; 1 - Alteração
        public static byte ComandoSelfRead = 0;                             // 0 - Leitura; 1 - Alteração
        public static byte ComandoNumeroTrafo = 0;                          // 1 - Leitura; 0 - Alteração
        public static byte SubComandoCorteReligamento = 0;                  // 0 - Corte; 1 - Religamento
        public static byte SubComandoHorarioVerao = 0;
        public static byte SubComandoFaltaEnergia = 0;                      // 0 - valores anteriores; 1 - valores atuais
        public static byte SubComandoPostosUniversais = 0;                  // 0 - Leitura; 1 - Escrita
        public static byte SubComandoMostradores = 0;                       // 0 - Leitura; 1 - Alteração   
        public static byte SubComandoCalibracao = 0;                        // 0 - Leitura; 1 - Alteração
        public static byte SubComandoAlteracaoProtocolo = 0;                // 0 - Leitura; 1 - Alteração
        public static byte SubComandoNumeroEntradas = 0;                    // 0 - 3 Entradas; 1 - 6 Entradas
        public static byte SubComandoSelfRead = 0;                          // 2 - Remove todas as datas e horas, inserindo datas novas; 
        public static byte SubComandoNumeroTrafo = 0;                       // 0 - Não ativa, nem desativa; 1 - Ativa; 2 - Desativa
                                                                            // 4 - Adiciona novas datas
        public static byte SubComandoTensaoNominal = 0;                     // 0 - Leitura; 1 - Alteração;                                                                  // 4 - Adiciona novas datas
        public static byte SubComandoResistenciaRamal = 0;                  // 0 - Leitura; 1 - Alteração;
        public static byte SubComandoHabilitaBLE = 0;                       // 0 - Leitura; 1 - Alteração;
        public static byte SubComandoVerificacaoIntegridade = 0;            // 0 - Leitura

        public static int MemoriaInternaExternaVerificacaoIntegridade = 0; // 0 - Memória Interna; 1 - Memória Externa
        public static int AlgoritmoHashVerificacaoIntegridade = 0;         // 0 - CRC32; 1 - SHA-256

        public static byte NumeroInterface = 0;                             // 0 - Interface em uso
                                                                            // 1 - BLE
                                                                            // 2 - Serial 1 - Porta Ótica Frontal
                                                                            // 3 - Serial 2 - Porta Ótica Lateral
                                                                            // 4 a 254 - Reserevado
                                                                            // 255 - Todas as interfaces

        public static byte ProtocoloInterface = 0;                          // 0 - Multiponto-NS
                                                                            // 1 - Protocolo SM
                                                                            // 2 - Protocolo Modbus RTU
                                                                            // 3 - Protocolo DLMS/COSEM
                                                                            // 04 a 255 - Reservado

        public static byte TempoSaidaProtocolo = 0;                         // Tempo de saida do protocolo, dado em minuntos                                                        

        public static byte ComposicaoCanais = 0x00;                         // 00 - Tarifa de reativos desativada
                                                                            // 12 - Canal 1 kwh, Canal 2 kvarhInd, Cana 3 kvarhCap
                                                                            // 52 - Canal 1 kwh, Canal 2 kvarhInd, Canal 3 se houver kvarhCap
                                                                            // 16 - Canal 1 kwh, Canal 2 kqh
        public static byte TamTag = 0x12;
        public static byte[] HashSaida = new byte[32];
        public static UInt32 TamProg = 0;
        public static UInt16 TamCampoDados = 0;
        public static UInt16 TamPacote = 0x80;
        public static UInt16 TamBlocoCargaPrograma = 0;
        public static UInt16 SeqProg = 0;
        public static UInt32 SendProg = 0;

        public static byte[] fileBytes;
        public static int TotalDiasLeituraMM = 0;

        public static UInt32 Sequenciador = 0;
        public static Int32 ValAux32 = 0;

        public static UInt16 Cabecalho_Recepcao_SM = 0;
        public static UInt16 TamCampoDados_Recepcao_SM = 0;

        public static bool BOL_Criptografia_Recepcao_SM = false;
        public static bool BOL_Autenticacao_Recepcao_SM = false;
        public static bool BOL_FinalMensagem_Recepcao_SM = false;
        public static bool BOL_ConfirmacaoMensagem_Recepcao_SM = false;
        public static bool BOL_SenhaAtivada = false;
        public static bool BOL_AlterarSenha = false;
        public static bool BOL_SenhaAlterada = false;
        public static bool BOL_AlterouTipoLigacao = false;
        public static bool BOL_AlterouSaidaUsuario = false;
        public static bool BOL_ArquivoBinarioSelecionado = false;
        public static bool BOL_AreaMemoriaSelecionada = false;

        public static UInt32 Ocorrencias_Recepcao_SM = 0;

        public static Int64 INT_UmPorSegundo;
        public static long MV_Ref_Counter;

        public static byte Retorno_Recepcao_SM = 0;

        public static UInt32 QtdRegistrosMedidor = 0;
        public static UInt32 QtdRegistrosMedidorET = 0;
        public static UInt32 QtdBlocosTransmitir = 0;
        public static UInt32 QtdBlocosTransmitirET = 0;
        public static UInt32 QtdRegistrosMM_ET = 0;
        public static byte QtdMedidoresAtivos = 0;
        public static byte ComandoBloco = 0;
        public static byte ComandoBlocoET = 0;
        public static byte TipoAlteracaoFeriados = 4;
        public static byte TipoAlteracaoHorarioVerao = 4;
        public static byte IndiceMedidor = 0;
        public static byte IndiceInicialHorarioVerao = 0;
        public static byte ConjuntoPostosUniversais = 0;                        // 0 - Conjunto 1; 1 - Conjunto 2
        public static byte CondicaoAtivacaoPostosUniversais = 0;                // 0 - Desativa
                                                                                // 1 - Domingo
                                                                                // 2 - Segunda-feira
                                                                                // ...
                                                                                // ...
                                                                                // 8 - Feriado
        public static byte CondicaoAtivaoNumTrafo = 0;                          // 0 - Sem ação
                                                                                // 1 - Ativar
                                                                                // 2 - Desativar
        public static bool CondicaoHorarioVerao = false;                        // false - Desativado
                                                                                // true - Ativado
        public static byte TipoLigacaoQEE = 0x00;
        public static byte TipoResetQEE = 0x00;
        public static byte PostoHorarioAtual = 0;
        public static byte MinutosRestantesProtecao = 0;
        public static byte ComportamentoPostosUniversais = 0;                   // 0 - Soma 1 hora; 1 - Não soma 1 h;                                                                                                                                    
        public static byte[] BufferParametrosMedidorHospedeiro;
        public static byte[] BufferTransmissaoBLE = new byte[150];
        public static byte[] BufferCargaPrograma = new byte[258];
        public static byte[] BufferRecepcaoBLE = new byte[258];
        public static byte NumByteTransmissaoBLE = 0;

        public static byte[] BufferTxGlobal = new byte[150];

        public static byte[] BufferTransmissaoEthernet = new byte[150];
        public static byte[] BufferRecepcaoEthernet = new byte[258];
        public static byte NumByteTransmissaoEthernet = 0;

        public static byte TipoLeituraIndicadores = 0;                          // 0-Leitura simples, 1-Leitura completa
        public static byte TipoLeituraIndicadoresLido = 0;
        public static byte ValeAlteracaoKhTpTc = 0;
        public static byte ValeAlteracaoTipoLigacao = 0;

        public static byte ValidadeHash = 0;

        public static UInt32 AreaMemoriaInicialFaixa1 = 0;
        public static UInt32 AreaMemoriaFinalFaixa1 = 0;
        public static UInt32 AreaMemoriaInicialFaixa2 = 0;
        public static UInt32 AreaMemoriaFinalFaixa2 = 0;
        public static UInt32 AreaMemoriaInicialFaixa3 = 0;
        public static UInt32 AreaMemoriaFinalFaixa3 = 0;
        public static UInt32 AreaMemoriaInicialFaixa4 = 0;
        public static UInt32 AreaMemoriaFinalFaixa4 = 0;
        public static UInt32 AreaMemoriaInicialFaixa5 = 0;
        public static UInt32 AreaMemoriaFinalFaixa5 = 0;
        public static UInt32 AreaMemoriaInicialFaixa6 = 0;
        public static UInt32 AreaMemoriaFinalFaixa6 = 0;
        public static UInt32 AreaMemoriaInicialFaixa7 = 0;
        public static UInt32 AreaMemoriaFinalFaixa7 = 0;
        public static UInt32 AreaMemoriaInicialFaixa8 = 0;
        public static UInt32 AreaMemoriaFinalFaixa8 = 0;
        public static UInt32 AreaMemoriaInicialFaixa9 = 0;
        public static UInt32 AreaMemoriaFinalFaixa9 = 0;
        public static UInt32 AreaMemoriaInicialFaixa10 = 0;
        public static UInt32 AreaMemoriaFinalFaixa10 = 0;
        public static UInt32 AreaMemoriaInicialFaixa11 = 0;
        public static UInt32 AreaMemoriaFinalFaixa11 = 0;
        public static UInt32 AreaMemoriaInicialFaixa12 = 0;
        public static UInt32 AreaMemoriaFinalFaixa12 = 0;
        public static UInt32 AreaMemoriaInicialFaixa13 = 0;
        public static UInt32 AreaMemoriaFinalFaixa13 = 0;
        public static UInt32 AreaMemoriaInicialFaixa14 = 0;
        public static UInt32 AreaMemoriaFinalFaixa14 = 0;

        public static byte[][] HashIntervalos = new byte[14][];

        public static Int16 ConjuntoIndicadores = 0;

        public static UInt64 NovoCodigoExibir;
        public static byte NovoCodigoExibir2;

        public static UInt64 ContadorComandos = 0;
        public static UInt64 ContadorRespComandos = 0;

        public static int PtrBufferParametrosMedidorHospedeiro = 0;
        public static int BlocoInicialHorarioVerao = 0;
        public static int BlocoFinalHorarioVerao = 15;

        public static int CodigoOcorrencia = 0;
        public static int ResultadoEnvioSenha = 0;

        public static int LarguraTela = 0;
        public static int AlturaTela = 0;

        public static int CBMedidoresAtivosIndiceAnterior = -1;

        public static int NumeroBytesRecebidosBLE = 0;
        public static int NumeroBytesRecebidosEthernet = 0;

        public static UInt64[] ParamDisplay;

        public static float TensaoNominalQEE = 0;
        public static float TensaoNominalQEELido = 0;

        public static enumModelosEquipamentos ENUM_ModeloEquipamento = enumModelosEquipamentos.eNenhum;
        public static ENUM_resComunicaCodi ENUM_Resultado;
        public static enumTipoHW ENUM_TipoHW = enumTipoHW.eNenhum;
        public static bool eSerialRS485 = false;
        public static enumEstadoCargaPrograma ENUM_CargaPrograma = enumEstadoCargaPrograma.eNenhum;
        public static enumGrupoMM ENUM_GrupoMM = enumGrupoMM.eNenhum;
        public static enumMMSM ENUM_MMSM = enumMMSM.eNenhum;
        public static int QtdDiasMM = 1;

        public static ComboBox ListaMedidoresAtivos = new ComboBox();

        public static ComboBox ListaDispositivosBLE = new ComboBox();
        public static List<int> ListaRSSI;
        public static List<string> ListaRSSIVerificada;
        public static bool BOL_FalhaCargaPrograma = false;
        public static bool BOL_BLEConectado = false;
        public static bool BOL_BLEConectando = false;
        public static bool BOL_ConectandoEquipamento = false;
        public static bool BOL_TemComandoBLE = false;
        public static bool BOL_RecebeuRespostaBLE = false;
        public static bool BOL_TimeoutBLE = false;
        public static bool BOL_Reconectar = false;
        public static bool BOL_VoltarNovamente = false;
        public static bool BOL_PegouNroSerie = false;
        public static bool BOL_ItemSuperiorHorarioVerao = false;

        public static bool BOL_Protocolo_SM = false;
        public static bool BOL_ProtocoloMultiponto = true;
        public static bool BOL_ProtocoloCodi = false;

        public static bool BOL_RepetirComando = false;
        public static bool BOL_DesativaMedidor = false;

        public static bool BOL_EthernetConectado = false;
        public static bool BOL_TemComandoEthernet = false;
        public static bool BOL_RecebeuRespostaEthernet = false;
        public static bool BOL_RecebeuRespostaPaginaFiscal = false;
        public static bool BOL_RecebeuRespostaAlteracaoProtocolo = false;
        public static bool BOL_RecebeuRepostaVerificacaoIntegridade = false;
        public static bool BOL_TimeoutEthernet = false;
        public static bool BOL_ProcessoTransmissaoBLE = false;
        public static bool BOL_ConfiguraVisibilidade = false;
        public static bool BOL_AtualizandoRelogio = false;
        public static bool BOL_Cancelar_Comandos = false;
        public static bool BOL_MudouMedidorSelecionado = false;
        public static bool BOL_LeuResistenciaRamal = false;
        public static bool BOL_AlterouResistenciaRamal = false;
        public static bool BOL_AlterouTensaoNominalQEE = false;
        public static bool BOL_LeuTensaoNominalQEE = false;
        public static bool BOL_AlterouTipoLigacaoQEE = false;
        public static bool BOL_AlterouTipoResetQEE = false;
        public static bool BOL_AlterouModoII = false;
        public static bool BOL_AlterouTarifaReativos = false;
        public static bool BOL_HabilitouBLE = false;
        public static bool BOL_AtivarBLE = false;
        public static bool BOL_SegundaParteVerificacaoIntegridade = false;
        public static bool BOL_AreaMemoriaFaixa1Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa2Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa3Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa4Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa5Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa6Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa7Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa8Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa9Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa10Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa11Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa12Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa13Selecionada = false;
        public static bool BOL_AreaMemoriaFaixa14Selecionada = false;

        public static bool BOL_FocoTelaPrincipal = true;

        public static RichTextBox rtbResultadoGlobal = new RichTextBox();
        public static RichTextBox rtbResultadoGlobalAux = new RichTextBox();

        public static DateTime DTTempo1 = new DateTime();
        public static DateTime DTTempo2 = new DateTime();

        public static TimeSpan Intervalo1 = new TimeSpan();
        public static TimeSpan Intervalo2 = new TimeSpan();

        public static UInt32 IUDestino;                // 4 bytes
        public static byte TipoEquipamentoDestino;     // 1 byte

        public static byte CodigoErro = 0;
        public static byte SubCodigoErro = 0;

        public static string VersaoSWBase = "";
        public static string VersaoSWCom = "";
        public static string VersaoSWCR = "";
        public static string VersaoBoot = "";

        public static Int16 VersaoSWSCR;
        public static Int16 EstadoRelesSCR;

        public static byte[] ProgramBufferRead = new byte[ProgramBufferSize];
        public static byte[] ProgramBufferRecorded = new byte[ProgramBufferSize];

        public static byte[] ProgramSCRBufferRead = new byte[ProgramSCRBufferSize];
        public static byte[] ProgramSCRBufferRecorded = new byte[ProgramSCRBufferSize];

        //public static byte[] CRCBufferRead = new byte[CRCBufferSize];
        //public static byte[] CRCBufferRecorded = new byte[CRCBufferSize];

        public static byte[] ParameterBufferRead = new byte[ParameterBufferSize];
        public static byte[] ParameterBufferRecorded = new byte[ParameterBufferSize];

        public static byte[] ConfigBufferRead = new byte[ConfigBufferSize];
        public static byte[] ConfigBufferRecorded = new byte[ConfigBufferSize];

        public static byte[] LogBufferRead = new byte[LogBufferSize];
        public static byte[] LogBufferRecorded = new byte[LogBufferSize];

        public static byte[] ProgramSDIBufferRead = new byte[ProgramSDIBufferSize];
        public static byte[] ProgramSDIBufferRecorded = new byte[ProgramSDIBufferSize];

        public static byte[] IUSDIBufferRead = new byte[IUSDIBufferSize];
        public static byte[] IUSDIBufferRecorded = new byte[IUSDIBufferSize];

        public static byte[] CanalSDIBufferRead = new byte[CanalSDIBufferSize];
        public static byte[] CanalSDIBufferRecorded = new byte[CanalSDIBufferSize];

        public static Int32 CRCBufferRead;

        public static bool bResultadoComparacao = false;

        public static string DiretorioArquivoOriginalBase = "";
        public static string NomeArquivoOriginalBase = "";
        public static string ArquivoOriginalBase = "";

        public static string DiretorioArquivoOriginalSDI = "";
        public static string NomeArquivoOriginalSDI = "";
        public static string ArquivoOriginalSDI = "";

        public static string DiretorioArquivoOriginalSCR = "";
        public static string NomeArquivoOriginalSCR = "";
        public static string ArquivoOriginalSCR = "";

        public static string DiretorioArquivoExtendBase = "";
        public static string NomeArquivoExtendBase = "";
        public static string ArquivoExtendBase = "";

        public static string PastaDestinoRelatorios = "";
        public static string PastaDestinoArquivosBinarios = "";

        public static string PastaExecutavel = "";

        public static string MessageText = "";
        public static string MessageWarning = "";

        public enum enumModelosEquipamentos
        {
            eAbsoluto,
            eDI,
            eEasyTrafo,
            eEasyVerMono,
            eEasyVerPoli,
            eUnique,
            eExtended,
            eMaxi,
            eEasyVolt,
            eSMNox,
            eNenhum
        }

        public static byte[] CmdAbsoluto = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x11, 0x12, 0x21, 0x28, 0x40, 0x63, 0x64, 0x92  };
        public static byte[] CmdEasy = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x90, 0x91, 0x92};
        public static byte[] CmdEstendido = { 0x26, 0x30, 0x32, 0x49, 0x50, 0x55, 0x56, 0x57, 0x58, 0x66, 0x73, 0x95 };
        public static byte[] CmdABNT = { 0x11, 0x13, 0x14, 0x16, 0x17, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35,
                                         0x36, 0x37, 0x38, 0x39, 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x58,
                                         0x59, 0x60, 0x63, 0x64, 0x65, 0x66, 0x67, 0x73, 0x75, 0x76, 0x77, 0x78, 0x79, 0x80, 0x81, 0x83, 0x84, 0x85, 0x87, 0x88, 0x89, 
                                         0x90, 0x92, 0x93, 0x95};

        public static byte[] CmdsABNTAbsoluto = { 0x11, 0x13, 0x14, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x28, 0x30, 0x31, 0x32, 0x35, 0x36, 0x37, 0x39, 0x40, 0x41, 0x42, 0x43,
                                                   0x44, 0x45, 0x46, 0x51, 0x52, 0x63, 0x64, 0x73, 0x77, 0x80, 0x84, 0x92};
        public static byte[] CmdsABAbsoluto = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x11, 0x12, 0x21, 0x28, 0x40, 0x63, 0x64, 0x92 };
        public static byte[] CmdsEBAbsoluto = { };
        public static byte[] CmdsEstendidosAbsoluto = { 0x32, 0x58 };

        public static byte[] CmdsABNTEasyTrafo = { 0x14, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x28, 0x30, 0x31, 0x37, 0x39, 0x40, 0x41, 0x42, 0x43,
                                                   0x44, 0x45, 0x46, 0x51, 0x52, 0x63, 0x73, 0x80, 0x84, 0x87, 0x95};
        public static byte[] CmdsABEasyTrafo = { 0x08, 0x28, 0x63};
        public static byte[] CmdsEBEasyTrafo = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x09, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x90, 0x91, 0x92};
        public static byte[] CmdsEstendidosEasyTrafo = { 0x26, 0x50, 0x55, 0x56, 0x58, 0x66, 0x73, 0x95};

        public static byte[] CmdsABNTEasyVer = { 0x14, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x28, 0x30, 0x31, 0x37, 0x39, 0x40, 0x41, 0x42, 0x43,
                                                   0x44, 0x45, 0x46, 0x51, 0x52, 0x63, 0x73, 0x80, 0x84, 0x87, 0x95};
        public static byte[] CmdsABEasyVer = { 0x08, 0x28, 0x63 };
        public static byte[] CmdsEBEasyVer = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x13, 0x14, 0x15 };
        public static byte[] CmdsEstendidosEasyVer = { 0x58, 0x66};

        public static byte[] CmdsABNTMaxi = { 0x11, 0x13, 0x14, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x28, 0x30, 0x31, 0x32, 0x35, 0x36, 0x37, 0x39, 0x40, 0x41, 0x42, 0x43,
                                                   0x44, 0x45, 0x46, 0x51, 0x52, 0x63, 0x64, 0x73, 0x80, 0x84, 0x87, 0x95};
        public static byte[] CmdsABMaxi = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x08, 0x12, 0x28, 0x40, 0x63, 0x64, 0x92 };
        public static byte[] CmdsEBMaxi = { 0x03, 0x04, 0x05, 0x06, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17 };
        public static byte[] CmdsEstendidosMaxi = { 0x26, 0x32, 0x50, 0x55, 0x56, 0x58, 0x66, 0x67, 0x73, 0x95 };

        public static byte[] CmdsABNTUnique = { 0x11, 0x13, 0x14, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x28, 0x30, 0x31, 0x32, 0x35, 0x36, 0x37, 0x39, 0x40, 0x41, 0x42, 0x43,
                                                   0x44, 0x45, 0x46, 0x51, 0x52, 0x63, 0x64, 0x73, 0x80, 0x84, 0x87, 0x95};
        public static byte[] CmdsABunique = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x08, 0x12, 0x28, 0x40, 0x63, 0x64, 0x92 };
        public static byte[] CmdsEBUnique = { 0x03, 0x04, 0x05, 0x06, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17 };
        public static byte[] CmdsEstendidosUnique = { 0x26, 0x32, 0x50, 0x55, 0x56, 0x58, 0x66, 0x67, 0x73, 0x95 };

        public enum enumGrupoMM
        {
            eEnergiaDireta,
            eEnergiaReversa,
            eTensao,
            eCorrente,
            eTHDTensao,
            eTHDCorrente,
            eNenhum
        }

        public enum enumMMSM
        {
            eTodaMemoria = 0,
            eVerificacao,
            eRecuperacao,
            eNumRegistros,
            eHoras,
            eDias,
            eNenhum
        }

        public enum enumEstadoCargaPrograma
        {
            eEntrarProtocoloSM,
            eInicioCarga,
            eTransferenciaPrograma,
            eNenhum
        }

        public enum enumTipoHW
        {
            eSerial,
            eBluetooth,
            eEthernet,
            eNenhum
        }

        public enum enumModoCalibracao
        {
            eCalibraEnergia,
            eMedidorGeral,
            eRTCComCompensacao,
            eRTCSemCompensacao,
            eModoPaginaFiscal,
            eNenhum
        }

        public enum enumModoCalibracaoEnergia
        {
            eModoNormal,
            ePortaOticaEA,
            ePortaOticaER,
            ePortaOticaEAkhr,
            ePortaOticaERkhr,
            eEnergiaReativaNoLedAtiva,
            eNenhum
        }

        public enum enumEstadoTela
        {
            eTelaIndefinida,
            eTelaInicial,
            eTelaStatus,
            eTelaLerDados,
            eTelaLerDados2,
            eTelaLeituraABNT,
            eTelaPaginaFiscal,
            eTelaCorteReligue,
            eTelaParametrizar,
            eTelaConfigurar,
            eTelaManutencao
        }

        public enum enumSelecaoMenu
        {
            eNenhum,
            eMenuLeitura,
            eMenuVisualizacao,
            eMenuAlteracoes,
            eMenuConfig,
            eVoltar
        }

        public static enumModoCalibracao _modoCalibracao = enumModoCalibracao.eNenhum;
        public static enumModoCalibracaoEnergia _modoCalibracaoEnergia = enumModoCalibracaoEnergia.eNenhum;
        public static enumSelecaoMenu _itemSelecionado = enumSelecaoMenu.eMenuLeitura;
        public static enumSelecaoMenu _anterior = clGlobal.enumSelecaoMenu.eMenuLeitura;

        public static enumEstadoTela _TelaAtual = enumEstadoTela.eTelaInicial;
        public static enumEstadoTela _TelaAnterior = enumEstadoTela.eTelaInicial;
        public static byte IndiceEscTelaAnterior = 0;
        public static byte IndiceLeiTelaAnterior = 0;

        public static string PortaSerialEscolhida;
        public static string HW;
        public static ListBox lbox_Comunica = new ListBox();
        public static DataGridView grid_Visualiza = new DataGridView();

        public static byte _NumeroGrupoCanaisDisponiveis = 0;
        public static int _grupoSelecionado;
        public static byte[] GrandezaCanal = new byte[3];

        //Grandeza de um canal(conforme NBR 14522)
        public const byte GRD_CANAL_Indefinida = 0x00;
        public const byte GRD_CANAL_kWh_direto = 0x01;
        public const byte GRD_CANAL_kVARh = 0x02;
        public const byte GRD_CANAL_kQh = 0x03;
        public const byte GRD_CANAL_V2h = 0x04;
        public const byte GRD_CANAL_I2h = 0x05;
        public const byte GRD_CANAL_Desativada = 0x06;
        public const byte GRD_CANAL_Indefinida2 = 0x07;
        public const byte GRD_CANAL_Vh = 0x08;
        public const byte GRD_CANAL_Ih = 0x09;
        public const byte GRD_CANAL_kvarhInd_direto = 0x10;
        public const byte GRD_CANAL_kvarhCap_direto = 0x11;
        public const byte GRD_CANAL_kQhInd_Qh= 0x12;
        public const byte GRD_CANAL_kQhCap_Qh = 0x13;
        public const byte GRD_CANAL_kWh_reverso = 0x14;
        public const byte GRD_CANAL_kvarhInd_reverso = 0x15;
        public const byte GRD_CANAL_kvarhCap_reverso = 0x16;
        public const byte GRD_CANAL_Vah = 0x17;
        public const byte GRD_CANAL_Vbh = 0x18;
        public const byte GRD_CANAL_Vch = 0x19;
        public const byte GRD_CANAL_Iah = 0x20;
        public const byte GRD_CANAL_Ibh = 0x21;
        public const byte GRD_CANAL_Ich = 0x22;
        public const byte GRD_CANAL_FPh_3F_direto = 0x23;
        public const byte GRD_CANAL_THDh = 0x24;
        public const byte GRD_CANAL_kVAh_3F = 0x25;
        public const byte GRD_CANAL_FPh_reverso = 0x26;
        public const byte GRD_CANAL_FPh_diretoA = 0x27;
        public const byte GRD_CANAL_FPh_diretoB = 0x28;
        public const byte GRD_CANAL_FPh_diretoC = 0x29;
        public const byte GRD_CANAL_THDh_tensaoA = 0x30;
        public const byte GRD_CANAL_THDh_tensaoB = 0x31;
        public const byte GRD_CANAL_THDh_tensaoC = 0x32;
        public const byte GRD_CANAL_THDh_correnteA = 0x33;
        public const byte GRD_CANAL_THDh_correnteB = 0x34;
        public const byte GRD_CANAL_THDh_correnteC = 0x35;
        public const byte GRD_CANAL_VmaxhA = 0x36;
        public const byte GRD_CANAL_VmaxhB = 0x37;
        public const byte GRD_CANAL_VmaxhC = 0x38;
        public const byte GRD_CANAL_VminhA = 0x39;
        public const byte GRD_CANAL_VminhB = 0x40;
        public const byte GRD_CANAL_VminhC = 0x41;
        public const byte GRD_CANAL_IrevhA = 0x42;
        public const byte GRD_CANAL_IrevhB = 0x43;
        public const byte GRD_CANAL_IrevhC = 0x44;
        public const byte GRD_CANAL_Ineutroh = 0x45;
        public const byte GRD_CANAL_Ineutroh_reversa = 0x46;
        public const byte GRD_CANAL_PotAtivaA = 0x47;
        public const byte GRD_CANAL_PotAtivaB = 0x48;
        public const byte GRD_CANAL_PotAtivaC = 0x49;
        public const byte GRD_CANAL_PotAtiva_reversaA = 0x50;
        public const byte GRD_CANAL_PotAtiva_reversaB = 0x51;
        public const byte GRD_CANAL_PotAtiva_reversaC = 0x52;
        public const byte GRD_CANAL_Inexistente = 0x99;

        public static bool _leReverso = false;
        public static string _pastaPar = Directory.GetCurrentDirectory() + "\\dados";
        public static string _pastaLeitura = Directory.GetCurrentDirectory() + "\\leitura";

        public static bool _conectadoComMedidor;
        public static bool _ConectadoMedidorHospedeiro = false;
        public static bool _TX;
        public static bool _RX;
        public static bool _LigaDesligaTimer;
        public static bool _LigaDesligaTimerPaginaFiscal;
        public static bool _AtivarReposicaoAutomatica = false;
        public static bool _UltimoBloco = false;
        public static bool _Erro_Bloco = false;
        public static bool _PressionadoEsc = false;
        public static bool _PaginaFiscalAtiva = false;

        public static int _dia;
        public static int _mes;
        public static int _ano;
        public static int _hora;
        public static int _min;

        public static byte NumeroSerie_HiHi;
        public static byte NumeroSerie_HiLow;
        public static byte NumeroSerie_LowHi;
        public static byte NumeroSerie_LowLow;

        public static byte InicioFeriadosLido = 100;
        public static byte FimFeriadosLido = 0;

        public static int PosicaoX = 0;
        public static int PosicaoY = 0;
        public static int PosicaoXSincronismo = 0;
        public static int PosicaoYSincronismo = 0;

        public static Int32 NumeroSerie = 0;

        public static String NumeroSerieHospedeiro = "";
        public static String CBNumeroSerieSelecionado = "";
        public static String MedidorSelecionado = "00000000000000";

        public static UInt32 Bloco_Leitura_Atual = 0;
        public static UInt32 Bloco_Leitura_Atual_MM = 0;
        public static UInt32 Bloco_Comando_Atual = 0;
        public static UInt32 Bloco_Comando_Atual_MM = 0;
        public static UInt32 Bloco_Lido = 0;
        public static UInt32 Bloco_MM_Lido = 0;
        public static UInt32 Bloco_MM_Lido_Aux = 0;
        public static UInt32 Bloco_MM_Lido_Anterior = 0;
        public static UInt32 Bloco_SelfRead_Lido = 0;
        public static UInt32 Bloco_Lido_Anterior = 0;
        public static UInt32 Bloco_SelfRead_Lido_Anterior = 0;
        public static byte DiaFaturaAutomatica = 0;
        public static byte Contador_Erros = 0;
        public static byte NumTentativasReconexao = 0;
        public static byte ContAreasMemoria = 0;
        public static UInt32 IndiceRegistroAlteracaoLido = 0;
        public static UInt32 IndiceRegistroMMLido = 0;
        public static UInt32 IndiceRegistroSelfReadLido = 0;
        public static UInt32 IndiceIntervaloMMLido = 0;
        public static UInt32 RTCNumerador;
        public static UInt32 RTPNumerador;
        public static UInt32 KPNumerador;
        public static UInt32 RTCDenaminador;
        public static UInt32 RTPDenominador;
        public static UInt32 KPDenominador;

        public static string DataAtualMedidor = "";
        public static string HoraAtualMedidor = "";
        public static string DiaSemanaAtualMedidor = "";

        public static string IP_Client = "192.168.1.5";
        public static string Gateway = "192.168.0.1";
        public static string Mask = "255.255.255.0";

        //Strings de uso geral
        public static string[] StrOrigemReposicao = { "Inicializacao", "Comando", "Tecla", "Fatura automática", "Alteração de data/hora", "Alteração de RTP/RTC" };
        public static string[] StrTipoLigacao = { "Estrela", "Estrela", "Delta aberto", "Bifásico 120°", "Monofásico 2 fios", "Série paralela", "Delta aterrado", "Monofásico 3 fios" };
        public static string[] StrTipoSaidaSerial = { "Saída de usuário monodirecional" , "Saída de usuário estendida" , "Reservado para uso futuro" , "Saída de usuário mista" ,
                                                    "Reservado para uso futuro" , "Saída SER311" , "Saída serial II (PIMA)" };
        public static string[] StrUnidadeExibicaoReg = { "Reservado", "Grandeza", "k Grandeza", "M Grandeza" };
        public static string[] StrProtInterfaceCom = { "Multiponto/NS", "Protocolo SM", "DLMS/COSEM" };
        public static string[] StrCfgOcMultiponto = { "Envio de ocorrências desabilitado" , "Envio de ocorrências em resposta a comandos habilitado\nOcorrências periódicas desabilitadas" , "Envio de ocorrências habilitado" };

        //public static double ContadorAtualizacaoTexto = 0;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stCabecalho_SMPO
        {
            public byte SMPO_Tipo;
            public UInt16 SMPO_Revisao;
            public UInt16 SMPO_Versao;
            public UInt32 SMPO_TamProg;
            public UInt32 SMPO_Offset;
            public UInt16 SMPO_TamPac;
        }

        public enum ENUM_TComando
        {
            cmdComandoInvalido,
            cmdNenhumComando,
            cmdTesteDeCondicao,
            cmdConecta,
            cmdDesconecta,
            cmdComunica,
            cmdTentaGerarMemoriaDeMassaZerada,
            cmdTerminaSeNaoForQuatroQuadrantes,
            cmdParametrosOnLine,
            cmdDICeFIC,
            cmdGravaArquivosDeQualidade,
            cmdVisualOscilografia,
            cmdRetornaParaUltimaOperacao,
            cmdLeDadosDosGruposDeCanais,
            cmdMudaOperacaoSeRegistroDeGrandezasForABNT,
            cmdCopiaBufferErro,
            cmdTermina
        }

        public enum ENUM_TComandoCodi
        {
            codSimples,
            codComposto,
            codSimplesEloNet,
            codCompostoEloNet
        }

        public enum ENUM_TTipoDeAvancoDoApontadorDeSubOperacao
        {
            taNormal,
            taPulaSeNaoZerouNumeroDeEstruturas,
            taPulaSeNaoZerouNumeroDeSubEstruturas,
            taPulaSeNaoHaSubEstruturas,
            taContinuaSeNaoAbortou,
            taRepeteOperacaoSeNaoLeuTodosOsCanais
        }


        public enum ENM_TOperacao
        {
            oCodiNormal,
            oCodiElonetEncapsulado
        }

        public struct TMedidores
        {
            public bool bAtivo;
            public byte Fases;
            public string NUC;
            public string Radio;
        }

        public struct stRegistrosDeAlteracoes
        {
            public byte CodigoAlteracao;
            public int NumSerieLeitorMSB;
            public byte NumSerieLeitorLSB;
            public byte Hora;
            public byte Minuto;
            public byte Segundo;
            public byte Dia;
            public byte Mes;
            public byte Ano;
        }

        public struct stRegistrosAtuaisEasy
        {
            public byte[] AtivaDireta;
            public byte[] AtivaReversa;
            public byte[] ReativaPositiva;
            public byte[] ReativaNegativa;
            public byte[] AtivaDireta123;
            public byte[] AtivaReversa123;
            public byte[] ReativaPositiva123;
            public byte[] ReativaNegativa123;
            public byte[] AtivaDireta456;
            public byte[] AtivaReversa456;
            public byte[] ReativaPositiva456;
            public byte[] ReativaNegativa456;
        }

        public struct stIntervaloMM
        {
            public byte Minutos;
            public byte Segundos;
            public byte Centesimos;
        }

        public struct stDataHora
        {
            public byte Segundo;
            public byte Minuto;
            public byte Hora;
            public byte Dia;
            public byte DiaSemana;
            public byte Mes;
            public byte Ano;
        }

        public struct stDataHoraMM
        {
            public byte Minuto;
            public byte Hora;
            public byte Dia;
            public byte Mes;
            public byte Ano;
        }

        public struct stIdentificador40
        {
            public UInt32 IdentificadoUnico;
            public byte TipoEquipamento;
        }

        public struct stProtocolo_SM
        {
            public UInt16 Cabecalho;                // 2 bytes
            public UInt32 Sequenciador;             // 4 bytes
            public UInt32 IUDestino;                // 4 bytes
            public byte TipoEquipamentoDestino;     // 1 byte
            public UInt32 IUOrigem;                 // 4 bytes
            public byte TipoEquipamentoOrigem;      // 1 byte
            public byte Comando;                    // 1 byte
            public byte Medidor;                    // 1 byte
            public int TamCab;                     // 1 byte
            public byte[] Dados;
            public UInt16 CRC;                      // 2 bytes
        }

        public struct stMM_ET
        {
            public stDataHoraMM DH_MM;
            public UInt32 Registrador1;
            public UInt32 Registrador2;
            public UInt32 Registrador3;
            public UInt32 Registrador4;
            public float TensaoA;
            public float TensaoB;
            public float TensaoC;
            public float CorrenteA;
            public float CorrenteB;
            public float CorrenteC;
            public UInt32 Flag1;
            public UInt32 Flag2;
            public UInt16 CRC16;
        }

        public struct stMM_ET_ABNT
        {
            public UInt16 RegistradorCanal1;
            public UInt16 RegistradorCanal2;
            public UInt16 RegistradorCanal3;
        }

        public struct stPostoHorario
        {
            public byte Dia;                // Dia de ínicio do conjunto de postos no formato BCD (1 a 31) - 1 byte
            public byte Mes;                // Mês do início do conjunto de postos no formato BCD (1 a 12) - 1 byte
            public byte Ano;                // Ano do início do conjunto de postos no formato BCD (0 a 99) - 0 indice que o conjunto é válido para todos os anos. - 1 byte
            public byte DesvioHorarioVerao; // Comportamento do conjunto de postos no horário de verão - 1 byte
            public stPostos[] Postos;       // 33 x 8 = 264
        } // 268 bytes

        public struct stPostos
        {
            public byte Ativacao;           // 1 byte
            public stPosto[][] InicioPosto; // 16 x 2 = 32 bytes
        } // 33 bytes

        public struct stPosto   // 2 bytes
        {
            public byte Minuto; // Minuto de início do posto no formato BCD (0 a 59)
            public byte Hora;   // Hora do início do posto no formato BCD (0 a 23)
        }
        
        public struct stIU
        {
            public byte[] IU;
        }

        public struct stFaturas
        {
            public UInt32 FatId;
            public stIU Origem;
            public byte NroRepDem;
            public UInt32 IniPerSegs;
            public UInt32 UltPerSegs;
            public UInt32 FaturasSegs;
            public UInt32[][] Registradores;
            public UInt32[] UFER;
            public UInt16[][] DemMax;
            public UInt32[][] DemAcum;
            public UInt16[] DmcrMax;
            public UInt32[] DmcrAcum;
            public stRegDicFic[] RegDicFic;
            public byte[][] CteRTP;
            public byte[][] CteRTC;
            public UInt16 Crc16;
        }

        public struct stRegDicFic
        {
            public UInt16 NroFaltas;
            public UInt32 DuracaoFaltas;
        }
        public struct stEstadoReles
        {
            public byte EstadoFaseA;
            public byte EstadoFaseB;
            public byte EstadoFaseC;
            public float TensaoAposReleFaseA;
            public float TensaoAposReleFaseB;
            public float TensaoAposReleFaseC;
            public float AnguloAposReleFaseA;
            public float AnguloAposReleFaseB;
            public float AnguloAposReleFaseC;
        }

        public struct stEstadoRelesMedidorHospedeiro
        {
            public byte VersaoSW;
            public byte RevisaoSW;
            public UInt16 EstadosReles;
            public float[] TensaoReles;
            public float[] AnguloReles;
        }

        public struct stHorarioVerao
        {
            public byte DiaInicio;  //Dia de ínicio do horário de verão (BCD)
            public byte MesInicio;  //Mês de ínicio do horário de verão (BCD)
            public byte AnoInicio;  //Ano de ínicio do horário de verão (BCD)
            public byte DiaFim;     //Dia de fim do horário de verão (BCD)
            public byte MesFim;     //Mês de fim do horário de verão (BCD)
            public byte AnoFim;		//Ano de fim do horário de verão (BCD)
        }

        public struct stFeriados
        {
            public byte Dia;        //Dia do feriado (BCD)
            public byte Mes;        //Mês do feriado (BCD)
            public byte Ano;		//Ano do feriado (BCD). Valor 0 indica feriado fixo
        }

        public struct stFaturaAuto
        {
            public byte Dia;        //Mês para fechamento automático da fatura
            public byte Mes;		//Dia para fechamento automático da fatura
        }

        public struct stParametros
        {
            public UInt64 MedAtivo;                 // 8 bytes
            public UInt32[] MedUC;                  // 140 bytes
            public byte[][] IUDI;                   // 175 bytes
            public stDataHora DataHora;             // 7 bytes
            public stFeriados[] Feriados;           // 246 bytes
            public stHorarioVerao[] HorarioVerao;   // 90 bytes
            public UInt64[] CodExibir;              // 104 bytes
            public stFaturaAuto[] FaturaAuto;       // 24 bytes
            public stPostoHorario[] PostoHorario;   // 268 bytes x 2 = 536 bytes
        } // 1330 bytes

        public struct stTarifaReativos
        {
            public byte Dia;                // 1 Dia de ínicio do conjunto de postos no formato BCD (1 a 31) - 1 byte
            public byte Mes;                // 1 Mês do início do conjunto de postos no formato BCD (1 a 12) - 1 byte
            public byte Ano;                // 1 Ano do início do conjunto de postos no formato BCD (0 a 99) - 0 indice que o conjunto é válido para todos os anos. - 1 byte
            public UInt16 SegRtAtivos;      // 2 Segmentos Reativos Ativos
            public byte FatPotRef;          // 1 Fator de Potência de Referência
            public stPosto[][] PostoReativo;// 8 = 2 * 2 * 2; 
        } // 14 bytyes

        public struct stParametrosMaxi
        {
            public UInt32 MedUC;                        // 4 bytes
            public byte[] IUDI;                         // 5 bytes
            public byte[] IUNeutro;                     // 5 bytes
            public byte[] NroTrafo;                     // 14 bytes
            public byte[] FlagsExib;                    // 9 bytes
            public float TensaoNominal;                 // 4 bytes
            public byte Ligacao;                        // 1
            public byte SaidaSerial;                    // 1
            public byte[][] CteKP;                      // 6 -> 2x3
            public byte[][] CteRTP;                     // 6 -> 2x3
            public byte[][] CteRTC;                     // 6 -> 2x3
            public byte[] ModoTotDem;                   // 2 -> 1x2
            public stFaturaAuto[] FaturaAuto;           // 24 -> 12x2 dia, mes
            public stTarifaReativos[] TarifaReativos;   // 28 -> 2x14 stTarifaReativos
            public stSelfRead[] SelfRead;               // 80 -> 16x5 Minuto, Hora, Dia, Mes, Ano
            public stHorarioVerao[] HorarioVerao;       // 90 -> 15x6 Ano, Mes, Dia
            public stFeriados[] Feriados;               // 246 -> 82x3
            public stPostoHorario[] PostoHorario;       // 536 -> 2x268 stPostoHorario 
            public byte[] CfgRemota;                    // 245 
        } // 1071 + 245 bytes

        public struct stConfiguracaoNova
        {
            public byte NroMostradores;
            public UInt32 NSABNT;
            public UInt32 NSFabrica;
            public byte[] IUMedidor;        // 5	(LSB first)
            public byte TemRadio;           // 15
            public byte TemRele;            // 16
            public byte TemPOL;				// 17
        }

        public struct stConfiguracaoMaxi
        {
            public UInt32 NSABNT;
            public UInt32 IDSMP;
            public byte[] IUMedidor;        // 5	(LSB first)
            public byte BitFlags;           // 1
            public UInt16 FundoEscala;      // 2
            public byte InterSerial1;       // 1    // 0 = Não tem; 3 = RS232; 4 = RS485; 5 = Remota
            public byte InterSerial2;       // 1    // 0 = Não tem; 1 = BLE_RN4871; 2 = BLE_EMB1082; 3 = RS232; 4 = RS485
            public byte[] Protocolos;       // 1    // 0 = Prot-Multiponto;
            public byte[] NroPatrimonio;
        }

        public struct stSelfRead
        {
            public byte Minuto;
            public byte Hora;
            public byte Dia;
            public byte Mes;
            public byte Ano;
        }

        public struct stQEESM
        {
            public byte StatusReg;
            public byte NroVTCDMom;
            public byte NroVTCDTemp;
            public byte NroVerFreq;
            public byte NroInterrupcao;
            public int Frequencia;
            public int Temperatura;
            public int TensaoA;
            public int TensaoB;
            public int TensaoC;
            public int Desequilibrio;
            public int DHTA;
            public int DHTB;
            public int DHTC;
        }

        public struct stQEESMFP
        {
            public byte StatusReg;
            public byte NroVTCDMom;
            public byte NroVTCDTemp;
            public byte NroVerFreq;
            public byte NroInterrupcao;
            public int Frequencia;
            public int Temperatura;
            public int TensaoA;
            public int TensaoB;
            public int TensaoC;
            public int Desequilibrio;
            public int DHTA;
            public int DHTB;
            public int DHTC;
            public int FPA;
            public int FPB;
            public int FPC;
            public int FP3F;
        }

        public struct stRegistrosDadosQEE
        {
            public byte ConjuntoDadosQEELido;
            public byte HoraInicio;
            public byte MinutoInicio;
            public byte SegundoInicio;
            public byte DiaInicio;
            public byte MesInicio;
            public byte AnoInicio;
            public byte HoraFim;
            public byte MinutoFim;
            public byte SegundoFim;
            public byte DiaFim;
            public byte MesFim;
            public byte AnoFim;
            public int IntervaloMedicao;
            public int TotalRegistros;
            public int NumeroRegistrosValidos;
            public byte GrandezasPresentes;
            public float IndicadorDRP;
            public float IndicadorDRC;
            public float IndicadorDTT95;
            public float IndicadorFD95;
            public float TensaoReferencia;
            public float ConstanteMultiplicacaoFrequencia;
            public float ConstanteMultiplicacaoTemperatura;
            public float ConstanteMultiplicacaoTensao;
            public float ConstanteMultiplicacaoDesequilibrio;
            public float ConstanteMultiplicacaoDHT;
            public float ConstanteMultiplicacaoFP;
            public float PercentualTPS;
            public float PercentualTPI;
            public float PercentualTCS;
            public float PercentualTCI;
            public byte TipoLigacao;
        }

        public struct stRegistradoresSelfRead
        {
            public byte Hora;
            public byte Minuto;
            public byte Segundo;
            public byte Dia;
            public byte Mes;
            public byte Ano;
            public byte[] TotalGeralEnergiaAtivaDiretaMG;
            public byte[] TotalGeralEnergiaAtivaDiretaE123;
            public byte[] TotalGeralEnergiaAtivaDiretaE456;
            public byte[] EspacoNuloEnergiaAtivaDireta;
            public byte[] TotalGeralEnergiaAtivaReversaMG;
            public byte[] TotalGeralEnergiaAtivaReversaE123;
            public byte[] TotalGeralEnergiaAtivaReversaE456;
            public byte[] EspacoNuloEnergiaAtivaReversa;
            public byte[] TotalGeralEnergiaReativaPositivaMG;
            public byte[] TotalGeralEnergiaReativaPositivaE123;
            public byte[] TotalGeralEnergiaReativaPositivaE456;
            public byte[] EspacoNuloEnergiaReativaPositiva;
            public byte[] TotalGeralEnergiaReativaNegativaMG;
            public byte[] TotalGeralEnergiaReativaNegativaE123;
            public byte[] TotalGeralEnergiaReativaNegativaE456;
            public byte[] EspacoNuloEnergiaReativaNegativa;
        }

        public struct stRegistradoresSelfReadET
        {
            public UInt32 RegId;            // 4
            public UInt32 DHSegs;           // 4
            public UInt32[][] Registradores;// 4*3*4=48
            public UInt16 CRC;              // 2
        }//58 - 4 por bloco

        public struct stRegistradoresSelfReadEV
        {
            public UInt32 RegId;            // 4
            public UInt32 DHSegs;           // 4
            public UInt32[] Registradores;  // 4*4=16
            public UInt16 CRC;              // 2
        }//74 - 3 por bloco

        public struct stRegistradoresSelfReadMaxi
        {
            public UInt32 RegId;            // 4
            public UInt32 DHSegs;           // 4
            public UInt32[][] Registradores;// 4*5*6=120
            public UInt16 CRC;              // 2
        }//90 - 2 por bloco

        public struct stConfiguracaoEasy
        {
            //Configuração
            public UInt32 NSABNT;           // 4 bytes
            public UInt32 NSFabrica;        // 4 bytes
            public byte[] IUMedidor;        // 5 bytes
            public byte BitFlags;           // 1 bytes
            public UInt16 FundoEscala;      // 2 byte
            public byte Protocolo;          // 2 byte
            //Variáveis auxiliares
            public string StrNSABNT;
            public string StrIU;
        }

        //Máscaras das bit flags dos medidores easy
        //Gerais
        public const byte MASK_EASY_LAST_GASP             = 0x01;
        public const byte MASK_EASY_ANUNCIO_BLE           = 0x08;
        //easyTrafo
        public const byte MASK_EASYTRAFO_NRO_ENTRADAS     = 0x02;
        public const byte MASK_EASYTRAFO_KH               = 0x04;
        public const byte MASK_EASYTRAFO_SENSOR_TEMP      = 0x10;
        public const byte MASK_EASYTRAFO_4TC              = 0x20;
        public const byte MASK_EASYTRAFO_EMB1082          = 0x40;
        public const byte MASK_EASYTRAFO_50HZ             = 0x80;
        //easyVer
        public const byte MASK_EASYVER_2TC                = 0x04;
        public const byte MASK_EASYVER_2TC_FASEA          = 0x10;
        //easyVolt/easyTrafoL
        public const byte MASK_EASYVOLT_SENSOR_TEMP       = 0x10;
        public const byte MASK_EASYVOLT_50HZ              = 0x20;
        public const byte MASK_EASYVOLT_BIFASICO          = 0x40;
        public const byte MASK_EASYVOLT_SENSOR_ABERTURA   = 0x80;

        public struct stParametrosEasy
        {
            //-----------------------------------------
            // Parametros
            public byte IntervaloMM;            // 1 byte
            public byte NumeroEntradas;         // 1 byte
            public stSelfRead[] SelfRead;       // 16 posicoes x 5 bytes = 80 bytes
            public byte[] NumeroTrafo;          // 14
            public float TensaoNominal;         // 4
            public byte QeeFlags;               // 1
            public int ResRamal;                // 2
            public stFaturaAuto[] FaturaAuto;   // 24
            public byte Ligacao;                // 1
            public int[] PotNomTrafo;           // 6
            public byte PapelTermo;             // 1
            public int[] SobreTensao;           // 6
            public int[] SubTensao;             // 6
            public int[] SobreCorrente;         // 6
            //-----------------------------------------
        }
        public struct stParametrosTarifaReativos
        {
            public byte AtivarTarifaReativos;
            public byte FPIndutivaTarifaReativos;
            public byte FPCapacitivaTarifaReativos;
            public UInt32 ConsumoTarifaReativos;
            public UInt32 DemandaTarifaReativos;
            public byte Hora1InicioIndutivo1;
            public byte Hora2InicioIndutivo1;
            public byte Minuto1InicioIndutivo1;
            public byte Minuto2InicioIndutivo1;
            public byte Hora1InicioIndutivo2;
            public byte Hora2InicioIndutivo2;
            public byte Minuto1InicioIndutivo2;
            public byte Minuto2InicioIndutivo2;
            public byte Hora1InicioCapacitivo1;
            public byte Hora2InicioCapacitivo1;
            public byte Minuto1InicioCapacitivo1;
            public byte Minuto2InicioCapacitivo1;
            public byte Hora1InicioCapacitivo2;
            public byte Hora2InicioCapacitivo2;
            public byte Minuto1InicioCapacitivo2;
            public byte Minuto2InicioCapacitivo2;
            public byte AtivaTR;
            public byte IndutivaTR;
            public byte CapacitivaTR;
            public bool BOL_KQhTR;
            public byte DiasUteisTR;
            public byte SabadosTR;
            public byte DomingosTR;
            public byte FeriadosTR;
        }

        public struct stMedAtivos
        {
            public UInt64 MedAtivo;
            public UInt32[] MedUC;
        }

        public struct stRegistradoresAtuais
        {
            public String TotalGeralDireta;
            public String TotalPontaDireta;
            public String TotalForaPontaDireta;
            public String TotalReservadoDireta;
            public String TotalTarifaDDireta;

            public String TotalGeralReversa;
            public String TotalPontaReversa;
            public String TotalForaPontaReversa;
            public String TotalReservadoReversa;
            public String TotalTarifaDReversa;

            public String TotalGeralReativaPositiva;
            public String TotalPontaReativaPositiva;
            public String TotalForaPontaReativaPositiva;
            public String TotalReservadoReativaPositiva;
            public String TotalTarifaDReativaPositiva;

            public String TotalGeralReativaNegativa;
            public String TotalPontaReativaNegativa;
            public String TotalForaPontaReativaNegativa;
            public String TotalReservadoReativaNegativa;
            public String TotalTarifaDReativaNegativa;

            public String TotalGeralDireta1;
            public String TotalGeralReversa1;
            public String TotalGeralDireta2;
            public String TotalGeralReversa2;
            public String TotalGeralDireta3;
            public String TotalGeralReversa3;

            public String[] ReativaGeralQ;
            public String[] ReativaPontaQ;
            public String[] ReativaForaPontaQ;
            public String[] ReativaReservadoQ;
            public String[] ReativaTarifaDQ;
        }

        public struct TAtributosDeComando
        {
            public ENUM_TComando TipoDeComando;
            public byte CodigoDeComandoDosOctetos;
            public byte CodigoDeComandoEstendidoDosOctetos;
            public byte CodigoDoMonitorDeQualidade;
            public ENUM_TTipoDeAvancoDoApontadorDeSubOperacao TipoDeAvancoDoApontadorDeSubOperacao;
            public sbyte AvancoDoApontadorDeSubOperacao;
            public ENUM_TComandoCodi ComandoCodi;
            public bool DeveGerarBlocoDeConexao;
            public bool NaoDeveGerarDadoParaGravar;
            public bool DeveTestarQuatroQuadrantes;
            public bool DeveTestarHorarioDeVerao;
            public bool DeveTestarSeTemPaginaFiscal;
            public bool DeveInverterVisibilidadeDosQuadrantes;
            public bool DeveTestarSeTemParametrosDeMedicao;
            public bool DeveTestarSeTemParametrosDeQualidade;
            public bool DeveTestarSeTemParametrosDeCompensacaoDePerdas;
            public bool DeveTestarSeTemDispRegAlarmes;
            public bool DeveTestarSeTemDispRegCargaProg;
            public bool DeveTestarSeTemMonitorAtivo;
            public bool DeveTestarSeEhMedidorDeQualidade;
            public bool DeveTestarSeTemGrandezasEmRegistro;
            public bool DeveTestarRegistradoresZerados;
            public bool DevePegarONumeroDePalavrasDaMemoriaDeMassa;
            public byte ComandoEloNetAEnviar;
            public bool EhAlteracaoElonet;
            public bool DeveAbortarSeDerComandoNaoImplementado;
            public short PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa;
            public bool FormaAlternativaDeCalcularNumeroDeBlocosDaMM;
            public bool DeveTestarSeCompensaEnergia;
            public bool DevePegarNumeroDeGruposDeCanais;
        }

        public struct TOperacoesDeComunicacao
        {
            public string Operacao;
            public ENM_TOperacao TipoOperacao;
            public bool EhAlteracao;
            public bool EhReposicao;
            public TAtributosDeComando[] ConjuntoDeSubOperacoes;
        }

        public enum ENM_TTipoDeGrandezaDoCanal
        {
            tTipoGrandEnergiaCompensada,
            tTipoGrandEnergiaNaoCompensada,
            tTipoGrandGrandeza
        }

        public struct TRecGrupoDeCanais
        {
            public ENM_TTipoDeGrandezaDoCanal TipoDeGrandeza;
            public bool DeveLer;
            public bool Lido;
        }

        public enum ENUM_resComunicaCodi
        {
            resCodiOK,
            resCodiOKComRecuperacaoDeErro,
            resCodiOKComRecuperacaoEFimDeOperacao,
            resCodiOKVeioWait,
            resCodiOKVeioNak,
            resCodiOKVeioAck,
            resCodiOKVeioEnq,
            resCodiComandoNaoImplementado,
            resCodiErroFaltouDesconectar,
            resCodiErroParametro,
            resCodiCanalAusente,
            resCodiMedidorAusente,
            resCodiFalhaProtocolar,
            resCodiErroComunicacao,
            resCodiLinhaRuim,
            resCodiFimDaMemoria,
            resCodiErroIrrecuperavel,
            resCodiMedidorNaoResetaErro,
            resCodiAbortou,
        }

        public struct stLogPO
        {
            public byte Versao;
            public byte Revisao;
            public byte Hora;
            public byte Minuto;
            public byte Segundo;
            public byte Dia;
            public byte Mes;
            public byte Ano;
            public byte NumSerieLeitorMSB;
            public byte NumSerieLeitor;
            public byte NumSerieLeitorLSB;
            public byte TipoCargaPO;
            public byte InterfaceCargaPO;
        }

        public struct stLogAlter
        {

            public Int32 LogId;             // 4
            public byte Comando;            // 1
            public byte[] Origem;//5        // 5
            public stDataHora DataHora;//7  // 7
            public byte[] Antes;//323       // 323
            public byte[] Depois;//323      // 323
            public int Crc16;               // 2
        } // Total 665

        public struct stLogAlterMaxi
        {

            public Int32 LogId;             // 4
            public byte Comando;            // 1
            public byte[] Origem;//5        // 5
            public UInt32 DHSegs;           // 4
            public byte[] Antes;//268       // 268
            public byte[] Depois;//268      // 268
            public int Crc16;               // 2
        } // Total 552

        public struct stLogAlterEasy
        {

            public Int32 LogId;             // 4
            public byte Comando;            // 1
            public byte[] Origem;           // 5
            public UInt32 DHSegs;           // 4
            public byte[] Antes;            // 40
            public byte[] Depois;           // 40
            public int Crc16;               // 2
        } // Total 96

        public struct stLogAlterTarifaReativos
        {
            public byte Dia;                    // 1 Dia de ínicio do conjunto de postos no formato BCD (1 a 31) - 1 byte
            public byte Mes;                    // 1 Mês do início do conjunto de postos no formato BCD (1 a 12) - 1 byte
            public byte Ano;                    // 1 Ano do início do conjunto de postos no formato BCD (0 a 99) - 0 indice que o conjunto é válido para todos os anos. - 1 byte
            public UInt16 SegRtAtivos;          // 2 Segmentos Reativos Ativos
            public byte FatPotRef;              // 1 Fator de Potência de Referência
            public stPosto PostoReativoInd0;    // 2
            public stPosto PostoReativoInd1;    // 2
            public stPosto PostoReativoCap0;    // 2
            public stPosto PostoReativoCap1;    // 2
        } // 14 bytyes

        public struct stGrandezasInstantaneas
        {

            public float[] Tensao;              //  12		// V	Tensão
            public float[] TenLinha;            //  12		// V	Tensão de Linha
            public float[] DefTensao;           //  12		// V	°	Defasamento de Tensão
            public float[] Corrente;            //  60		// A	Corrente
            public float[] Defasamento;         //  60		// °	Defasamento Tensão e Corrente
            public float[] Ativa;               //  60		// W	Potência Ativa
            public float[] Reativa;             //  60		// var	Potência Reativa
            public float Frequencia;            //   4		// Hz	Freqüência
            public float Temperatura;           //   4		// em ºC
            public stDataHora DataHora;         //   7
            public uint[] VerRev;			    //   2
        }

        public struct stIndicadoresQEE
        {
            public float KVP;
            public float KVT;
            public float PTPS;
            public float PTPI;
            public float PTCS;
            public float PTCI;
        }

        public struct stIndicadoresSimples
        {
            public UInt32 DHSegsIni;            //  4
            public UInt32 DHSegsFim;            //  4
            public UInt16 DRP;                  //  2
            public UInt16 DRC;                  //  2
            public UInt16 DTT95;                //  2
            public UInt16 FD95;                 //  2
        }

        public struct stIndicadoresCompleto
        {
            public UInt32 DHSegsIni;            // 4
            public UInt32 DHSegsFim;            // 4
            public UInt16 DRP;                  // 2
            public UInt16 DRC;                  // 2
            public UInt16 DTT95;                // 2
            public UInt16 FD95;                 // 2
            public UInt16 TenReferencia;        // 2
            public UInt16 RegsTotal;            // 2
            public UInt16 RegsValidos;          // 2
            public UInt16 TotalVTCD;            // 2
            public UInt16 IntRegistro;          // 2
            public UInt16[] Adequado;           // 2x3=6
            public UInt16[] Precario;           // 2x3=6
            public UInt16[] Critico;            // 2x3=6
            public UInt16[] TenMinima;          // 2x3=6
            public UInt16[] TenMaxima;          // 2x3=6
            public UInt32[] DHSegsMin;          // 4x3=12
            public UInt32[] DHSegsMax;          // 4x3=12
        }

        public struct stLogEventosQee
        {
            public UInt32 LogId;                     //  4
            public UInt32 DHSegs;                    //  4
            public byte Codigo;                      //  1
            public byte SubCod;                      //  1
            public byte[] EveDados;                  // 20
            public UInt16 Crc16;                     //  2
        }

        public struct stFaltasQEE
        {
            public UInt32 FaltasId;                 //  4
            public UInt32 DHSegsIni;                //  4
            public UInt32 DHSegsFim;                //  4
            public UInt16 Crc16;                    //  2
        }

        public struct stAlteracaoTarifaReativos
        {
            public byte ComposicaoDosCanais;
            public UInt16 IntervaloDeConsumoDeReativos;
            public UInt16 IntervaloDeDemandaDeReativos;
            public byte FatorDePotenciaDeReferenciaInd;
            public byte FatorDePotenciaDeReferenciaCap;
            public byte HoraInicioHorarioReativoInd;
            public byte MinutoInicioHorarioReativoInd;
            public byte HoraInicioHorarioReativoInd2;
            public byte MinutoInicioHorarioReativoInd2;
            public byte HoraInicioHorarioReativoCap;
            public byte MinutoInicioHorarioReativoCap;
            public byte HoraInicioHorarioReativoCap2;
            public byte MinutoInicioHorarioReativoCap2;
            public byte HoraInicioHorarioReativoIndCj2;
            public byte MinutoInicioHorarioReativoIndCj2;
            public byte HoraInicioHorarioReativoInd2Cj2;
            public byte MinutoInicioHorarioReativoInd2Cj2;
            public byte HoraInicioHorarioReativoCapCj2;
            public byte MinutoInicioHorarioReativoCapCj2;
            public byte HoraInicioHorarioReativoCap2Cj2;
            public byte MinutoInicioHorarioReativoCap2Cj2;
            public Int16 SegmentosReativosValidosDiasUteisESabados;
            public Int16 SegmentosReativosValidosDomingosEFeriados;
        }

        public struct stAlteracaoConstantesModoOperacao
        {
            public UInt64 ConstanteKe;
            public UInt64 ConstanteKh;
            public UInt64 ConstanteRTP;
            public UInt64 ConstanteRTC;
            public byte ModoDeOPeracaoParaEnergiaAtiva;
            public byte ModoDeOPeracaoParaEnergiaReativa;
            public UInt64 ConstanteKeReativo;
            public byte RegistroGrandezas;
            public byte TipoLigacao;
            public byte RedefinicaoSaidaUsuario;
            public byte SaidaUsuario;
            public UInt64 ConstanteKp;
            public UInt32 DemandaLimitePonta;
            public UInt32 DemandaLimiteFPonta;
            public UInt32 DemandaLimiteReservado;
            public UInt32 DemandaLimiteQuartoPosto;
            public byte ModoCalculoEnergia;
            public byte ValeAlteracao1;
            public byte ValeAlteracao2;

        }

        public struct stCfgHWAB13
        {
            public byte Tipo;
            public UInt32 BitFlags;
            public UInt16 TensaoBateria;
            public byte BotaoFatura;
            public byte FaltaEnergia;
            public byte BLE;
            public byte SensorPO;
            public byte SensorUART1;
            public byte SensorUART2;
        }

        //Máscaras das bit flags da configuracao de hardware
        public const UInt32 MASK_AB13_MED_BAT       = 0x00000001;
        public const UInt32 MASK_AB13_BOTAO_FATURA  = 0x00000002;
        public const UInt32 MASK_AB13_FALTA_ENERGIA = 0x00000004;
        public const UInt32 MASK_AB13_BLE           = 0x00000008;
        public const UInt32 MASK_AB13_SENSOR_PO     = 0x00000010;
        public const UInt32 MASK_AB13_SENSOR_UART1  = 0x00000020;
        public const UInt32 MASK_AB13_SENSOR_UART2  = 0x00000040;

        public struct stOcorrencias
        {
            public Int32 Ocorrencia;
            public stDataHora DataHora;
            public Int16 NroOcorrencias;
        }

        public struct stOcorrenciasAB40
        {
            public byte Tipo;
            public UInt32 NumeroOcorrenciasMedidor;
            public UInt64 OcorrenciasAtivasMedidor;
            public byte CfgOcMultipontoMedidor;
            public stOcorrencias[] OcorrenciasMedidor;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stInfoMMAB52
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] IUMedidor;
            public byte TipoEstrutura;
            public byte TamEstrutura;
            public float cteEnergia;
            public float cteTensao;
            public float cteCorrente;
            public float cteTHD;
            public float ctePerdas;
            public float cteTensaoPrimaria;
            public float cteCorrentePrimaria;
        }

        //00 - ABSOLUTO SM-12
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stMMAB52_00
        {
            public UInt32 DataHora;
            public UInt32 EnergiaAtivaDireta;
            public UInt32 EnergiaAtivaReversa;
            public UInt32 EnergiaReativaPositiva;
            public UInt32 EnergiaReativaNegativa;
            public UInt16 TensaoA;
            public UInt16 TensaoB;
            public UInt16 TensaoC;
            public UInt16 CorrenteA;
            public UInt16 CorrenteB;
            public UInt16 CorrenteC;
            public byte Flags;
            public UInt16 CRC;
        }

        //01 - easyTrafo(L)
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stMMAB52_01
        {
            public UInt32 DataHora;
            public UInt32 EnergiaAtivaDireta;
            public UInt32 EnergiaAtivaReversa;
            public UInt32 EnergiaReativaPositiva;
            public UInt32 EnergiaReativaNegativa;
            public UInt16 TensaoA;
            public UInt16 TensaoB;
            public UInt16 TensaoC;
            public UInt16 CorrenteA;
            public UInt16 CorrenteB;
            public UInt16 CorrenteC;
            public UInt16 THDTensaoA;
            public UInt16 THDTensaoB;
            public UInt16 THDTensaoC;
            public UInt16 THDCorrenteA;
            public UInt16 THDCorrenteB;
            public UInt16 THDCorrenteC;
            public byte Flags;
            public UInt16 CRC;
        }

        //02 - easyVer 3F
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stMMAB52_02
        {
            public UInt32 DataHora;
            public UInt32 EnergiaAtivaDireta;
            public UInt32 EnergiaAtivaReversa;
            public UInt32 EnergiaReativaPositiva;
            public UInt32 EnergiaReativaNegativa;
            public UInt16 TensaoA;
            public UInt16 TensaoB;
            public UInt16 TensaoC;
            public UInt16 CorrenteA;
            public UInt16 CorrenteB;
            public UInt16 CorrenteC;
            public UInt16 PerdasRamal;
            public byte Flags;
            public UInt16 CRC;
        }

        //03 - easyVer 1F
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stMMAB52_03
        {
            public UInt32 DataHora;
            public UInt32 EnergiaAtivaDireta;
            public UInt32 EnergiaAtivaReversa;
            public UInt32 EnergiaReativaPositiva;
            public UInt32 EnergiaReativaNegativa;
            public UInt16 TensaoA;
            public UInt16 CorrenteA;
            public UInt16 PerdasRamal;
            public byte Flags;
            public UInt16 CRC;
        }

        //04 - easyVolt
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stMMAB52_04
        {
            public UInt32 DataHora;
            public UInt16 TensaoA;
            public UInt16 TensaoB;
            public UInt16 TensaoC;
            public UInt16 THDTensaoA;
            public UInt16 THDTensaoB;
            public UInt16 THDTensaoC;
            public UInt16 TensaoMinA;
            public UInt16 TensaoMinB;
            public UInt16 TensaoMinC;
            public UInt16 TensaoMaxA;
            public UInt16 TensaoMaxB;
            public UInt16 TensaoMaxC;
            public byte Flags;
            public UInt16 CRC;
        }

        //05 - Extend/Unique/Maxi
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct stMMAB52_05
        {
            public UInt32 DataHora;
            public UInt32 EnergiaAtivaDireta;
            public UInt32 EnergiaAtivaReversa;
            public UInt32 EnergiaReativaQ1;
            public UInt32 EnergiaReativaQ2;
            public UInt32 EnergiaReativaQ3;
            public UInt32 EnergiaReativaQ4;
            public UInt16 TensaoA;
            public UInt16 TensaoB;
            public UInt16 TensaoC;
            public UInt16 CorrenteA;
            public UInt16 CorrenteB;
            public UInt16 CorrenteC;
            public UInt16 THDTensaoA;
            public UInt16 THDTensaoB;
            public UInt16 THDTensaoC;
            public UInt16 THDCorrenteA;
            public UInt16 THDCorrenteB;
            public UInt16 THDCorrenteC;
            public byte Flags;
            public UInt16 CRC;
        }

        //Máscaras das bit flags dos eventos da memória de massa
        public const byte MASK_AB52_FALTA_ENERGIA       = 0x01;
        public const byte MASK_AB52_ALTERACAO_DATA      = 0x02;
        public const byte MASK_AB52_ALTERACAO_HORA      = 0x04;
        public const byte MASK_AB52_ATIVACAO_MED        = 0x08;
        public const byte MASK_AB52_FATURA_CMD          = 0x10;
        public const byte MASK_AB52_FATURA_ALTERACAO    = 0x20;
        public const byte MASK_AB52_REG_INVALIDO        = 0x80;     //Não faz parte da definição de medidores

        public static string[] StrEventosMMSM =
        {
            "Falta de energia", "Alteração de data", "Alteração de hora", "Ativação de medidor",
            "Fechamento de fatura por comando", "Fechamento de fatura devido à alteração da data/hora",
            "Reservado", "Registro inválido",
            //"Registro inválido" é marcado pelo SMReader quando ocorre erro de CRC do bloco
        };

        public static stInfoMMAB52 InfoMMAB52;
        public static stMMAB52_00[] DataMMAB52_00 = new stMMAB52_00[(int)(247/Marshal.SizeOf(typeof(clGlobal.stMMAB52_00)))]; // (int)(247/35) = 7
        public static stMMAB52_01[] DataMMAB52_01 = new stMMAB52_01[(int)(247/Marshal.SizeOf(typeof(clGlobal.stMMAB52_01)))]; // (int)(247/47) = 5
        public static stMMAB52_02[] DataMMAB52_02 = new stMMAB52_02[(int)(247/Marshal.SizeOf(typeof(clGlobal.stMMAB52_02)))]; // (int)(247/37) = 6
        public static stMMAB52_03[] DataMMAB52_03 = new stMMAB52_03[(int)(247/Marshal.SizeOf(typeof(clGlobal.stMMAB52_03)))]; // (int)(247/29) = 8
        public static stMMAB52_04[] DataMMAB52_04 = new stMMAB52_04[(int)(247/Marshal.SizeOf(typeof(clGlobal.stMMAB52_04)))]; // (int)(247/31) = 9
        public static stMMAB52_05[] DataMMAB52_05 = new stMMAB52_05[(int)(247/Marshal.SizeOf(typeof(clGlobal.stMMAB52_05)))]; // (int)(247/55) = 4

        public static Int32 INT_NumeroDeSerieDaLeitoraHi = 0x99;
        public static Int32 INT_NumeroDeSerieDaLeitoraMe = 0x99;
        public static Int32 INT_NumeroDeSerieDaLeitoraLo = 0x90;

        public static string COD_MED_HOSPEDEIRO = "000000";
        public static string COD_MED_MONO_01 = "010000";
        public static string COD_MED_MONO_02 = "020000";
        public static string COD_MED_MONO_03 = "030000";
        public static string COD_MED_MONO_04 = "040000";
        public static string COD_MED_MONO_05 = "050000";
        public static string COD_MED_MONO_06 = "060000";
        public static string COD_MED_MONO_07 = "070000";
        public static string COD_MED_MONO_08 = "080000";
        public static string COD_MED_MONO_09 = "090000";
        public static string COD_MED_MONO_10 = "100000";
        public static string COD_MED_MONO_11 = "110000";
        public static string COD_MED_MONO_12 = "120000";

        public static string COD_MED_BI_01_02 = "010200";
        public static string COD_MED_BI_02_03 = "020300";
        public static string COD_MED_BI_03_04 = "030400";
        public static string COD_MED_BI_04_05 = "040500";
        public static string COD_MED_BI_05_06 = "050600";
        public static string COD_MED_BI_06_07 = "060700";
        public static string COD_MED_BI_07_08 = "070800";
        public static string COD_MED_BI_08_09 = "080900";
        public static string COD_MED_BI_09_10 = "091000";
        public static string COD_MED_BI_10_11 = "101100";
        public static string COD_MED_BI_11_12 = "111200";

        public static string COD_MED_TRI_01_02_03 = "010203";
        public static string COD_MED_TRI_02_03_04 = "020304";
        public static string COD_MED_TRI_03_04_05 = "030405";
        public static string COD_MED_TRI_04_05_06 = "040506";
        public static string COD_MED_TRI_05_06_07 = "050607";
        public static string COD_MED_TRI_06_07_08 = "060708";
        public static string COD_MED_TRI_07_08_09 = "070809";
        public static string COD_MED_TRI_08_09_10 = "080910";
        public static string COD_MED_TRI_09_10_11 = "091011";
        public static string COD_MED_TRI_10_11_12 = "101112";

        //public static string COD_MED_HEX_01 = "123456";
        public static string COD_MED_HEX_01 = "142536";

        public static Int32 INT_NumeroDeDiasDaVerificacaoParcial;
        public static Int32 INT_NumeroDeHorasDaVerificacaoParcial;
        public static Int32 INT_QuantidadeDiasVerificacaoParcial;

        public static bool BOL_LerFeriados = false;
        public static bool BOL_LerHorarioVerao = false;
        public static bool BOL_VerificacaoParcialDeHoje = false;
        public static bool BOL_VerificacaoParcialPorDias = true;
        public static bool BOL_VerificacaoParcialPorHoras = false;
        public static bool BOL_PegouStatusMedidoresAtivos = false;
        public static bool BOL_PegouParametrosMedidor = false;
        public static bool BOL_PegouIdsRadios = false;
        public static bool BOL_PegouCodigoExibir = false;
        public static bool BOL_PegouConfiguracaoMedidorHospedeiro = false;
        public static bool BOL_PegouParametrosETEV = false;
        public static bool BOL_PegouStatusRele = false;
        public static bool BOL_ComandoModoCalibracaoOK = false;
        public static bool BOL_AtualizouViewVisualiza = false;
        public static bool BOL_GravouArquivo = false;
        public static bool BOL_TerminouEnvioBlocos = false;
        public static bool BOL_TerminouEnvioBlocosET = false;
        public static bool BOL_AlterouData = false;
        public static bool BOL_AlterouHora = false;
        public static bool BOL_DataCorreta = false;
        public static bool BOL_HoraCorreta = false;
        public static bool BOL_SenhaExpira = false;
        public static bool BOL_SenhaInvalida = false;
        public static bool BOL_TransmitiuPostosUniversais = false;
        public static bool BOL_ComandoDesativacaoPostosUniversais = false;
        public static bool BOL_BateriaOK = true;
        public static bool BOL_AbriuTelaStatus = false;
        public static bool BOL_MudouConfiguracao = false;
        public static bool BOL_MudouParametroDataHora = false;
        public static bool BOL_ComandoAtivo = false;
        public static bool BOL_Depuracao = false;
        public static bool BOL_DesconectarBLE = false;
        public static bool BOL_Desconectar3 = false;
        public static bool BOL_ShowFormBle = false;

        public static bool BOL_DesconectarEthernet = false;
        public static bool BOL_DesconectarMedidor = false;
        public static bool BOL_LerNumTrafo = false;

        public static bool BOL_TemParametrosDeMedicao = false;
        public static bool BOL_TemFP_RegistrosDadosQEE = false;

        public static bool BOL_EstadoSensorAberturaTampa = false;
        public static bool BOL_EstadoSensorMagnetico = false;
        public static bool BOL_DiscrepanciaTCs = false;
        public static bool BOL_SensorPO = false;
        public static bool BOL_SensorUART1 = false;
        public static bool BOL_SensorUART2 = false;

        public static stDataHora DataHoraUltimoIntervaloDemanda = new stDataHora();
        public static stDataHora DataHoraUltimaReposicaoDemanda = new stDataHora();

        public static stDataHora DataAlteracao = new stDataHora();
        public static stIntervaloMM IntervaloMM = new stIntervaloMM();
        public static stDataHora[] DataHoraFaltaEnergia = new clGlobal.stDataHora[(clGlobal.cte_Numero_Faltas_Energia * 2)];

        public static stOcorrenciasAB40 OcorrenciasMedidorAB40 = new clGlobal.stOcorrenciasAB40();

        public static stPostoHorario[] PostosUniversais = new clGlobal.stPostoHorario[2];

        public static string STR_DiretorioParaArquivosDePrograma = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\PROGRAMA\\";
        public static string STR_DiretorioParaArquivosArqPrivado = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\PRIVADO\\";
        public static string STR_DiretorioParaArquivosLog = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\LOG\\";
        public static string STR_DiretorioParaArquivosPgf = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\PGF\\";
        public static string STR_DiretorioParaArquivosIni = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\CONFIG\\";
        public static string STR_DiretorioParaArquivosLeituras = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\LEITURAS\\";
        public static string STR_DiretorioParaArquivos = "";

        public static TOperacoesDeComunicacao[] OperacoesDeComunicacao = new clGlobal.TOperacoesDeComunicacao[clGlobal.cte_opUltima];
        public static stConfiguracaoNova ConfiguracaoMedidorHospedeiroNova = new clGlobal.stConfiguracaoNova();
        public static stConfiguracaoMaxi ConfiguracaoMedidorMaxi = new clGlobal.stConfiguracaoMaxi();
        public static stParametrosEasy ParametrosEasy = new clGlobal.stParametrosEasy();
        public static stParametrosTarifaReativos ParametrosTarifaReativos = new clGlobal.stParametrosTarifaReativos();
        public static stConfiguracaoEasy ConfiguracaoEasy = new clGlobal.stConfiguracaoEasy();
        public static stRegistrosAtuaisEasy RegistrosAtuaisEasy = new clGlobal.stRegistrosAtuaisEasy();
        public static stRegistradoresSelfRead[] RegistradoresSelfRead = new clGlobal.stRegistradoresSelfRead[2000];
        public static stRegistradoresSelfReadET[] RegistradoresSelfReadET = new clGlobal.stRegistradoresSelfReadET[2000];
        public static stRegistradoresSelfReadEV[] RegistradoresSelfReadEV = new clGlobal.stRegistradoresSelfReadEV[2000];
        public static stRegistradoresSelfReadMaxi[] RegistradoresSelfReadMaxi = new clGlobal.stRegistradoresSelfReadMaxi[2000];
        public static stRegistrosDadosQEE RegistrosDadosQEE = new clGlobal.stRegistrosDadosQEE();
        public static stQEESMFP[] QEESMFP = new clGlobal.stQEESMFP[50000];
        public static stQEESM[] QEESM = new clGlobal.stQEESM[50000];
        public static stRegistrosDeAlteracoes[] RegistrosDeAlteracoes = new clGlobal.stRegistrosDeAlteracoes[25];
        public static stIndicadoresQEE IndicadoresQEE = new clGlobal.stIndicadoresQEE();
        public static stIndicadoresSimples[] IndicadoresSimples = new clGlobal.stIndicadoresSimples[2000];
        public static stIndicadoresCompleto[] IndicadoresCompleto = new clGlobal.stIndicadoresCompleto[2000];
        public static stLogEventosQee[] LogEventoQEE = new clGlobal.stLogEventosQee[20000];
        public static stFaltasQEE[] FaltasQEE = new clGlobal.stFaltasQEE[20000];
        public static stMM_ET[] MemoriaMassaET = new clGlobal.stMM_ET[4];
        public static stMM_ET_ABNT[] MemoriaMassaET_ABNT = new clGlobal.stMM_ET_ABNT[56];
        public static stAlteracaoTarifaReativos AlteracaoTarifasReativos = new clGlobal.stAlteracaoTarifaReativos();
        public static stAlteracaoConstantesModoOperacao AlteracaoConstantesModoOperacao = new clGlobal.stAlteracaoConstantesModoOperacao();

        public static stParametros ParametrosMedidorHospedeiro = new clGlobal.stParametros();
        public static stParametrosMaxi ParametrosMedidorMaxi = new clGlobal.stParametrosMaxi();
        public static stGrandezasInstantaneas GrandezasInstantaneas = new clGlobal.stGrandezasInstantaneas();

        public static stRegistradoresAtuais RegistradoresAtuais = new clGlobal.stRegistradoresAtuais();
        public static stFaturas[] FaturasEasy = new clGlobal.stFaturas[100];

        public static TAtributosDeComando[] SubOperacao = new clGlobal.TAtributosDeComando[clGlobal.cte_NumeroMaximoDeSubOperacoes];

        public static int DadosRecebidosPtr1 = 0;
        public static int DadosRecebidosPtr2 = 0;
        public static int DadosRecebidosPtr3 = 0;
        public static int DadosRecebidosPtr4 = 0;
        public static int BufferPtr = 1;
        public static byte[] MedidoresAtivos = new byte[8];
        public static byte[] DadosRecebidos1 = new byte[200000];
        public static byte[] DadosRecebidos2 = new byte[200000];
        public static byte[] DadosRecebidos3 = new byte[200000];
        public static byte[] DadosRecebidos4 = new byte[200000];
        public static char[] SenhaMedidor = new char[16];
        public static bool[] _HabilitaReposicaoDemanda = new bool[12];
        public static bool[] _HabilitaHorarioVerao = new bool[15];

        public static stHorarioVerao HorarioVeraoUnico;
        public static stHorarioVerao[] HorarioVeraoAuxiliar;
        public static stHorarioVerao[] HorarioVeraoAuxiliar2;
        public static stFeriados[] FeriadosAuxiliar = new clGlobal.stFeriados[cte_Numero_Feriados];           // 246 bytes
        public static stFeriados[] FeriadosAuxiliar2 = new clGlobal.stFeriados[cte_Numero_Feriados];           // 246 bytes
        public static stEstadoReles[] EstadosReles = new clGlobal.stEstadoReles[12];
        public static stEstadoRelesMedidorHospedeiro EstadosRelesMedidorHospedeiro = new clGlobal.stEstadoRelesMedidorHospedeiro();

        public static stLogAlter[] LogAlter = new clGlobal.stLogAlter[255];
        public static stLogAlterMaxi[] LogAlterMaxi = new clGlobal.stLogAlterMaxi[255];
        public static stLogAlterEasy[] LogAlterEasy = new clGlobal.stLogAlterEasy[255];
        public static stLogPO[] LogPO = new clGlobal.stLogPO[255];

        public static stDataHora DataExpiracaoSenha = new clGlobal.stDataHora();

        public static stSelfRead[] NovoSelfRead;

        public static stCabecalho_SMPO CabecalhoSMPO;

        public static string NomeArquivoIni = "";
        public static string NomeArquivoRegistradoresAtuais = "";
        public static string NomeArquivoParametrosAtuais = "";
        public static string NomeArquivoGeral = "";

        public static string PontoBLE = "";

        public static System.IO.Stream SaidaIni;
        public static System.IO.StreamReader LeituraIni;
        public static string[] EntradaIni;
        public static string[] LinhasCaixaTexto = new string[8];
        public static System.IO.StreamWriter ArquivoIni;

        public static string NomeArquivoLogCom = "";
        public static System.IO.Stream SaidaLogCom;
        public static System.IO.StreamWriter ArquivoLogCom;

        public static string CBGeral = "";

        public static stCfgHWAB13 CfgHWAB13 = new clGlobal.stCfgHWAB13();

        //Inicializa todas as variáveis globais no momento da conexão ou desconexão
        public static void clGlobalInit(bool conectar)
        {
            if (conectar)
            {
                //Conexão
                clGlobal.BOL_Cancelar_Comandos = false;
                clGlobal.lbModeloMedidor = "0000";
            }
            else
            {
                //Desconexão
                ResetCfgParametros();

                clGlobal._ConectadoMedidorHospedeiro = false;
                clGlobal.BOL_DesconectarMedidor = false;
                clGlobal.BOL_PegouConfiguracaoMedidorHospedeiro = false;

                clGlobal.LinhasCaixaTexto[0] = "Modelo : ";
                clGlobal.LinhasCaixaTexto[1] = "Núm. Série : ";
                clGlobal.AtualizaMsgCaixaTexto("Status : Desconectado");
                clGlobal.LinhasCaixaTexto[3] = "";
                clGlobal.LinhasCaixaTexto[4] = "";
                clGlobal.LinhasCaixaTexto[5] = "";
                clGlobal.LinhasCaixaTexto[6] = "";
                clGlobal.LinhasCaixaTexto[7] = "";

                clGlobal.BOL_DataCorreta = true;
                clGlobal.BOL_HoraCorreta = true;

                clGlobal.CodigoOcorrencia = 0x00;
                clGlobal.NumeroSerie = 0x00000000;
                clGlobal.NumeroSerie_HiHi = 0x00;
                clGlobal.NumeroSerie_HiLow = 0x00;
                clGlobal.NumeroSerie_LowHi = 0x00;
                clGlobal.NumeroSerie_LowLow = 0x00;

                clGlobal.lbModeloGeralMedidor = "";
                clGlobal.lbModeloMedidor = "";
                clGlobal.ModeloMedidor = 0x00;

                clGlobal.TamTag = 0x12;
                clGlobal.TamProg = 0;
                clGlobal.TamCampoDados = 0;
                clGlobal.TamPacote = 0x80;
                clGlobal.TamBlocoCargaPrograma = 0;
                clGlobal.SendProg = 0x0000;
                clGlobal.SeqProg = 0;
                clGlobal.Sequenciador = 0;
                clGlobal.Cabecalho_Recepcao_SM = 0;
                clGlobal.TamCampoDados_Recepcao_SM = 0;
                clGlobal.BOL_Protocolo_SM = false;
                clGlobal.BOL_ProcessoTransmissaoBLE = false;
                clGlobal.BOL_PegouNroSerie = false;
                clGlobal.ENUM_CargaPrograma = clGlobal.enumEstadoCargaPrograma.eNenhum;

                clGlobal.QtdRegistrosMedidor = 0;
                clGlobal.QtdRegistrosMedidorET = 0;
                clGlobal.QtdBlocosTransmitir = 0;
                clGlobal.QtdBlocosTransmitirET = 0;
                clGlobal.QtdRegistrosMM_ET = 0;
                clGlobal.ComandoBloco = 0;
                clGlobal.ComandoBlocoET = 0;
                clGlobal.TipoAlteracaoFeriados = 4;
                clGlobal.TipoAlteracaoHorarioVerao = 4;
                clGlobal.IndiceMedidor = 0;
                clGlobal.ConjuntoPostosUniversais = 0;            // 0 - Conjunto 1; 1 - Conjunto 2
                clGlobal.CondicaoAtivacaoPostosUniversais = 0;    // 0 - Desativa

                clGlobal.Bloco_Leitura_Atual = 0;
                clGlobal.Bloco_Leitura_Atual_MM = 0;
                clGlobal.Bloco_Comando_Atual = 0;
                clGlobal.Bloco_Comando_Atual_MM = 0;
                clGlobal.Bloco_Lido = 0;
                clGlobal.Bloco_Lido_Anterior = 0;
                clGlobal.DiaFaturaAutomatica = 0;
                clGlobal.Contador_Erros = 0;
                clGlobal.IndiceRegistroAlteracaoLido = 0;
                clGlobal.IndiceRegistroMMLido = 0;
                clGlobal.BOL_ComandoAtivo = false;
                BlocoMMLidoInit();

                clGlobal.BOL_ShowFormBle = true;
                //As demais variáveis de controle do BLE serão resetadas quando de sua desconexão
            }
        }

        //Zera as estruturas de parâmetros e configuração
        public static void ResetCfgParametros()
        {
            //Configuração
            //ABSOLUTO
            clGlobal.ConfiguracaoMedidorHospedeiroNova.NroMostradores = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.NSFabrica = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.IUMedidor[0] = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.IUMedidor[1] = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.IUMedidor[2] = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.IUMedidor[3] = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.IUMedidor[4] = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.TemRadio = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.TemRele = 0;
            clGlobal.ConfiguracaoMedidorHospedeiroNova.TemPOL = 0;
            //Maxi
            clGlobal.ConfiguracaoMedidorMaxi.NSABNT = 0;
            clGlobal.ConfiguracaoMedidorMaxi.IDSMP = 0;
            clGlobal.ConfiguracaoMedidorMaxi.IUMedidor[0] = 0;
            clGlobal.ConfiguracaoMedidorMaxi.IUMedidor[1] = 0;
            clGlobal.ConfiguracaoMedidorMaxi.IUMedidor[2] = 0;
            clGlobal.ConfiguracaoMedidorMaxi.IUMedidor[3] = 0;
            clGlobal.ConfiguracaoMedidorMaxi.IUMedidor[3] = 0;
            clGlobal.ConfiguracaoMedidorMaxi.BitFlags = 0;
            clGlobal.ConfiguracaoMedidorMaxi.FundoEscala = 0;
            clGlobal.ConfiguracaoMedidorMaxi.InterSerial1 = 0;
            clGlobal.ConfiguracaoMedidorMaxi.InterSerial2 = 0;
            clGlobal.ConfiguracaoMedidorMaxi.Protocolos[0] = 0;
            clGlobal.ConfiguracaoMedidorMaxi.Protocolos[1] = 0;
            clGlobal.ConfiguracaoMedidorMaxi.Protocolos[2] = 0;
            for (int x = 0; x < 14; x++)
            {
                clGlobal.ConfiguracaoMedidorMaxi.NroPatrimonio[x] = 0;
            }
            //Easy
            clGlobal.ConfiguracaoEasy.NSABNT = 0;
            clGlobal.ConfiguracaoEasy.NSFabrica = 0;
            clGlobal.ConfiguracaoEasy.IUMedidor[0] = 0;
            clGlobal.ConfiguracaoEasy.IUMedidor[1] = 0;
            clGlobal.ConfiguracaoEasy.IUMedidor[2] = 0;
            clGlobal.ConfiguracaoEasy.IUMedidor[3] = 0;
            clGlobal.ConfiguracaoEasy.IUMedidor[4] = 0;
            clGlobal.ConfiguracaoEasy.BitFlags = 0;
            clGlobal.ConfiguracaoEasy.FundoEscala = 0;
            clGlobal.ConfiguracaoEasy.Protocolo = 0;
            
            //Parâmetros
            for (int PtrBuffer = 0; PtrBuffer < clGlobal.BufferParametrosMedidorHospedeiro.Length; PtrBuffer++)
            {
                clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] = 0;
            }
            //ABSOLUTO e Maxi
            AtualizaParametrosMedidorHospedeiro();
            //Easy
            clGlobal.ParametrosEasy.IntervaloMM = 0;
            clGlobal.ParametrosEasy.NumeroEntradas = 0;
            for (int x = 0; x < 16; x++)
            {
                clGlobal.ParametrosEasy.SelfRead[x].Minuto = 0;
                clGlobal.ParametrosEasy.SelfRead[x].Hora = 0;
                clGlobal.ParametrosEasy.SelfRead[x].Dia = 0;
                clGlobal.ParametrosEasy.SelfRead[x].Mes = 0;
                clGlobal.ParametrosEasy.SelfRead[x].Ano = 0;
            }
            for (int x = 0; x < 14; x++)
            {
                clGlobal.ParametrosEasy.NumeroTrafo[x] = 0;
            }
            clGlobal.ParametrosEasy.TensaoNominal = 0;
            clGlobal.ParametrosEasy.QeeFlags = 0;
            clGlobal.ParametrosEasy.ResRamal = 0;
            for (int x = 0; x < 12; x++)
            {
                ParametrosEasy.FaturaAuto[x].Dia = 0;
                ParametrosEasy.FaturaAuto[x].Mes = 0;
            }
            clGlobal.ParametrosEasy.Ligacao = 0;
            clGlobal.ParametrosEasy.PapelTermo = 0;
            for (int x = 0; x < 3; x++)
            {
                clGlobal.ParametrosEasy.PotNomTrafo[x] = 0;
                clGlobal.ParametrosEasy.SobreTensao[x] = 0;
                clGlobal.ParametrosEasy.SubTensao[x] = 0;
                clGlobal.ParametrosEasy.SobreCorrente[x] = 0;
            }

            //Outros
            //Registros de self-read
            for (int x = 0; x < 2000; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        clGlobal.RegistradoresSelfReadET[x].Registradores[y][z] = 0;
                    }
                    clGlobal.RegistradoresSelfReadEV[x].Registradores[y] = 0;
                }
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 6; z++)
                    {
                        clGlobal.RegistradoresSelfReadMaxi[x].Registradores[y][z] = 0;
                    }
                }
            }
            //Registros de faturas
            for (int x = 0; x < 100; x++)
            {
                FaturasEasy[x].FatId = 0;
                FaturasEasy[x].NroRepDem = 0;
                FaturasEasy[x].IniPerSegs = 0;
                FaturasEasy[x].UltPerSegs = 0;
                FaturasEasy[x].FaturasSegs = 0;
                for (int y = 0; y < 5; y++)
                {
                    FaturasEasy[x].Origem.IU[y] = 0;
                    for (int z = 0; z < 6; z++)
                    {
                        FaturasEasy[x].Registradores[y][z] = 0;
                    }
                    FaturasEasy[x].UFER[y] = 0;
                    FaturasEasy[x].DmcrMax[y] = 0;
                    FaturasEasy[x].DmcrAcum[y] = 0;
                    for (int z = 0; z < 2; z++)
                    {
                        FaturasEasy[x].DemMax[y][z] = 0;
                        FaturasEasy[x].DemAcum[z][z] = 0;
                    }
                }
                for (int y = 0; y < 2; y++)
                {
                    FaturasEasy[x].RegDicFic[y].DuracaoFaltas = 0;
                    FaturasEasy[x].RegDicFic[y].NroFaltas = 0;
                    for (int z = 0; z < 3; z++)
                    {
                        FaturasEasy[x].CteRTP[y][z] = 0;
                        FaturasEasy[x].CteRTC[y][z] = 0;
                    }
                }
                FaturasEasy[x].Crc16 = 0;
            }
            //Memória de massa SM
            if (InfoMMAB52.IUMedidor != null)
            {
                for (int x = 0; x < InfoMMAB52.IUMedidor.Length; x++)
                {
                    InfoMMAB52.IUMedidor[x] = 0;
                }
            }
            InfoMMAB52.TipoEstrutura = 0;
            InfoMMAB52.TamEstrutura = 0;
            InfoMMAB52.cteEnergia = 0;
            InfoMMAB52.cteTensao = 0;
            InfoMMAB52.cteCorrente = 0;
            InfoMMAB52.cteTHD = 0;
            InfoMMAB52.ctePerdas = 0;
            InfoMMAB52.cteTensaoPrimaria = 0;
            InfoMMAB52.cteCorrentePrimaria = 0;
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        ///////////////////////////////////////////////////////////////////////////////
        public static void MV_Start_Us()
        {
            QueryPerformanceCounter(out MV_Ref_Counter);
        }


        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempo_ms"></param>
        ///////////////////////////////////////////////////////////////////////////////
        public static int MV_Get_Us()
        {
            long counter_val;
            if (INT_UmPorSegundo == 0)
            {
                QueryPerformanceFrequency(out INT_UmPorSegundo);
            }
            QueryPerformanceCounter(out counter_val);
            return (int)((counter_val - MV_Ref_Counter) / (INT_UmPorSegundo / 1000000));
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempo_ms"></param>
        ///////////////////////////////////////////////////////////////////////////////
        public static void MV_Sleep_Ms(int tempo_ms)
        {
            long counter_val;
            if (tempo_ms < 1)
            {
                return;
            }
            if (INT_UmPorSegundo == 0)
            {
                QueryPerformanceFrequency(out INT_UmPorSegundo);
            }
            QueryPerformanceCounter(out counter_val);
            long time_out = counter_val + (int)((INT_UmPorSegundo / 1000) * tempo_ms);
            while (counter_val < time_out)
            {
                QueryPerformanceCounter(out counter_val);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumeroRele"></param>
        /// <param name="BOL_LigarRele"></param>
        /// ///////////////////////////////////////////////////////////////////////////////
        public static bool MPROC_AcionaRele(int NumeroRele, bool BOL_LigarRele)
        {
            if ((NumeroRele < 0) || (NumeroRele > 12))
            {
                return false;
            }

            if (BOL_LigarRele)
            {
                EstadoReles |= (0x01 << (NumeroRele - 1));
            }
            else
            {
                EstadoReles &= 0xFFF - (0x01 << (NumeroRele - 1));
            }
            return true;
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LBOL_TX"></param>
        /// <param name="LBOL_RX"></param>
        /// ///////////////////////////////////////////////////////////////////////////////
        public static void MPROC_ConfiguraSetasTransmissao(bool LBOL_TX, bool LBOL_RX)
        {
            clGlobal._TX = LBOL_TX;
            clGlobal._RX = LBOL_RX;
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdSetas"></param>
        /// ///////////////////////////////////////////////////////////////////////////////
        public static void MPROC_NovaConfiguraSetasTransmissao(byte IdSetas)
        {
            clGlobal.IdSetas = IdSetas;
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LBOL_LigaDesligaTimer"></param>
        /// ///////////////////////////////////////////////////////////////////////////////
        public static void MPROC_LigaDesligaTimer(bool LBOL_LigaDesligaTimer)
        {
            clGlobal._LigaDesligaTimer = LBOL_LigaDesligaTimer;
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LBOL_LigaDesligaTimerPaginaFiscal"></param>
        /// ///////////////////////////////////////////////////////////////////////////////
        public static void MPROC_LigaDesligaTimerPaginaFiscal(bool LBOL_LigaDesligaTimer)
        {
            clGlobal._LigaDesligaTimerPaginaFiscal = LBOL_LigaDesligaTimer;
        }

        public static void PROC_ExibeMsgDisplay(string LSTR_Msg, int LINT_NroLinha)
        {

            if (LINT_NroLinha == 0)
            {
                lbox_Comunica.Items.Clear();
                lbox_Comunica.Items.Add(LSTR_Msg);
            }
            else
            {
                if (LSTR_Msg.Contains("Lendo ") == true)
                {
                    if (lbox_Comunica.Items.Contains(LSTR_Msg) == true)
                    {
                        return;
                    }
                }

                int LINT_Item = lbox_Comunica.FindString("0---");
                if ((LSTR_Msg.Contains("0---") == true) && (LINT_Item >= 0))
                {
                    lbox_Comunica.Items[LINT_Item] = LSTR_Msg;
                }
                else
                    if (lbox_Comunica.Items.Count == 0)
                {
                    lbox_Comunica.Items.Add("");
                    lbox_Comunica.Items.Add(LSTR_Msg);
                    lbox_Comunica.Update();
                }
                else
                {
                    if (lbox_Comunica.Items.Count == 1)
                    {
                        lbox_Comunica.Items.Add(LSTR_Msg);
                    }
                    else
                    {
                        lbox_Comunica.Items[1] = LSTR_Msg;
                    }
                }
            }

            lbox_Comunica.SelectedIndex = lbox_Comunica.Items.Count - 1;
            lbox_Comunica.SelectedIndex = -1;
            lbox_Comunica.Update();
            lbox_Comunica.Visible = true;
            lbox_Comunica.BringToFront();
        }

        public static void PROC_InicializaEstrutura()
        {
            Int32 LINT_i;

            clGlobal._TelaAnterior = clGlobal.enumEstadoTela.eTelaInicial;
            clGlobal.IndiceLeiTelaAnterior = 0;
            clGlobal.IndiceEscTelaAnterior = 1;

            for(byte s=0; s < 14; s++)
            {
                clGlobal.HashIntervalos[s] = new byte[33];
            }

            clGlobal.MedidoresAtivos[0] = 0;
            clGlobal.MedidoresAtivos[1] = 0;
            clGlobal.MedidoresAtivos[2] = 0;
            clGlobal.MedidoresAtivos[3] = 0;
            clGlobal.MedidoresAtivos[4] = 0;
            clGlobal.MedidoresAtivos[5] = 0;
            clGlobal.MedidoresAtivos[6] = 0;
            clGlobal.MedidoresAtivos[7] = 0;

            clGlobal.rtbResultadoGlobal.Width = 856;
            clGlobal.rtbResultadoGlobal.Height = 575;
            clGlobal.rtbResultadoGlobalAux.Width = 856;
            clGlobal.rtbResultadoGlobalAux.Height = 575;

            EstadoReleLido = new byte[12];

            NovoSelfRead = new stSelfRead[16];

            RegistrosAtuaisEasy.AtivaDireta = new byte[5];
            RegistrosAtuaisEasy.AtivaReversa = new byte[5];
            RegistrosAtuaisEasy.ReativaPositiva = new byte[5];
            RegistrosAtuaisEasy.ReativaNegativa = new byte[5];
            RegistrosAtuaisEasy.AtivaDireta123 = new byte[5];
            RegistrosAtuaisEasy.AtivaReversa123 = new byte[5];
            RegistrosAtuaisEasy.ReativaPositiva123 = new byte[5];
            RegistrosAtuaisEasy.ReativaNegativa123 = new byte[5];
            RegistrosAtuaisEasy.AtivaDireta456 = new byte[5];
            RegistrosAtuaisEasy.AtivaReversa456 = new byte[5];
            RegistrosAtuaisEasy.ReativaPositiva456 = new byte[5];
            RegistrosAtuaisEasy.ReativaNegativa456 = new byte[5];

            clGlobal.EstadosRelesMedidorHospedeiro.TensaoReles = new float[15];
            clGlobal.EstadosRelesMedidorHospedeiro.AnguloReles = new float[15];

            for(int z=0; z < 2000; z++)
            {
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaAtivaDiretaMG = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaAtivaDiretaE123 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaAtivaDiretaE456 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].EspacoNuloEnergiaAtivaDireta = new byte[10];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaAtivaReversaMG = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaAtivaReversaE123 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaAtivaReversaE456 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].EspacoNuloEnergiaAtivaReversa = new byte[10];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaReativaPositivaMG = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaReativaPositivaE123 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaReativaPositivaE456 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].EspacoNuloEnergiaReativaPositiva = new byte[10];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaReativaNegativaMG = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaReativaNegativaE123 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].TotalGeralEnergiaReativaNegativaE456 = new byte[5];
                clGlobal.RegistradoresSelfRead[z].EspacoNuloEnergiaReativaNegativa = new byte[10];

                clGlobal.IndicadoresCompleto[z].Adequado = new UInt16[3];
                clGlobal.IndicadoresCompleto[z].Precario = new UInt16[3];
                clGlobal.IndicadoresCompleto[z].Critico = new UInt16[3];
                clGlobal.IndicadoresCompleto[z].TenMinima = new UInt16[3];
                clGlobal.IndicadoresCompleto[z].TenMaxima = new UInt16[3];
                clGlobal.IndicadoresCompleto[z].DHSegsMin = new UInt32[3];
                clGlobal.IndicadoresCompleto[z].DHSegsMax = new UInt32[3];

                clGlobal.LogEventoQEE[z].EveDados = new byte[20];
            }

            for(int z=0; z < 2000; z++)
            {
                clGlobal.RegistradoresSelfReadET[z].Registradores = new UInt32[3][];
                for (int x = 0; x < 3; x++)
                {
                    clGlobal.RegistradoresSelfReadET[z].Registradores[x] = new UInt32[4];
                }
            }

            for (int z = 0; z < 2000; z++)
            {
                clGlobal.RegistradoresSelfReadEV[z].Registradores = new UInt32[4];
            }

            for (int z = 0; z < 2000; z++)
            {
                clGlobal.RegistradoresSelfReadMaxi[z].Registradores = new UInt32[5][];
                for (int x = 0; x < 5; x++)
                {
                    clGlobal.RegistradoresSelfReadMaxi[z].Registradores[x] = new UInt32[6];
                }
            }

            for (int x = 0; x < 12; x++)
            {
                clGlobal._HabilitaReposicaoDemanda[x] = false;
                clGlobal.EstadoReleLido[x] = 0;
            }

            for (int x = 0; x < 15; x++)
            {
                clGlobal._HabilitaHorarioVerao[x] = false;
            }

            ConfiguracaoMedidorHospedeiroNova.IUMedidor = new byte[5];

            ConfiguracaoMedidorMaxi.NroPatrimonio = new byte[14];
            ConfiguracaoMedidorMaxi.Protocolos = new byte[3];
            ConfiguracaoMedidorMaxi.IUMedidor = new byte[5];

            ConfiguracaoEasy.IUMedidor = new byte[5];

            for(int z = 0; z<100; z++)
            {
                FaturasEasy[z].Origem.IU = new byte[5];
                FaturasEasy[z].Registradores = new UInt32[5][];
                for (int x = 0; x < 5; x++)
                {
                    FaturasEasy[z].Registradores[x] = new UInt32[6];
                }
                FaturasEasy[z].UFER = new UInt32[5];
                FaturasEasy[z].DemMax = new UInt16[5][];
                for (int x = 0; x < 5; x++)
                {
                    FaturasEasy[z].DemMax[x] = new UInt16[2];
                }
                FaturasEasy[z].DemAcum = new UInt32[5][];
                for (int x = 0; x < 5; x++)
                {
                    FaturasEasy[z].DemAcum[x] = new UInt32[2];
                }
                FaturasEasy[z].DmcrMax = new UInt16[5];
                FaturasEasy[z].DmcrAcum = new UInt32[5];
                FaturasEasy[z].RegDicFic = new stRegDicFic[2];
                FaturasEasy[z].CteRTP = new byte[2][];
                for (int x = 0; x < 2; x++)
                {
                    FaturasEasy[z].CteRTP[x] = new byte[3];
                }
                FaturasEasy[z].CteRTC = new byte[2][];
                for (int x = 0; x < 2; x++)
                {
                    FaturasEasy[z].CteRTC[x] = new byte[3];
                }
            }

            int TamParametrosMedidorMaxi = 0;
            ParametrosMedidorMaxi.IUDI = new byte[5];
            ParametrosMedidorMaxi.IUNeutro = new byte[5];
            ParametrosMedidorMaxi.NroTrafo = new byte[14];
            for (int x = 0; x < 14; x++)
            {
                ParametrosMedidorMaxi.NroTrafo[x] = 0x30;
            }
            ParametrosMedidorMaxi.FlagsExib = new byte[9];
            ParametrosMedidorMaxi.ModoTotDem = new byte[2];
            ParametrosMedidorMaxi.CteRTP = new byte[2][];
            ParametrosMedidorMaxi.CteRTP[0] = new byte[3];
            ParametrosMedidorMaxi.CteRTP[1] = new byte[3];
            ParametrosMedidorMaxi.CteRTC = new byte[2][];
            ParametrosMedidorMaxi.CteRTC[0] = new byte[3];
            ParametrosMedidorMaxi.CteRTC[1] = new byte[3];
            ParametrosMedidorMaxi.CteKP = new byte[2][];
            ParametrosMedidorMaxi.CteKP[0] = new byte[3];
            ParametrosMedidorMaxi.CteKP[1] = new byte[3];
            ParametrosMedidorMaxi.FaturaAuto = new stFaturaAuto[12];
            ParametrosMedidorMaxi.TarifaReativos = new stTarifaReativos[2];
            ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo = new stPosto[2][];
            ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[0] = new stPosto[2];
            ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[1] = new stPosto[2];
            ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo = new stPosto[2][];
            ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[0] = new stPosto[2];
            ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[1] = new stPosto[2];
            ParametrosMedidorMaxi.SelfRead = new stSelfRead[16];
            ParametrosMedidorMaxi.HorarioVerao = new stHorarioVerao[cte_Numero_Horario_Verao];
            ParametrosMedidorMaxi.Feriados = new stFeriados[cte_Numero_Feriados];
            ParametrosMedidorMaxi.PostoHorario = new stPostoHorario[2];
            ParametrosMedidorMaxi.CfgRemota = new byte[245];
            for (int x = 0; x < 2; x++)
            {
                //TamParametrosMedidorMaxi += Marshal.SizeOf(ParametrosMedidorMaxi.PostoHorario[x].Dia);
                //TamParametrosMedidorMaxi += Marshal.SizeOf(ParametrosMedidorMaxi.PostoHorario[x].Mes);
                //TamParametrosMedidorMaxi += Marshal.SizeOf(ParametrosMedidorMaxi.PostoHorario[x].Ano);
                //TamParametrosMedidorMaxi += Marshal.SizeOf(ParametrosMedidorMaxi.PostoHorario[x].DesvioHorarioVerao);

                ParametrosMedidorMaxi.PostoHorario[x].Postos = new stPostos[cte_Numero_Dias_Semana + 1];
                for (int y = 0; y < (cte_Numero_Dias_Semana + 1); y++)
                {
                    //TamParametrosMedidorMaxi += Marshal.SizeOf(ParametrosMedidorMaxi.PostoHorario[x].Postos[y].Ativacao);

                    ParametrosMedidorMaxi.PostoHorario[x].Postos[y].InicioPosto = new stPosto[4][];
                    for (int h = 0; h < (cte_Numero_PH - 1); h++)
                    {
                        ParametrosMedidorMaxi.PostoHorario[x].Postos[y].InicioPosto[h] = new stPosto[4];
                        //TamParametrosMedidorMaxi += Marshal.SizeOf(ParametrosMedidorMaxi.PostoHorario[x].Postos[y].InicioPosto[h][0]) * 4;
                    }
                }
            }
            TamParametrosMedidorMaxi += Marshal.SizeOf(ParametrosMedidorMaxi.NroTrafo[0]) * 536;

            //Easy
            ParametrosEasy.SelfRead = new stSelfRead[16];
            ParametrosEasy.NumeroTrafo = new byte[14];
            for (int x = 0; x < 14; x++)
            {
                ParametrosEasy.NumeroTrafo[x] = 0x30;
            }
            ParametrosEasy.FaturaAuto = new stFaturaAuto[12];
            ParametrosEasy.PotNomTrafo = new int[3];
            ParametrosEasy.SobreTensao = new int[3];
            ParametrosEasy.SubTensao = new int[3];
            ParametrosEasy.SobreCorrente = new int[3];

            for (int x = 0; x < clGlobal.LogAlter.Length; x++)
            {
                LogAlter[x].Origem = new byte[5];
                LogAlter[x].Antes = new byte[323];
                LogAlter[x].Depois = new byte[323];
            }

            for (int x = 0; x < clGlobal.LogAlterMaxi.Length; x++)
            {
                LogAlterMaxi[x].Origem = new byte[5];
                LogAlterMaxi[x].Antes = new byte[268];
                LogAlterMaxi[x].Depois = new byte[268];
            }

            for (int x = 0; x < clGlobal.LogAlterEasy.Length; x++)
            {
                LogAlterEasy[x].Origem = new byte[5];
                LogAlterEasy[x].Antes = new byte[40];
                LogAlterEasy[x].Depois = new byte[40];
            }

            ListaDispositivosBLE.Items.Clear();

            int TamParametrosMedidorHospedeiro = 0;

            // MedAtivo
            TamParametrosMedidorHospedeiro = Marshal.SizeOf(ParametrosMedidorHospedeiro.MedAtivo);

            // MedUC
            ParametrosMedidorHospedeiro.MedUC = new UInt32[cte_Numero_Medidores];
            TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.MedUC[0]) * cte_Numero_Medidores;

            // IUDI
            ParametrosMedidorHospedeiro.IUDI = new byte[cte_Numero_Medidores][];
            //TamParametrosMedidorHospedeiro = 0;
            for (int x = 0; x < cte_Numero_Medidores; x++)
            {
                ParametrosMedidorHospedeiro.IUDI[x] = new byte[5];
                TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.IUDI[x][0]) * 5;
            }

            // DataHora
            ParametrosMedidorHospedeiro.DataHora = new stDataHora();
            TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.DataHora);

            // Feriados
            ParametrosMedidorHospedeiro.Feriados = new stFeriados[cte_Numero_Feriados];
            TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.Feriados[0]) * cte_Numero_Feriados;

            // Horário de Verão
            ParametrosMedidorHospedeiro.HorarioVerao = new stHorarioVerao[cte_Numero_Horario_Verao];
            HorarioVeraoAuxiliar = new stHorarioVerao[cte_Numero_Horario_Verao];
            HorarioVeraoAuxiliar2 = new stHorarioVerao[cte_Numero_Horario_Verao];
            TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.HorarioVerao[0]) * cte_Numero_Horario_Verao;

            // CodExibir
            ParametrosMedidorHospedeiro.CodExibir = new UInt64[cte_Numero_Display + 1];
            TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.CodExibir[0]) * (cte_Numero_Display + 1);

            // FaturaAuto
            ParametrosMedidorHospedeiro.FaturaAuto = new stFaturaAuto[cte_Numero_Fatura];
            TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.FaturaAuto[0]) * (cte_Numero_Fatura);

            // Postos Horários
            ParametrosMedidorHospedeiro.PostoHorario = new stPostoHorario[2];
            //TamParametrosMedidorHospedeiro = 0;
            for (int x = 0; x < 2; x++)
            {
                TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.PostoHorario[x].Dia);
                TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.PostoHorario[x].Mes);
                TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.PostoHorario[x].Ano);
                TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.PostoHorario[x].DesvioHorarioVerao);

                ParametrosMedidorHospedeiro.PostoHorario[x].Postos = new stPostos[cte_Numero_Dias_Semana + 1];
                PostosUniversais[x].Postos = new stPostos[cte_Numero_Dias_Semana + 1];
                for (int y = 0; y < (cte_Numero_Dias_Semana + 1); y++)
                {
                    PostosUniversais[x].Postos[y].Ativacao = (byte)(y + 1);
                    TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.PostoHorario[x].Postos[y].Ativacao);

                    ParametrosMedidorHospedeiro.PostoHorario[x].Postos[y].InicioPosto = new stPosto[4][];
                    PostosUniversais[x].Postos[y].InicioPosto = new stPosto[4][];
                    for (int h = 0; h < (cte_Numero_PH - 1); h++)
                    {
                        ParametrosMedidorHospedeiro.PostoHorario[x].Postos[y].InicioPosto[h] = new stPosto[4];
                        TamParametrosMedidorHospedeiro += Marshal.SizeOf(ParametrosMedidorHospedeiro.PostoHorario[x].Postos[y].InicioPosto[h][0]) * 4;
                        PostosUniversais[x].Postos[y].InicioPosto[h] = new stPosto[4];
                    }
                }
            }

            GrandezasInstantaneas.Tensao = new float[cte_Numero_Fases];
            GrandezasInstantaneas.TenLinha = new float[cte_Numero_Fases];
            GrandezasInstantaneas.DefTensao = new float[cte_Numero_Fases];
            GrandezasInstantaneas.Corrente = new float[cte_Numero_Elementos];
            GrandezasInstantaneas.Defasamento = new float[cte_Numero_Elementos];
            GrandezasInstantaneas.Ativa = new float[cte_Numero_Elementos];
            GrandezasInstantaneas.Reativa = new float[cte_Numero_Elementos];
            GrandezasInstantaneas.VerRev = new uint[2];

            //BufferParametrosMedidorHospedeiro = new byte[TamParametrosMedidorHospedeiro];
            BufferParametrosMedidorHospedeiro = new byte[((255 - 9) + 1) * 6];

            for (int i = clGlobal.cte_opPrimeira; i < cte_opUltima; i++)
            {
                OperacoesDeComunicacao[i].Operacao = "";
                OperacoesDeComunicacao[i].TipoOperacao = clGlobal.ENM_TOperacao.oCodiNormal;
                OperacoesDeComunicacao[i].EhReposicao = false;
                OperacoesDeComunicacao[i].EhAlteracao = false;
                OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes = new clGlobal.TAtributosDeComando[clGlobal.cte_NumeroMaximoDeSubOperacoes];

                for (int j = 0; j < clGlobal.cte_NumeroMaximoDeSubOperacoes; j++)
                {

                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].TipoDeComando = clGlobal.ENUM_TComando.cmdComandoInvalido;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].CodigoDeComandoEstendidoDosOctetos = 0x00;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].CodigoDoMonitorDeQualidade = 0x00;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taNormal;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].AvancoDoApontadorDeSubOperacao = 1;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].ComandoCodi = clGlobal.ENUM_TComandoCodi.codSimples;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveGerarBlocoDeConexao = false;

                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarQuatroQuadrantes = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarHorarioDeVerao = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarSeTemPaginaFiscal = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveInverterVisibilidadeDosQuadrantes = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarSeTemParametrosDeMedicao = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarSeTemParametrosDeQualidade = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarSeTemParametrosDeCompensacaoDePerdas = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarSeTemMonitorAtivo = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarSeEhMedidorDeQualidade = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarSeTemGrandezasEmRegistro = false;

                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveTestarRegistradoresZerados = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DevePegarONumeroDePalavrasDaMemoriaDeMassa = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].ComandoEloNetAEnviar = 0;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].EhAlteracaoElonet = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].FormaAlternativaDeCalcularNumeroDeBlocosDaMM = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DeveAbortarSeDerComandoNaoImplementado = false;
                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 0;

                    OperacoesDeComunicacao[i].ConjuntoDeSubOperacoes[j].DevePegarNumeroDeGruposDeCanais = false;
                }
            }

            //  Definicoes de Leitura de Registradores Atuais.

            OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresAtuais].Operacao = "Leitura de Registradores Atuais";
            OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresAtuais].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresAtuais].EhAlteracao = false;

            //clGlobal._grupoSelecionado = 0x02;
            //clGlobal._leReverso = true;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresAtuais].ConjuntoDeSubOperacoes;

            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = false;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = false;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = false;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = false;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAtuais;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;
            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;

            //  Definicoes de Leitura de Registradores Ultima Reposição de Demanda.

            OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresUltimaReposicao].Operacao = "Leitura de Registradores da Última Reposição";
            OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresUltimaReposicao].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresUltimaReposicao].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opLerRegistradoresUltimaReposicao].ConjuntoDeSubOperacoes;

            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = false;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = false;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = false;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = false;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = false;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;

            //  Definicoes da Verificacao Resumida

            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoResumida].Operacao = "Verificação Resumida";
            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoResumida].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoResumida].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opVerificacaoResumida].ConjuntoDeSubOperacoes;
            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;


            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAtuais;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveInverterVisibilidadeDosQuadrantes = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAtuais;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Verificacao

            OperacoesDeComunicacao[clGlobal.cte_opVerificacao].Operacao = "Verificação";
            OperacoesDeComunicacao[clGlobal.cte_opVerificacao].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opVerificacao].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opVerificacao].ConjuntoDeSubOperacoes;

            LINT_i = 0;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 74;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAtuais;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coMemoriaDeMassaAtuais;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveInverterVisibilidadeDosQuadrantes = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 74;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAtuais;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coMemoriaDeMassaAtuais;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Verificacao Parcial

            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoParcial].Operacao = "Verificação Parcial";
            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoParcial].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoParcial].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opVerificacaoParcial].ConjuntoDeSubOperacoes;

            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coParametrosParaTodaMemoriaDeMassa;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 74;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coTodaMemoriaDeMassa;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coParametrosParaTodaMemoriaDeMassa;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveInverterVisibilidadeDosQuadrantes = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 74;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coTodaMemoriaDeMassa;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Verificacao de Grandezas

            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoDeGrandezas].Operacao = "Verificação de Grandezas";
            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoDeGrandezas].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opVerificacaoDeGrandezas].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opVerificacaoDeGrandezas].ConjuntoDeSubOperacoes;

            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = false;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdMudaOperacaoSeRegistroDeGrandezasForABNT;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarSeTemGrandezasEmRegistro = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coCabecalhoDeRegistroDeMMS;
            SubOperacao[LINT_i].FormaAlternativaDeCalcularNumeroDeBlocosDaMM = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 6;
            SubOperacao[LINT_i].DeveAbortarSeDerComandoNaoImplementado = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeMMS;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Verificacao Parcial de Grandezas

            OperacoesDeComunicacao[clGlobal.cte_opGrandezasParciais].Operacao = "Verificação Parcial das Grandezas";
            OperacoesDeComunicacao[clGlobal.cte_opGrandezasParciais].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opGrandezasParciais].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opGrandezasParciais].ConjuntoDeSubOperacoes;

            LINT_i = 0;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coParametrosParaTodaMemoriaDeMassa;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = false;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdMudaOperacaoSeRegistroDeGrandezasForABNT;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].DeveTestarSeTemGrandezasEmRegistro = true;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coCabecalhoDeRegistroDeMMS;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 6;
            SubOperacao[LINT_i].FormaAlternativaDeCalcularNumeroDeBlocosDaMM = true;
            SubOperacao[LINT_i].DeveAbortarSeDerComandoNaoImplementado = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeMMS;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Recuperacao Resumida

            OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoResumida].Operacao = "Recuperação Resumida";
            OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoResumida].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoResumida].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoResumida].ConjuntoDeSubOperacoes;

            LINT_i = 0;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAnteriores;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAnteriores;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveInverterVisibilidadeDosQuadrantes = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Recuperacao

            OperacoesDeComunicacao[clGlobal.cte_opRecuperacao].Operacao = "Recuperação";
            OperacoesDeComunicacao[clGlobal.cte_opRecuperacao].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opRecuperacao].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opRecuperacao].ConjuntoDeSubOperacoes;

            LINT_i = 0;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAnteriores;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 78;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coMemoriaDeMassaAnteriores;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAnteriores;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveInverterVisibilidadeDosQuadrantes = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 78;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;
            SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coMemoriaDeMassaAnteriores;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Fatura

            OperacoesDeComunicacao[clGlobal.cte_opFatura].Operacao = "Reposição de Demanda";
            OperacoesDeComunicacao[clGlobal.cte_opFatura].EhReposicao = true;
            OperacoesDeComunicacao[clGlobal.cte_opFatura].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opFatura].ConjuntoDeSubOperacoes;

            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosComReposicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 78;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            //SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            //SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;


            //if (clGlobal.lbModeloGeralMedidor == "Absoluto")
            //{
            //    LINT_i++;
            //    SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //    SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;
            //}

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;
            //SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;
            //SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;
            //SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coMemoriaDeMassaAnteriores;
            //SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            //SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;
            
            /*
            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosComReposicao;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarONumeroDePalavrasDaMemoriaDeMassa = true;
            SubOperacao[LINT_i].DeveInverterVisibilidadeDosQuadrantes = true;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 78;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            if (clGlobal.lbModeloGeralMedidor == "Absoluto")
            {
                LINT_i++;
                SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
                SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;
            }

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;
            //SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;
            //SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;
            //SubOperacao[LINT_i].DeveTestarRegistradoresZerados = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coMemoriaDeMassaAnteriores;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;
            */
            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Reposicao Resumida
            OperacoesDeComunicacao[clGlobal.cte_opFaturaResumida].Operacao = "Reposição Resumida";
            OperacoesDeComunicacao[clGlobal.cte_opFaturaResumida].EhReposicao = true;
            OperacoesDeComunicacao[clGlobal.cte_opFaturaResumida].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opFaturaResumida].ConjuntoDeSubOperacoes;

            LINT_i = 0;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosComReposicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            //SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosComReposicao;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveInverterVisibilidadeDosQuadrantes = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAnteriores;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal2;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAnterioresDoCanal3;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;


            //  Definicoes da Recuperacao de Grandezas

            OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoDeGrandezas].Operacao = "Recuperação de Grandezas";
            OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoDeGrandezas].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoDeGrandezas].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opRecuperacaoDeGrandezas].ConjuntoDeSubOperacoes;

            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAnteriores;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = false;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = true;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdLeDadosDosGruposDeCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdMudaOperacaoSeRegistroDeGrandezasForABNT;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdCopiaBufferErro;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].DeveTestarSeTemGrandezasEmRegistro = true;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coCabecalhoDeRegistroDeMMS;
            SubOperacao[LINT_i].PosicaoAPegarONumeroDePalavrasDaMemoriaDeMassa = 6;
            SubOperacao[LINT_i].FormaAlternativaDeCalcularNumeroDeBlocosDaMM = true;
            SubOperacao[LINT_i].DeveAbortarSeDerComandoNaoImplementado = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistrodDeFaltasDeEnergia;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeMMS;
            SubOperacao[LINT_i].ComandoCodi = clGlobal.ENUM_TComandoCodi.codComposto;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;



            // Visualiza Parâmetros Atuais
            OperacoesDeComunicacao[clGlobal.cte_opVisParametrosAtuais].Operacao = "Visualiza Parâmetros Atuais";
            OperacoesDeComunicacao[clGlobal.cte_opVisParametrosAtuais].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opVisParametrosAtuais].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opVisParametrosAtuais].ConjuntoDeSubOperacoes;

            LINT_i = 0;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;  // Compensação de perdas
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdParametrosOnLine;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taContinuaSeNaoAbortou;
            SubOperacao[LINT_i].AvancoDoApontadorDeSubOperacao = 1;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coAlteracaoDoHorarioDeVerao;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdParametrosOnLine;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taContinuaSeNaoAbortou;
            SubOperacao[LINT_i].AvancoDoApontadorDeSubOperacao = 1;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = true;
            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeCompensacaoDePerdas;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdParametrosOnLine;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taContinuaSeNaoAbortou;
            SubOperacao[LINT_i].AvancoDoApontadorDeSubOperacao = 1;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;
            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdParametrosOnLine;
            SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taContinuaSeNaoAbortou;
            SubOperacao[LINT_i].AvancoDoApontadorDeSubOperacao = 1;

            LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;

            //  Definicoes para a Página Fiscal  (visualizacao!!)

            OperacoesDeComunicacao[clGlobal.cte_opVisPaginaFiscal].Operacao = "Visualização de Página Fiscal";
            OperacoesDeComunicacao[clGlobal.cte_opVisPaginaFiscal].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opVisPaginaFiscal].EhAlteracao = false;

            SubOperacao = @OperacoesDeComunicacao[clGlobal.cte_opVisPaginaFiscal].ConjuntoDeSubOperacoes;
            LINT_i = 0;

            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;
            SubOperacao[LINT_i].DeveTestarHorarioDeVerao = false;
            SubOperacao[LINT_i].DeveTestarSeTemPaginaFiscal = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeMedicao = true;
            SubOperacao[LINT_i].DeveTestarSeTemParametrosDeCompensacaoDePerdas = false;
            SubOperacao[LINT_i].DeveGerarBlocoDeConexao = false;
            SubOperacao[LINT_i].DevePegarNumeroDeGruposDeCanais = false;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosDeMedicao;
            //SubOperacao[LINT_i].DeveTestarQuatroQuadrantes = true;

            //LINT_i++;
            SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coGrandezasInstantaneas;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistradoresAtuais;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal1;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal2;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDosRegistradoresParciaisAtuaisDoCanal3;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            //SubOperacao[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coRegistroDeAlteracoes;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTerminaSeNaoForQuatroQuadrantes;
            //SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            //SubOperacao[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            //SubOperacao[LINT_i].NaoDeveGerarDadoParaGravar = true;

            //LINT_i++;
            //SubOperacao[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;

            //  Definicoes para as Visulalização de DIC e FIC:

            //  Definicoes de Ler VTCD

            //  Definicoes de Ler VTLD

            //  Definicoes para operacao de Leitura dos dados dos grupos de canais            
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].Operacao = "Leitura dos Grupos de Canais";
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].EhReposicao = false;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].EhAlteracao = false;

            LINT_i = 0;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdComunica;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].CodigoDeComandoDosOctetos = clGlobal.cte_coLeituraDeParametrosAtuais;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].DeveTestarSeCompensaEnergia = true;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].DevePegarNumeroDeGruposDeCanais = true;

            LINT_i++;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTesteDeCondicao;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].TipoDeAvancoDoApontadorDeSubOperacao = clGlobal.ENUM_TTipoDeAvancoDoApontadorDeSubOperacao.taRepeteOperacaoSeNaoLeuTodosOsCanais;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].NaoDeveGerarDadoParaGravar = true;

            LINT_i++;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdRetornaParaUltimaOperacao;

            LINT_i++;
            OperacoesDeComunicacao[clGlobal.cte_opLeituraDosDadosDosGruposDeCanais].ConjuntoDeSubOperacoes[LINT_i].TipoDeComando = clGlobal.ENUM_TComando.cmdTermina;

            //Ocorrências
            OcorrenciasMedidorAB40.OcorrenciasMedidor = new stOcorrencias[24];
    }

        public static void PROC_Int32ToBCD(Int32 Val1, ref Int32 Val2)
        {
            string textoAux;
            byte Valor;
            Int32 ValAux;
            ValAux = Val1;
            textoAux = ValAux.ToString("D");
            char[] chars = textoAux.ToCharArray();
            if (chars.Length > 1)
            {
                ValAux = 0;
                for (Int32 x = 0; x < chars.Length; x++)
                {
                    Valor = byte.Parse(chars[x].ToString());
                    ValAux += Valor * (Int32)System.Math.Pow(16, ((chars.Length - 1) - x));
                }
                //ValAux = ValAux * 16;
                //ValAux = ValAux + Int32.Parse(chars[1].ToString());
            }
            else
            {
                ValAux = byte.Parse(chars[0].ToString());
            }
            Val2 = ValAux;
        }

        public static void PROC_Int64ToBCD(UInt64 Val1, ref UInt64 Val2)
        {
            string textoAux;
            byte Valor;
            UInt64 ValAux;
            ValAux = Val1;
            textoAux = ValAux.ToString("D");
            char[] chars = textoAux.ToCharArray();
            if (chars.Length > 1)
            {
                ValAux = 0;
                for (Int64 x = 0; x < chars.Length; x++)
                {
                    Valor = byte.Parse(chars[x].ToString());
                    ValAux += Valor * (UInt64)System.Math.Pow(16, ((chars.Length - 1) - x));
                }
                //ValAux = ValAux * 16;
                //ValAux = ValAux + Int32.Parse(chars[1].ToString());
            }
            else
            {
                ValAux = byte.Parse(chars[0].ToString());
            }
            Val2 = ValAux;
        }

        public static void AtualizaParametrosMedidorHospedeiro()
        {
            int PtrBuffer = 0;

            if(clGlobal.lbModeloGeralMedidor == "Absoluto")
            {
                //------------ Inicio do primeiro bloco -------------
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo = (ulong)clGlobal.BufferParametrosMedidorHospedeiro[7] << 56;
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo |= (ulong)clGlobal.BufferParametrosMedidorHospedeiro[6] << 48;
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo |= (ulong)clGlobal.BufferParametrosMedidorHospedeiro[5] << 40;
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo |= (ulong)clGlobal.BufferParametrosMedidorHospedeiro[4] << 32;
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo |= (ulong)clGlobal.BufferParametrosMedidorHospedeiro[3] << 24;
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo |= (ulong)clGlobal.BufferParametrosMedidorHospedeiro[2] << 16;
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo |= (ulong)clGlobal.BufferParametrosMedidorHospedeiro[1] << 8;
                clGlobal.ParametrosMedidorHospedeiro.MedAtivo |= (ulong)clGlobal.BufferParametrosMedidorHospedeiro[0];


                clGlobal.MedidoresAtivos[7] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.MedidoresAtivos[6] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.MedidoresAtivos[5] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.MedidoresAtivos[4] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.MedidoresAtivos[3] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.MedidoresAtivos[2] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.MedidoresAtivos[1] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.MedidoresAtivos[0] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];

                for (int i = 0; i < cte_Numero_Medidores; i++)
                {
                    clGlobal.ParametrosMedidorHospedeiro.MedUC[i] = (uint)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.MedUC[i] |= ((uint)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 8);
                    clGlobal.ParametrosMedidorHospedeiro.MedUC[i] |= ((uint)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 16);
                    clGlobal.ParametrosMedidorHospedeiro.MedUC[i] |= ((uint)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 24);
                }

                for (int i = 0; i < cte_Numero_Medidores; i++)
                {
                    clGlobal.ParametrosMedidorHospedeiro.IUDI[i][0] = (byte)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.IUDI[i][1] = (byte)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.IUDI[i][2] = (byte)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.IUDI[i][3] = (byte)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.IUDI[i][4] = (byte)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }
                //------------ fim do primeiro bloco ----------------

                // ----------- Inicio do segundo Bloco --------------
                clGlobal.ParametrosMedidorHospedeiro.DataHora.Segundo = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorHospedeiro.DataHora.Minuto = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorHospedeiro.DataHora.Hora = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorHospedeiro.DataHora.Dia = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorHospedeiro.DataHora.DiaSemana = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorHospedeiro.DataHora.Mes = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorHospedeiro.DataHora.Ano = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];

                for (int x = 0; x < 82; x++)
                {
                    clGlobal.ParametrosMedidorHospedeiro.Feriados[x].Dia = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.Feriados[x].Mes = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.Feriados[x].Ano = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }
                // ----------- Fim do segundo bloco ------------------

                // ----------- Inicio do terceiro bloco -------------
                for (int x = 0; x < clGlobal.cte_Numero_Horario_Verao; x++)
                {
                    clGlobal.ParametrosMedidorHospedeiro.HorarioVerao[x].DiaInicio = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.HorarioVerao[x].MesInicio = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.HorarioVerao[x].AnoInicio = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.HorarioVerao[x].DiaFim = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.HorarioVerao[x].MesFim = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.HorarioVerao[x].AnoFim = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }

                for (int x = 0; x < (cte_Numero_Display + 1); x++)
                {
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] = ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] |= ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 8);
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] |= ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 16);
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] |= ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 24);
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] |= ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 32);
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] |= ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 40);
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] |= ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 48);
                    clGlobal.ParametrosMedidorHospedeiro.CodExibir[x] |= ((UInt64)clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 56);
                }
                // ----------- Fim do terceiro bloco ----------------

                // ----------- Inicio do quarto bloco ---------------
                for (int x = 0; x < 12; x++)
                {
                    clGlobal.ParametrosMedidorHospedeiro.FaturaAuto[x].Dia = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.FaturaAuto[x].Mes = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }

                for (int d = 0; d < 2; d++)
                {
                    clGlobal.ParametrosMedidorHospedeiro.PostoHorario[d].Dia = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.PostoHorario[d].Mes = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.PostoHorario[d].Ano = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorHospedeiro.PostoHorario[d].DesvioHorarioVerao = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    for (int y = 0; y < 8; y++)
                    {
                        clGlobal.ParametrosMedidorHospedeiro.PostoHorario[d].Postos[y].Ativacao = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                        for (int h = 0; h < (clGlobal.cte_Numero_PH - 1); h++)
                        {
                            for (int s = 0; s < (clGlobal.cte_Numero_PH - 1); s++)
                            {
                                clGlobal.ParametrosMedidorHospedeiro.PostoHorario[d].Postos[y].InicioPosto[h][s].Minuto = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                                clGlobal.ParametrosMedidorHospedeiro.PostoHorario[d].Postos[y].InicioPosto[h][s].Hora = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                            }
                        }
                    }
                }
                // ----------- Fim do quarto bloco ------------------
            }
            else if(clGlobal.lbModeloGeralMedidor == "Maxi-Extend-Unique")
            {
                //------------ Inicio do primeiro bloco -------------
                clGlobal.ParametrosMedidorMaxi.MedUC = (UInt32)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.MedUC |= (UInt32)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 8);
                clGlobal.ParametrosMedidorMaxi.MedUC |= (UInt32)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 16);
                clGlobal.ParametrosMedidorMaxi.MedUC |= (UInt32)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++] << 24);

                clGlobal.ParametrosMedidorMaxi.IUDI[0] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUDI[1] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUDI[2] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUDI[3] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUDI[4] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);

                clGlobal.ParametrosMedidorMaxi.IUNeutro[0] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUNeutro[1] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUNeutro[2] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUNeutro[3] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                clGlobal.ParametrosMedidorMaxi.IUNeutro[4] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);

                for(int x = 0; x < 14; x++)
                {
                    clGlobal.ParametrosMedidorMaxi.NroTrafo[x] = (byte)(clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++]);
                }

                clGlobal.ParametrosMedidorMaxi.FlagsExib[0] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[1] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[2] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[3] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[4] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[5] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[6] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[7] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FlagsExib[8] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.TensaoNominal = BitConverter.ToSingle(clGlobal.BufferParametrosMedidorHospedeiro, PtrBuffer);
                PtrBuffer += 4;

                clGlobal.ParametrosMedidorMaxi.Ligacao = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.SaidaSerial = BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.ModoTotDem[0] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.ModoTotDem[1] = BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.CteKP[0][0] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteKP[0][1] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteKP[0][2] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteKP[1][0] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteKP[1][1] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteKP[1][2] = BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.CteRTP[0][0] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTP[0][1] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTP[0][2] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTP[1][0] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTP[1][1] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTP[1][2] = BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.CteRTC[0][0] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTC[0][1] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTC[0][2] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTC[1][0] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTC[1][1] = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.CteRTC[1][2] = BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.FaturaAuto[0].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[0].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[1].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[1].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[2].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[2].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[3].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[3].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[4].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[4].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[5].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[5].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[6].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[6].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[7].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[7].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[8].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[8].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[9].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[9].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[10].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[10].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[11].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.FaturaAuto[11].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].Ano = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].SegRtAtivos = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].SegRtAtivos <<= 8;
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].SegRtAtivos |= BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].FatPotRef = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[0][0].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[0][0].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[0][1].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[0][1].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[1][0].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[1][0].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[1][1].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[0].PostoReativo[1][1].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];

                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].Ano = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].SegRtAtivos = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].SegRtAtivos <<= 8;
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].SegRtAtivos |= BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].FatPotRef = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[0][0].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[0][0].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[0][1].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[0][1].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[1][0].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[1][0].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[1][1].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                clGlobal.ParametrosMedidorMaxi.TarifaReativos[1].PostoReativo[1][1].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                
                for (int x=0; x < 16; x++)
                {
                    clGlobal.ParametrosMedidorMaxi.SelfRead[x].Minuto = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.SelfRead[x].Hora = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.SelfRead[x].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.SelfRead[x].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.SelfRead[x].Ano = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }
                for (int x = 0; x < 15; x++)
                {
                    clGlobal.ParametrosMedidorMaxi.HorarioVerao[x].DiaInicio = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.HorarioVerao[x].MesInicio = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.HorarioVerao[x].AnoInicio = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.HorarioVerao[x].DiaFim = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.HorarioVerao[x].MesFim = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.HorarioVerao[x].AnoFim = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }
                for (int x = 0; x < 82; x++)
                {
                    clGlobal.ParametrosMedidorMaxi.Feriados[x].Dia = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.Feriados[x].Mes = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.Feriados[x].Ano = BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }
                
                for (int d = 0; d < 2; d++)
                {
                    clGlobal.ParametrosMedidorMaxi.PostoHorario[d].Dia = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.PostoHorario[d].Mes = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.PostoHorario[d].Ano = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    clGlobal.ParametrosMedidorMaxi.PostoHorario[d].DesvioHorarioVerao = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                    for (int y = 0; y < 8; y++)
                    {
                        clGlobal.ParametrosMedidorMaxi.PostoHorario[d].Postos[y].Ativacao = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                        for (int h = 0; h < (clGlobal.cte_Numero_PH - 1); h++)
                        {
                            for (int s = 0; s < (clGlobal.cte_Numero_PH - 1); s++)
                            {
                                clGlobal.ParametrosMedidorMaxi.PostoHorario[d].Postos[y].InicioPosto[h][s].Minuto = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                                clGlobal.ParametrosMedidorMaxi.PostoHorario[d].Postos[y].InicioPosto[h][s].Hora = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                            }
                        }
                    }
                }

                for (int x = 0; x < 245; x++)
                {
                    clGlobal.ParametrosMedidorMaxi.CfgRemota[x] = clGlobal.BufferParametrosMedidorHospedeiro[PtrBuffer++];
                }

                    //------------ fim do primeiro bloco ----------------
            }
        }


        public static byte PegaIndiceMedidor(string NumeroSerie)
        {
            byte IndiceMedidor = 0;

            switch (NumeroSerie)
            {
                // Monfásicos
                case "010000":
                case "010200":
                case "010203":
                case "142536":
                    //case "123456":
                    IndiceMedidor = 0;
                    break;
                case "020000":
                case "020300":
                case "020304":
                    IndiceMedidor = 1;
                    break;
                case "030000":
                case "030400":
                case "030405":
                    IndiceMedidor = 2;
                    break;
                case "040000":
                case "040500":
                case "040506":
                    IndiceMedidor = 3;
                    break;
                case "050000":
                case "050600":
                case "050607":
                    IndiceMedidor = 4;
                    break;
                case "060000":
                case "060700":
                case "060708":
                    IndiceMedidor = 5;
                    break;
                case "070000":
                case "070800":
                case "070809":
                    IndiceMedidor = 6;
                    break;
                case "080000":
                case "080900":
                case "080910":
                    IndiceMedidor = 7;
                    break;
                case "090000":
                case "091000":
                case "091011":
                    IndiceMedidor = 8;
                    break;
                case "100000":
                case "101100":
                case "101112":
                    IndiceMedidor = 9;
                    break;
                case "110000":
                case "111200":
                    IndiceMedidor = 10;
                    break;
                case "120000":
                    IndiceMedidor = 11;
                    break;
            }
            return IndiceMedidor;
        }

        public static void PegaMedidoresAtivos(object sender, EventArgs e)
        {
            // Monsta lista de medidores ativos dentro do CcheckBox
            ListaMedidoresAtivos.Items.Clear();

            ListaMedidoresAtivos.Items.Add("Medidor Hospedeiro-NS " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "000000");

            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 1) & 0x01) == 0x01)
            {
                // Medidor 1 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[1].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "010000");
            }

            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 2) & 0x01) == 0x01)
            {
                // Medidor 2 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[2].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "020000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 3) & 0x01) == 0x01)
            {
                // Medidor 3 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[3].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "030000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 4) & 0x01) == 0x01)
            {
                // Medidor 4 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[4].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "040000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 5) & 0x01) == 0x01)
            {
                // Medidor 5 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[5].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "050000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 6) & 0x01) == 0x01)
            {
                // Medidor 6 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[6].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "060000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 7) & 0x01) == 0x01)
            {
                // Medidor 7 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[7].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "070000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 8) & 0x01) == 0x01)
            {
                // Medidor 8 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[8].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "080000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 9) & 0x01) == 0x01)
            {
                // Medidor 9 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[9].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "090000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 10) & 0x01) == 0x01)
            {
                // Medidor 10 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[10].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "100000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 11) & 0x01) == 0x01)
            {
                // Medidor 11 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[11].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "110000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 12) & 0x01) == 0x01)
            {
                // Medidor 12 Mono ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[12].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "120000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 13) & 0x01) == 0x01)
            {
                // Medidor 13 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[13].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "010200");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 14) & 0x01) == 0x01)
            {
                // Medidor 14 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[14].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "020300");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 15) & 0x01) == 0x01)
            {
                // Medidor 15 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[15].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "030400");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 16) & 0x01) == 0x01)
            {
                // Medidor 16 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[16].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "040500");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 17) & 0x01) == 0x01)
            {
                // Medidor 17 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[17].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "050600");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 18) & 0x01) == 0x01)
            {
                // Medidor 18 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[18].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "060700");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 19) & 0x01) == 0x01)
            {
                // Medidor 19 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[19].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "070800");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 20) & 0x01) == 0x01)
            {
                // Medidor 20 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[20].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "080900");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 21) & 0x01) == 0x01)
            {
                // Medidor 21 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[21].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "091000");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 22) & 0x01) == 0x01)
            {
                // Medidor 22 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[22].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "101100");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 23) & 0x01) == 0x01)
            {
                // Medidor 23 Bi ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[23].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "111200");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 24) & 0x01) == 0x01)
            {
                // Medidor 24 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[24].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "010203");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 25) & 0x01) == 0x01)
            {
                // Medidor 25 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[25].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "020304");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 26) & 0x01) == 0x01)
            {
                // Medidor 26 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[26].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "030405");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 27) & 0x01) == 0x01)
            {
                // Medidor 27 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[27].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "040506");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 28) & 0x01) == 0x01)
            {
                // Medidor 28 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[28].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "050607");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 29) & 0x01) == 0x01)
            {
                // Medidor 29 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[29].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "060708");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 30) & 0x01) == 0x01)
            {
                // Medidor 30 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[30].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "070809");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 31) & 0x01) == 0x01)
            {
                // Medidor 31 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[31].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "080910");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 32) & 0x01) == 0x01)
            {
                // Medidor 32 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[32].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "091011");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 33) & 0x01) == 0x01)
            {
                // Medidor 33 Tri ativo
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[33].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "101112");
            }
            if (((clGlobal.ParametrosMedidorHospedeiro.MedAtivo >> 34) & 0x01) == 0x01)
            {
                // Medidor 34 Hex ativo
                //ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[34].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "123456");
                ListaMedidoresAtivos.Items.Add(clGlobal.ParametrosMedidorHospedeiro.MedUC[34].ToString("D" + 9) + " - " + clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8) + "142536");
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// MPROC_PegaMedidor
        /// </summary>
        /// <param name="IndiceMedidor"></param>
        ////////////////////////////////////////////////////////////////////////////
        public static string MPROC_PegaMedidor(Int64 IndiceMedidor)
        {
            string NumeroMedidor = clGlobal.ConfiguracaoMedidorHospedeiroNova.NSABNT.ToString("X" + 8);

            switch (IndiceMedidor)
            {
                case 0:
                    // Medidor Hospedeiro
                    break;
                case 1:
                    // Medidor Monofásico 1
                    NumeroMedidor += "010000";
                    break;
                case 2:
                    // Medidor Monofásico 2
                    NumeroMedidor += "020000";
                    break;
                case 3:
                    // Medidor Monofásico 3
                    NumeroMedidor += "030000";
                    break;
                case 4:
                    // Medidor Monofásico 4
                    NumeroMedidor += "040000";
                    break;
                case 5:
                    // Medidor Monofásico 5
                    NumeroMedidor += "050000";
                    break;
                case 6:
                    // Medidor Monofásico 6
                    NumeroMedidor += "060000";
                    break;
                case 7:
                    // Medidor Monofásico 7
                    NumeroMedidor += "070000";
                    break;
                case 8:
                    // Medidor Monofásico 8
                    NumeroMedidor += "080000";
                    break;
                case 9:
                    // Medidor Monofásico 9
                    NumeroMedidor += "090000";
                    break;
                case 10:
                    // Medidor Monofásico 10
                    NumeroMedidor += "100000";
                    break;
                case 11:
                    // Medidor Monofásico 11
                    NumeroMedidor += "110000";
                    break;
                case 12:
                    // Medidor Monofásico 12
                    NumeroMedidor += "120000";
                    break;
                case 13:
                    // Medidor Bifásico 1
                    NumeroMedidor += "010200";
                    break;
                case 14:
                    // Medidor Bifásico 2
                    NumeroMedidor += "020300";
                    break;
                case 15:
                    // Medidor Bifásico 3
                    NumeroMedidor += "030400";
                    break;
                case 16:
                    // Medidor Bifásico 4
                    NumeroMedidor += "040500";
                    break;
                case 17:
                    // Medidor Bifásico 5
                    NumeroMedidor += "050600";
                    break;
                case 18:
                    // Medidor Bifásico 6
                    NumeroMedidor += "060700";
                    break;
                case 19:
                    // Medidor Bifásico 7
                    NumeroMedidor += "070800";
                    break;
                case 20:
                    // Medidor Bifásico 8
                    NumeroMedidor += "080900";
                    break;
                case 21:
                    // Medidor Bifásico 9
                    NumeroMedidor += "091000";
                    break;
                case 22:
                    // Medidor Bifásico 10
                    NumeroMedidor += "101100";
                    break;
                case 23:
                    // Medidor Bifásico 11
                    NumeroMedidor += "111200";
                    break;
                case 24:
                    // Medidor Trifásico 1
                    NumeroMedidor += "010203";
                    break;
                case 25:
                    // Medidor Trifásico 2
                    NumeroMedidor += "020304";
                    break;
                case 26:
                    // Medidor Trifásico 3
                    NumeroMedidor += "030405";
                    break;
                case 27:
                    // Medidor Trifásico 4
                    NumeroMedidor += "040506";
                    break;
                case 28:
                    // Medidor Trifásico 5
                    NumeroMedidor += "050607";
                    break;
                case 29:
                    // Medidor Trifásico 6
                    NumeroMedidor += "060708";
                    break;
                case 30:
                    // Medidor Trifásico 7
                    NumeroMedidor += "070809";
                    break;
                case 31:
                    // Medidor Trifásico 8
                    NumeroMedidor += "080910";
                    break;
                case 32:
                    // Medidor Trifásico 9
                    NumeroMedidor += "091011";
                    break;
                case 33:
                    // Medidor Trifásico 10
                    NumeroMedidor += "101112";
                    break;
                case 34:
                    // Medidor Hexafásico 1
                    //NumeroMedidor += "123456";
                    NumeroMedidor += "142536";
                    break;
            }
            return NumeroMedidor;
        }

        public static void ExibeMsgErro(clGlobal.ENUM_resComunicaCodi ErroComunicao)
        {
            switch (ErroComunicao)
            {
                case clGlobal.ENUM_resComunicaCodi.resCodiCanalAusente:
                    MessageBox.Show("Canal Ausente.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Canal Ausente", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiComandoNaoImplementado:
                    MessageBox.Show("Comando não implementado.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Comando não Implementado", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiErroComunicacao:
                    MessageBox.Show("Erro de Comunicação.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Erro de Comunicacao", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiErroFaltouDesconectar:
                    MessageBox.Show("Faltou desconectar.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Faltou desconectar", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiErroIrrecuperavel:
                    MessageBox.Show("Erro irrecuperável.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Erro irrecuperável", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiErroParametro:
                    MessageBox.Show("Erro de parâmetro.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Erro de parâmetro", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiFalhaProtocolar:
                    MessageBox.Show("Falha protocolar.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Falha protocolar", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiFimDaMemoria:
                    MessageBox.Show("Fim da memória.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Fim da Memória", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiLinhaRuim:
                    MessageBox.Show("Linha ruim.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Linha ruim", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiMedidorAusente:
                    MessageBox.Show("Medidor ausente.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Medidor ausente", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiMedidorNaoResetaErro:
                    MessageBox.Show("Medidor não reseta.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Medidor não reseta", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiOK:
                    //MessageBox.Show("Resultado OK.", "Aviso");
                    //clGlobal.PROC_ExibeMsgDisplay("Resultado OK", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiOKComRecuperacaoDeErro:
                    MessageBox.Show("OK com recuperação de erro.", "Aviso");
                    //clGlobal.PROC_ExibeMsgDisplay("Ok com recuperação de erro", 1);
                    break;
                case clGlobal.ENUM_resComunicaCodi.resCodiOKComRecuperacaoEFimDeOperacao:
                    MessageBox.Show("Ok com recuperação de erro e fim de operação.", "Erro");
                    //clGlobal.PROC_ExibeMsgDisplay("Ok com recuperação de erro e fim de operação", 1);
                    break;
            }
        }

        public static void AtualizaMsgCaixaTexto(string Mensagem)
        {
            for (int x = 7; x > 2; x--)
            {
                clGlobal.LinhasCaixaTexto[x] = clGlobal.LinhasCaixaTexto[x - 1];
            }
            clGlobal.LinhasCaixaTexto[2] = Mensagem;
        }

        public static void LimparCaixaTexto()
        {
            LinhasCaixaTexto[2] = "";
            LinhasCaixaTexto[3] = "";
            LinhasCaixaTexto[4] = "";
            LinhasCaixaTexto[5] = "";
            LinhasCaixaTexto[6] = "";
            LinhasCaixaTexto[7] = "";
        }

        public static UInt16 Calcula_Crc(byte[] Dados, int index, int NBytes)
        {
            byte Dir, Esq;
            byte crc_l = 0;
            byte crc_h = 0;
            byte byte_zero = 0;
            //byte CrcH = 0;
            //byte CrcL = 0;
            int Ind;

            for (Ind = index; Ind < (NBytes + index); Ind++)
            {
                byte_zero |= Dados[Ind];
                Dir = (byte)(Dados[Ind] ^ crc_l);
                Dir = (byte)(Dir ^ ((Dir & 0x7f) << 1));
                Dir = (byte)(Dir ^ ((Dir & 0x3f) << 2));
                Esq = (byte)(Dir ^ ((Dir & 0xf) << 4));
                Dir = (byte)(((Esq & 3) << 6) | ((Esq & 0xfc) >> 2));
                crc_l = (byte)(crc_h ^ (Dir & 0xc0));
                crc_l = (byte)(crc_l ^ ((Esq & 0x80) >> 7));
                crc_h = (byte)(Esq ^ (Dir & 0x3f));
            }
            if (byte_zero == 0)
                crc_l = 0xff;
            //CrcL = crc_l;
            //CrcH = crc_h;
            Ind = crc_h * 256 + crc_l;
            return (UInt16)Ind;
        }
        public static string Formata_Valor(double valor)
        {
            string stipo = " ";
            if (Math.Abs(valor) > 1000000000)
            {
                valor /= 1000000000;
                stipo = " G";
            }
            else
            {
                if (Math.Abs(valor) > 1000000)
                {
                    valor /= 1000000;
                    stipo = " M";
                }
                else
                {
                    if (Math.Abs(valor) > 1000)
                    {
                        valor /= 1000;
                        stipo = " K";
                    }
                }
            }
            if (Math.Abs(valor) < 10)
            {
                return valor.ToString("0.000") + stipo;
            }
            else
            {
                if (Math.Abs(valor) < 100)
                {
                    return valor.ToString("0.00") + stipo;
                }
                else
                {
                    return valor.ToString("0.0") + stipo;
                }
            }
        }

        public static string Obtem_NroTrafo()
        {
            string strAux = "";
            for (int x = 0; x < 14; x++)
            {   // Converte em String
                strAux += ((char)ParametrosEasy.NumeroTrafo[x]).ToString();
            }
            strAux = strAux.TrimStart();
            strAux = strAux.TrimEnd();
            return strAux;  // Retorna a String sem os Espaços do Início e do Final...
        }

        public static void Seta_NroTrafo(string nrotrafo)
        {
            if (nrotrafo.Length >= 14)
            {   // Limita em 14 Caracteres
                nrotrafo = nrotrafo.Substring(0, 14);
            }
            else
            {   // Tenta Colocar 2 Espaços no Início
                nrotrafo = "  " + nrotrafo;    
                if (nrotrafo.Length >= 14)
                {   // Pega os 14 Caracteres finais
                    nrotrafo = nrotrafo.Substring(14 - nrotrafo.Length, 14);
                }
                else
                {   // Coloca Espços no Final
                    nrotrafo += "              ";
                    nrotrafo = nrotrafo.Substring(0, 14);
                }
            }
            for (int x = 0; x < nrotrafo.Length; x++)
            {   // Pega os Caracteres...
                ParametrosEasy.NumeroTrafo[x] = (byte)(Char.Parse(nrotrafo.Substring(x, 1)));
            }
        }

        public static void TrataErroCmd(object sender, EventArgs e)
        {       
            switch (clGlobal.CodigoErro)
            {
                case 0x30:
                    // Bateria com defeito
                    break;
                case 0x31:
                    // Erro na integridade do programa
                    break;
                case 0x33:
                    // Relogio com defeito
                    break;
                case 0x36:
                    // Senha inválida
                    break;
                case 0x37:
                    // Watchdog
                    break;
                case 0x45:
                    // Fechamento de fatura no momento de proteção
                    break;
                case 0x46:
                    // Alteração com parâmetro inválido
                    break;
                case 0xAB:
                    // Ocorrências Especificas no Absoluto
                    break;
            }
        }

        public static void BlocoMMLidoInit()
        {
            Bloco_MM_Lido = 0;
            Bloco_MM_Lido_Anterior = 0;
            Bloco_MM_Lido_Aux = 0;
            IndiceIntervaloMMLido = 0;
        }

        public static UInt32 BlocoMMLidoBcd2Int()
        {
            //Converte o valor da variável Bloco_MM_Lido para inteiro
            return (UInt32)((UInt32)(Bloco_MM_Lido & 0x000F) + ((UInt32)((Bloco_MM_Lido & 0x00F0) >> 4) * 10) + ((UInt32)((Bloco_MM_Lido & 0x0F00) >> 8) * 100) + Bloco_MM_Lido_Aux);
        }
    }
}