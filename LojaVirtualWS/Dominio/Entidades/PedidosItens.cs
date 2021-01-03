using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("pedidosItens")]
    public class PedidosItens
    {
        [Key]
        public Int64 ChavePedidoItem { get; set; }

        [ForeignKey("Pedidos")]
        public Int64 ChavePedido { get; set; }
        public virtual Pedidos Pedidos { get; set; }

        [ForeignKey("Produtos")]
        public Int64 ChaveProduto { get; set; }
        public virtual Produtos Produtos { get; set; }

        public Int64 Quantidade { get; set; }      
    }
}
