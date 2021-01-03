using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Banco")]
    public partial class Banco
    {

        [Key]
        public Int64 ChaveBanco { get; set; }
        public string NomeBanco { get; set; }
        public Int64 NumeroConta { get; set; }
        public Int64 Agencia { get; set; }
        public DateTime DataCadastro { get; set; }
        public double Saldo { get; set; }
        public bool Ativo { get; set; }

    }
}
