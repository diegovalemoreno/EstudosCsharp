using System;
using Microsoft.Win32;
using Linx.NFCE.Services.Util.Util;
using System.Security.Principal;

namespace Linx.NFCE.Services.Util.Persistence
{
    /// <summary>
    /// Classe com métodos para manipular registros do Windows - (REGEDIT).
    /// </summary>

    #region RegistryUtil
    public class RegistryUtil
    {
        /// <summary>
        /// Efetua a leitura de uma chave no registro do Windows (A partir da Sub Chave Software\Linx Sistemas\LinxPOS)
        /// </summary>
        /// <param name="chave">Recebe a chave que será lida no REGISTRY (A partir da Sub Chave Software\Linx Sistemas\LinxPOS)</param>
        /// <returns></returns>
        #region LerRegistro

        public string LerRegistro(string chave)
        {
            try
            {
                NTAccount ntuser = new NTAccount(WindowsIdentity.GetCurrent().Name.ToString());
                SecurityIdentifier sID = (SecurityIdentifier)ntuser.Translate(typeof(SecurityIdentifier));
                string strSID = sID.ToString();
                const string subkey = @"\Software\Linx Sistemas\LinxPOS\";
                string AtualKey = strSID + subkey;
                using (RegistryKey key = Registry.Users.OpenSubKey(AtualKey))
                {
                    chave = (string)key.GetValue(chave) ?? "";
                }
                return chave.ToString();
            }
            catch (Exception ex)
            {
                LogUtil.GravarLogErro("LerRegistro: LerRegistro", ex.Message.ToString());
                LogUtil.GravarlogEventosWindows(VariaveisGlobais.GlobalString, "LerRegistro: LerRegistro", ex.Message.ToString());
            }
            if (String.IsNullOrWhiteSpace(chave))
            {
                return null;
            }
           
            return chave.ToString();
        }
        #endregion

       

        #region CriarChaveRegistro 

        public void CriarChaveRegistro()
        {
            try
            {
                const string subkey = @"Software\Linx Sistemas\LinxPOS\";
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey))
                {
                    key.SetValue("Servico Frequencia Processamento Minutos", "15");
                    key.SetValue("Servico Pendencias Periodo Dias", "3");
                }
            }
            catch (Exception ex)
            {
                LogUtil.GravarLogErro("RegistryUtil: CriarChaveRegistro", ex.Message.ToString());
                LogUtil.GravarlogEventosWindows(VariaveisGlobais.GlobalString, "RegistryUtil: CriarChaveRegistro", ex.Message.ToString());
            }
            
        }
        #endregion
    }
    #endregion
}

