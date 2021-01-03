using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("NivelAcesso")]
    public partial class NivelAcesso
    {
        [Key]
        public Int64 ChaveNivelAcesso { get; set; }
        public bool CadastrarPessoas { get; set; }
        //public bool  { get; set; }
    }
}
