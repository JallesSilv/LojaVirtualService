using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("ControleAcesso")]
    public partial class ControleAcesso
    {
        [Key]
        public Int64 ChaveControleAcesso { get; set; }
        //[ForeignKey("NivelAcesso")]
        public Int64 ChaveNivelAcesso { get; set; }
        //public virtual NivelAcesso NivelAcesso { get; set; }
        public string Descricao { get; set; }
    }
}
