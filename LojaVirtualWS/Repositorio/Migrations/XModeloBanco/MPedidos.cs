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
    public class MPedidos : XMigrationBanco
    {

        public static void Pedidos()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("Pedidos", "ChavePedido"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `Pedidos` (
                                            `ChavePedido` BIGINT NOT NULL AUTO_INCREMENT,
                                            `ChavePessoa` BIGINT DEFAULT NULL,
                                            `ChaveFormaPagamento` BIGINT DEFAULT NULL,
                                            `DataPedido` datetime NOT NULL,
                                            `Orcamento` BIGINT DEFAULT NULL,
                                            `LancamentoCaixa` bit(1) NOT NULL,
                                            `Status` varchar(300) COLLATE utf8_bin DEFAULT NULL,
                                            `Descricao` varchar(300) COLLATE utf8_bin DEFAULT NULL,
                                            `Quatidade` BIGINT DEFAULT NULL,
                                            `PrecoTotal` DECIMAL(12,2) DEFAULT NULL,
                                            `Parcela` BiGINT DEFAULT NULL,
                                            `ValorAntecipado` DECIMAL(12,2) DEFAULT NULL,
                                            PRIMARY KEY (`ChavePedido`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela Pedidos.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela Pedidos: {error.Message}");
                    }
                }
            }
        }
    }
}
