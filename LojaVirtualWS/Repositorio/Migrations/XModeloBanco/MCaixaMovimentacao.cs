using Repositorio.Config;
using Repositorio.Migrations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class MCaixaMovimentacao : XMigrationBanco
    {
        public static void CaixaMovimentacao()
        {
            CriarTabelaSql();
        }

        private static void CriarTabelaSql()
        {
            if (!VerificarExisteTabela.ExisteColunaNaTabela("CaixaMovimentacao", "ChaveCaixaMovimentacao"))
            {
                using (var cmd = FactoryConnection.NewCommand())
                {
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE `CaixaMovimentacao` (
                                                `ChaveCaixaMovimentacao` BIGINT NOT NULL AUTO_INCREMENT,
                                                `ChaveCaixa` BIGINT DEFAULT NULL,
                                                `ChavePessoa` BIGINT DEFAULT NULL,
                                                `ChavePedido` BIGINT DEFAULT NULL,
                                                `ChaveFile` BIGINT DEFAULT NULL,
                                                `ChaveFormaPagamento` BIGINT DEFAULT NULL,
                                                `Descricao` varchar(300) COLLATE utf8_bin DEFAULT NULL,
                                                `DataCadastro` datetime NULL,
                                                `DataPago` datetime NULL,
                                                `DataEstorno` datetime NULL,
                                                `TipoLancamento` BIGINT DEFAULT NULL,
                                                `FecharCaixaAutomatico` BOOLEAN DEFAULT NULL,     
                                                `Valor` DECIMAL(10,2) DEFAULT NULL,
                                                `ValorAntecipado` DECIMAL(10,2) DEFAULT NULL,
                                                `Ativo` BOOLEAN DEFAULT NULL,
                                                PRIMARY KEY (`ChaveCaixaMovimentacao`))";
                        cmd.ExecuteNonQuery();
                        XLog.RegistraLog($"Tabela CaixaMovimentacao.", "ModeloBanco");
                    }
                    catch (Exception error)
                    {
                        throw new Exception($"Error Tabela CaixaMovimentacao: {error.Message}");
                    }
                }
            }

        }
    }
}
