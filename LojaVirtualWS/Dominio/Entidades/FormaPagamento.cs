using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("FormaPagamento")]
    public partial class FormaPagamento
    {
        [Key]
        public Int64 ChaveFormaPagamento { get; set; }
        public string Tipo { get; set; }    
        public string Categoria { get; set; }    
        public string Descricao { get; set; }    
        public bool Ativo { get; set; }    
        
    }
}
