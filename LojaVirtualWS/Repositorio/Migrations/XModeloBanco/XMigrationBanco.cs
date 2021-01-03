using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.XModeloBanco
{
    public class XMigrationBanco
    {
        public static void ExecutarBanco()
        {
            MVersao_Migration.Versao_Migration();
            MPessoas.Pessoas();
            MProdutos.Produtos();
            MPedidos.Pedidos();
            MPedidosItens.PedidosItens();
            MFormaPagamento.FormaPagamento();
            MCategoriaProduto.CategoriaProduto();
            MCaixaMovimentacao.CaixaMovimentacao();
            MBanco.Banco();
            MFileToUpload.FileToUpload();
            MCaixa.Caixa();
            MControleAcesso.ControleAcesso();
        }
    }
}
