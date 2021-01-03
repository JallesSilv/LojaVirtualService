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
    public class MPedidosItens : XMigrationBanco
    {

        public static void PedidosItens()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("PedidosItens", "ChavePedidoItem"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `PedidosItens` (
                                              `ChavePedidoItem` BIGINT NOT NULL AUTO_INCREMENT,
                                              `ChavePedido` BIGINT NOT NULL,
                                              `ChaveProduto` BIGINT DEFAULT NULL,
                                              `Nome` varchar(300) DEFAULT NULL,  
                                              `Quatidade` BIGINT NULL,
                                            PRIMARY KEY (`ChavePedidoItem`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela PedidosItens.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela PedidosItens: {error.Message}");
                    }
                }
            }
        }
    }
}
