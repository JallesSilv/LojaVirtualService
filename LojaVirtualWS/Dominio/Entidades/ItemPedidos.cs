using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("itenspedidos")]
    public class ItemPedidos
    {
        [Key]
        public int ChaveItensPedido { get; set; }

        [ForeignKey("Pedidos")]
        public int ChavePedido { get; set; }
        public virtual Pedidos Pedidos { get; set; }

        [ForeignKey("Produtos")]
        public int ChaveProduto { get; set; }
        public virtual Produtos Produtos { get; set; }

        public int Quantidade { get; set; }      
    }
}
