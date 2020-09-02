using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Versao_Migration")]
    public class Versao_Migration
    {
        [Key]
        public Int64 ChaveVersao { get; set; }
        public DateTime Data { get; set; }
        public int Versao { get; set; }
    }
}
