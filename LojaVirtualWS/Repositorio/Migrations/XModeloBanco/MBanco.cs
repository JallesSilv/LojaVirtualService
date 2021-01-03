using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MBanco:XMigrationBanco
    {
        public static void Banco()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Banco", "ChaveBanco"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `Banco` (
                                              `ChaveBanco` BIGINT NOT NULL AUTO_INCREMENT,
                                              `NomeBanco` varchar(300) DEFAULT NULL,
                                              `NumeroConta` BIGINT NULL,
                                              `Agencia` BIGINT NULL,
                                              `DataCadastro` datetime NOT NULL,
                                              `Saldo` double DEFAULT NULL,
                                              `Descricao` varchar(300) DEFAULT NULL,
                                              `Ativo` BOOLEAN DEFAULT NULL, 
                                            PRIMARY KEY (`ChaveBanco`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela Banco.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Banco: {error.Message}");
                    }
                }
            }
        }
    }
}
