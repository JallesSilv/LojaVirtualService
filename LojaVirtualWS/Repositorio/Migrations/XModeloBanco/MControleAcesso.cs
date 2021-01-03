using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MControleAcesso : XMigrationBanco
    {

        public static void ControleAcesso()
        {
            CriarTabelaSql();
            InsertSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("ControleAcesso", "ChaveControleAcesso"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `ControleAcesso` (
                                              `ChaveControleAcesso` BIGINT NOT NULL AUTO_INCREMENT,
                                              `ChaveNivelAcesso` BIGINT DEFAULT NULL,
                                              `Descricao` varchar(50) COLLATE utf8_bin DEFAULT NULL,
                                            PRIMARY KEY (`ChaveControleAcesso`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela ControleAcesso.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela ControleAcesso: {error.Message}");
                    }
                }
            }
        }

        private static void InsertSql()
        {
            if (!VerificarExisteTabela.ExisteRegistro("ControleAcesso", "ChaveControleAcesso", "3"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"INSERT INTO `lojavirtual`.`ControleAcesso` (`ChaveControleAcesso`, `ChaveNivelAcesso`, `Descricao`) VALUES(1, 1, 'Administrador');
                                            INSERT INTO `lojavirtual`.`ControleAcesso` (`ChaveControleAcesso`, `ChaveNivelAcesso`, `Descricao`) VALUES(2, 2, 'Funcionario');
                                            INSERT INTO `lojavirtual`.`ControleAcesso` (`ChaveControleAcesso`, `ChaveNivelAcesso`, `Descricao`) VALUES(3, 3, 'Cliente');
                                        ";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Insert ControleAcesso.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Insert ControleAcesso: {error.Message}");
                    }
                }
            }
        }
    }
}


