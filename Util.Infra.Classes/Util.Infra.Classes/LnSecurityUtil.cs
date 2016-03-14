using System;
using LnSecurityLib;
using Linx.NFCE.Services.Util.Util;

namespace Linx.NFCE.Services.Util.Persistence
{
    /// <summary>
    /// Classe com métodos da LnSecurity.dll.
    /// </summary>

    #region LnSecurityUtil
    public class LnSecurityUtil
    {
        /// <summary>
        /// Propriedade interna da classe para instanciar a classe StringBufferClass.
        /// </summary>
        private StringBufferClass _StringBuffer = new StringBufferClass();

        /// <summary>
        /// Efetua a leitura de uma string criptografada através da LnSecurity.dll
        /// </summary>
        /// <param name="stringNome">string criptografada para realizar a descriptografia utilizado a LnSecurity.dll.</param>
        /// <returns></returns>
        #region MyRegion
        public string LerBuffer(string stringNome)
        {

            try
            {
                string bufferKey = _StringBuffer.BuildBuffer();
                string valor = _StringBuffer.LoadBuffer(bufferKey, stringNome).Trim();
                return valor.ToString();
            }
            catch (Exception ex)
            {
                LogUtil.GravarLogErro("LnSecurityUtil: LerBuffer", ex.Message.ToString());
                LogUtil.GravarlogEventosWindows(VariaveisGlobais.GlobalString, "LnSecurityUtil: LerBuffer", ex.Message.ToString());
                return null;
            }

        }
        #endregion
    }
    #endregion
}
