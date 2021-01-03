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
    public class MProdutos : XMigrationBanco
    {

        public static void Produtos()
        {
            CriarTabelaSql();
        }
        
        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Produtos", "ChaveProduto"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `Produtos` (
                                              `ChaveProduto` BIGINT NOT NULL AUTO_INCREMENT,
                                              `Nome` varchar(300) DEFAULT NULL,  
                                              `Descricao` varchar(300) DEFAULT NULL,
                                              `NomeImagem` varchar(300) DEFAULT NULL,
                                              `Preco` DECIMAL(12,2) DEFAULT NULL,
                                            PRIMARY KEY (`ChaveProduto`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela Produtos.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Produtos: {error.Message}");
                    }
                }
            }            
        }
    }
}
