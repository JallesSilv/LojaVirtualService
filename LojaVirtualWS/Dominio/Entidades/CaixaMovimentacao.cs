using Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("CaixaMovimentacao")]
    public partial class CaixaMovimentacao
    {

        [Key]
        public Int64 ChaveCaixaMovimentacao { get; set; }
        [ForeignKey("Caixa")]
        public Int64 ChaveCaixa { get; set; }
        public virtual Caixa Caixa { get; set; }
        [ForeignKey("Pessoas")]
        public Int64? ChavePessoa { get; set; }
        public virtual Pessoas Pessoas { get; set; }
        [ForeignKey("Pedidos")]
        public Int64? ChavePedido { get; set; }
        public virtual Pedidos Pedidos { get; set; }
        [ForeignKey("FileToUpload")]
        public Int64? ChaveFile { get; set; }
        public virtual FileToUpload FileToUpload { get; set; }
        [ForeignKey("FormaPagamento")]
        public Int64? ChaveFormaPagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataPago { get; set; }
        public DateTime? DataEstorno { get; set; }
        public Int64? TipoLancamento { get; set; }
        public bool FecharCaixaAutomatico { get; set; }
        public decimal? Valor { get; set; }
        public decimal? ValorAntecipado { get; set; }
        public bool Ativo { get; set; }

        public bool EhTipoReceita
        {
            get { return TipoLancamento == (Int64)TipoDeLancamento.Receitas; }
        }

        public bool EhTipoDespesas
        {
            get
            {
                return TipoLancamento == (Int64)TipoDeLancamento.Despesas;
            }
        }
    }


}
