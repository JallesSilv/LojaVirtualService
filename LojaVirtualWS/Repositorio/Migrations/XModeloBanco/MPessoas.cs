using Dominio.Entidades;
using Repositorio.Config;
using Repositorio.Contexto;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MPessoas : XMigrationBanco
    {

        public static void Pessoas()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Pessoas", "ChavePessoa"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `Pessoas` (
                                              `ChavePessoa` BIGINT NOT NULL AUTO_INCREMENT,
                                              `ChaveControleAcesso` BIGINT DEFAULT NULL,
                                              `Nome` varchar(100) DEFAULT NULL,
                                              `Email` varchar(100) DEFAULT NULL,
                                              `Senha` varchar(100) DEFAULT NULL,
                                              `CnpjCpf` varchar(14) DEFAULT NULL,                                              
                                              `Telefone` varchar(20) DEFAULT NULL,
                                              `DataCadastro` datetime NOT NULL,
                                              `Cep` varchar(8) DEFAULT NULL,
                                              `Endereco` varchar(500) DEFAULT NULL,
                                              `Observacoes` varchar(1000) DEFAULT NULL,
                                              `Ativo` BOOLEAN DEFAULT NULL,
                                            PRIMARY KEY (`ChavePessoa`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela Pessoas.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Pessoas: {error.Message}");
                    }
                }
            }            
        }
    }
}
