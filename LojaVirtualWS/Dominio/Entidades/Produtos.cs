using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        public Int64 ChaveProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public byte NomeImagem{ get; set; }
    }
}
