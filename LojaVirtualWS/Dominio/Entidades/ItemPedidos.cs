using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("itenspedidos")]
    public class ItemPedidos
    {
        [Key]
        public Int64 ChaveItensPedido { get; set; }

        [ForeignKey("Pedidos")]
        public Int64 ChavePedido { get; set; }
        public virtual Pedidos Pedidos { get; set; }

        [ForeignKey("Produtos")]
        public Int64 ChaveProduto { get; set; }
        public virtual Produtos Produtos { get; set; }

        public Int64 Quantidade { get; set; }      
    }
}
