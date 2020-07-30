using Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Pedidos")]
    public class Pedidos : Entidade
    {
        [Key]
        public int ChavePedido { get; set; }

        [ForeignKey("Pessoas")]
        public int ChavePessoa { get; set; }
        //public Pessoas Pessoas { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPedido { get; set; }
        public int Orcamento { get; set; }
        public bool LancamentoCaixa { get; set; }
        public string Descricao { get; set; }
        public int Quatidade { get; set; }
        public string TipoPagamento { get; set; }
        public int Parcela { get; set; }
        public double Preco { get; set; }
        public double PrecoTotal { get; set; }

        public int ChaveFormaPagamento { get; set; }
        public FormaPagamento FormaPagamento { get; set; } 

        public ICollection<ItemPedidos>  ItemPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();
            if (!ItemPedidos.Any())
                AdicionarCritica("Atenção: Nem um item foi selecionado!!!");
        }
        //public ICollection<Funcionario> ListFuncionario { get; set; }
    }
}
