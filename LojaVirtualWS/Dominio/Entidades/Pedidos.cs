﻿using Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Pedidos")]
    public partial class Pedidos
    {
        [Key]
        public Int64 ChavePedido { get; set; }

        [ForeignKey("Pessoas")]
        public Int64 ChavePessoa { get; set; }
        public virtual Pessoas Pessoas { get; set; }

        [ForeignKey("FormaPagamento")]
        public Int64 ChaveFormaPagamento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPedido { get; set; }
        public Int64 Orcamento { get; set; }
        public bool LancamentoCaixa { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public Int64 Quatidade { get; set; }
        public Int64 Parcela { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal ValorAntecipado { get; set; }

    }
}
