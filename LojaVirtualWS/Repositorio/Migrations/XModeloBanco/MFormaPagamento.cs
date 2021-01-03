using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MFormaPagamento : XMigrationBanco
    {
        public static void FormaPagamento()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("FormaPagamento", "ChaveFormaPagamento"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `FormaPagamento` (
                                            `ChaveFormaPagamento` BIGINT NOT NULL AUTO_INCREMENT,
                                            `Tipo` varchar(200) DEFAULT NULL,
                                            `Categoria` varchar(100) DEFAULT NULL,
                                            `Descricao` varchar(100) DEFAULT NULL,
                                            `Ativo` BOOLEAN DEFAULT NULL,
                                            PRIMARY KEY (`ChaveFormaPagamento`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela FormaPagamento.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela FormaPagamento: {error.Message}");
                    }
                }
            }            
        }
    }
}
