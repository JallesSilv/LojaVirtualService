using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Config
{
    public static class XExtension
    {
        public static string AsString(this object pValor)
        {
            if (pValor is null) return string.Empty;
            return Convert.ToString(pValor);
        }

        public static bool EstaVazio(this string pValor)
        {
            return string.IsNullOrEmpty(pValor);
        }

        public static bool AsBool(this string pValor)
        {
            return Convert.ToBoolean(pValor);
        }

        public static int AsInt64(this object pValor)
        {
            return Convert.ToInt32(pValor);
        }
    }
}
