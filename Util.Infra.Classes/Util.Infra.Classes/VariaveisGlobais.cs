using System;
using System.Configuration;

namespace Linx.NFCE.Services.Util.Util
{
    public static class VariaveisGlobais
    {
        /// <summary>
        /// Global variable that is constant.
        /// </summary>
        public static string GlobalString = AppDomain.CurrentDomain.FriendlyName;

        /// <summary>
        /// Static value protected by access routine.
        /// </summary>
        static int _globalValue;

        /// <summary>
        /// Access routine for global variable.
        /// </summary>
        public static int GlobalValue
        {
            get
            {
                return _globalValue;
            }
            set
            {
                _globalValue = value;
            }
        }

        /// <summary>
        /// Global static field.
        /// </summary>
        public static bool GlobalBoolean;
    }
}
