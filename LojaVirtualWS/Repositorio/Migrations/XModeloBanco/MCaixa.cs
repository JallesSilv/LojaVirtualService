using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MCaixa:XMigrationBanco
    {
        public static void Caixa()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Caixa", "ChaveCaixa"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `Caixa` (
                                              `ChaveCaixa` BIGINT NOT NULL AUTO_INCREMENT,
                                              `ChaveBanco` BIGINT NOT NULL,
                                              `NomeCaixa` varchar(300) DEFAULT NULL,
                                              `DataCadastro` datetime NOT NULL,
                                              `Saldo` double DEFAULT NULL,
                                              `AtualizarBanco` BOOLEAN DEFAULT NULL, 
                                              `Ativo` BOOLEAN DEFAULT NULL, 
                                            PRIMARY KEY (`ChaveCaixa`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela Caixa.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Caixa: {error.Message}");
                    }
                }
            }
        }
    }
}
