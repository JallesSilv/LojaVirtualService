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
    public class MItensPedidos : XMigrationBanco
    {

        public static void ItensPedidos()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("ItensPedidos", "ChaveItensPedido"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `ItensPedidos` (
                                              `ChaveItensPedido` BIGINT NOT NULL AUTO_INCREMENT,
                                              `ChavePedido` BIGINT NOT NULL,
                                              `ChaveProduto` BIGINT NOT NULL,
                                              `Nome` varchar(300) DEFAULT NULL,  
                                              `Quatidade` BIGINT NULL,
                                            PRIMARY KEY (`ChaveItensPedido`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela ItensPedidos.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Itenspedidos: {error.Message}");
                    }
                }
            }
        }
    }
}
