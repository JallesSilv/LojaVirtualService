using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("FormaPagamento")]
    public class FormaPagamento
    {
        [Key]
        public Int64 ChaveFormaPagamento { get; set; }
        public string Descricao { get; set; }        
    }
}
