using Repositorio.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public static class VerificarExisteTabela
    {
        public static bool ExisteColunaNaTabela(string pTable, string pColumn)
        {
            int resultado = 0;
            using (var cmd = FactoryConnection.NewCommand())
            {
                var strQuery = $@"SELECT Count(*)
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = '{pTable}'
                                    AND COLUMN_NAME = '{pColumn}'";
                try
                {
                    cmd.CommandText = strQuery;
                    resultado = cmd.ExecuteScalar().AsInt32();
                }
                catch (Exception error)
                {
                    throw new Exception($"Erro ao validar existencia da coluna: \n{pColumn} da tabela {pTable}\n{error.Message}");
                }
                finally
                {
                    cmd.Prepare();
                }
            }
            return resultado > 0;
        }
    }
}
