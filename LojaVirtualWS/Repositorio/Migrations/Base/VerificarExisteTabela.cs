using Repositorio.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.Base
{
    public static class VerificarExisteTabela
    {
        public static bool ExisteColunaNaTabela(string pTable, string pColumn)
        {
            int resultado = 0;
            using (var cmd = FactoryConnection.NewCommand())
            {
                string pBanco = XConfig.DataSouce;
                var strQuery = $@"SELECT Count(*)
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME = '{pTable}'
                                    AND TABLE_SCHEMA = '{pBanco}'
                                    AND COLUMN_NAME = '{pColumn}'";
                try
                {
                    cmd.CommandText = strQuery;
                    resultado = cmd.ExecuteScalar().AsInt64();
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

        public static bool ExisteRegistro(string pTabela, string pColumn, string pValor)
        {
            using (var cmd = FactoryConnection.NewCommand())
            {
                string resultado = "";
                var strQuery = $@"SELECT {pColumn} FROM {pTabela} WHERE {pColumn} = '{pValor}'";
                try
                {
                    cmd.CommandText = strQuery;
                    resultado = cmd.ExecuteScalar().AsString();
                }
                catch (Exception eX)
                {

                    throw new Exception($"Erro ao verficar existencia do registro:\n{pValor} da tabela {pTabela}\n{eX.Message}");
                }
                finally
                {
                    cmd.Dispose();
                }
                return resultado == pValor;
            }
        }
    }
}
