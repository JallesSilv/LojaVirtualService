using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Config
{
    public static class XFormatacao
    {
        public static string AsFormatCnpjCpf(string pValor)
        {
            if (pValor is null) return string.Empty;
            if (pValor.Length == 11)
                return Convert.ToInt64(pValor).ToString(@"000\.000\.000\-00"); // CPF
            else
                return Convert.ToInt64(pValor).ToString(@"00\.000\.000\/0000\-00"); //CNPJ
        }
    }
}
