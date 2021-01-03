using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MCategoriaProduto:XMigrationBanco
    {
        public static void CategoriaProduto()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("CategoriaProduto", "ChaveCategoriaProduto"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `CategoriaProduto` (
                                              `ChaveCategoriaProduto` BIGINT NOT NULL AUTO_INCREMENT,
                                              `Nome` varchar(300) DEFAULT NULL,  
                                              `Descricao` varchar(300) DEFAULT NULL,
                                            PRIMARY KEY (`ChaveCategoriaProduto`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela CategoriaProduto.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela CategoriaProduto: {error.Message}");
                    }
                }
            }
        }
    }
}
