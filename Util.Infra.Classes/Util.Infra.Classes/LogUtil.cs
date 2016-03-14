using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.NFCE.Services.Util.Util
{
    /// <summary>
    /// Classe estática com métodos responsáveis por gerar os arquivos de Log para auditoria.
    /// </summary>
    #region LogUtil
    public static class LogUtil
    {
        /// <summary>
        /// Método para gravar um log no formato .txt no diretório da aplicação.
        /// </summary>
        /// <param name="mensagem">Mensagem de erro que será gravada através do método em um arquivo .txt. </param>
        #region GravarLogErro
        public static void GravarLogErro(string metodoErro, string mensagem)
        {
            metodoErro += "Erro no método: " + metodoErro +". ";
            mensagem += "Mensagem de erro: " + mensagem;
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now + ": " + metodoErro + mensagem);
                sw.Flush();
                sw.Close();

            }
            catch (Exception ex)
            {

                //GravarLogErro(ex.Message.ToString());
                GravarlogEventosWindows(VariaveisGlobais.GlobalString, metodoErro,ex.Message.ToString());
            }

        }
        #endregion

        /// <summary>
        /// Método para a geração e gravação de eventos de aplicativos no registro de eventos do Windows.
        /// </summary>
        /// <param name="fonteAplicativo">Nome do aplicativo exibido no Visualizados de Eventos do Windows.</param>
        /// <param name="mensagemErro">Mensagem de erro do Evento exibido no Visualizados de Eventos do Windows.</param>

        #region GravarlogEventosWindows
        public static void GravarlogEventosWindows(string fonteAplicativo,string metodoErro, string mensagemErro, int eventType = 0, string mensagemInfo = null)
        {
            metodoErro += "Erro no método: " + metodoErro + ". ";
            mensagemErro += "Mensagem de erro: " + mensagemErro;
            string sLog;
            sLog = "Application";
            try
            {
                if (!EventLog.SourceExists(fonteAplicativo))
                    EventLog.CreateEventSource(fonteAplicativo, sLog);

                //EventLog.WriteEntry(fonteAplicativo, mensagem);
                if (eventType == 0)
                {
                    EventLog.WriteEntry(fonteAplicativo, metodoErro + mensagemErro, EventLogEntryType.Warning, 234);
                }
                else
                {
                    EventLog.WriteEntry(fonteAplicativo, mensagemInfo, EventLogEntryType.Information, 234);
                }


            }
            catch (ConfigurationErrorsException ex)
            {

                GravarLogErro(metodoErro,ex.Message.ToString());
                //GravarlogEventosWindows(VariaveisGlobais.GlobalString, ex.Message.ToString());
            }

           
        }
        #endregion

    }
    #endregion
}
