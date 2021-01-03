using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Caixa")]
    public partial class Caixa
    {

        [Key]
        public Int64 ChaveCaixa { get; set; }
        [ForeignKey("Banco")]
        public Int64 ChaveBanco { get; set; }
        public string NomeCaixa { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool AtualizarBanco { get; set; }
        public double Saldo { get; set; }
        public bool Ativo { get; set; }

        public virtual Banco Banco { get; set; }
    }
}
    