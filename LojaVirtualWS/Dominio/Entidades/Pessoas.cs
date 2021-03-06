﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Pessoas")]
    public partial class Pessoas
    {

        [Key]
        public Int64 ChavePessoa { get; set; }
        [ForeignKey("ControleAcesso")]
        public Int64 ChaveControleAcesso { get; set; }
        public virtual ControleAcesso ControleAcesso { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Senha { get; set; }        
        public string CnpjCpf { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }
        [StringLength(300)]
        public string Endereco { get; set; }
        [StringLength(1000)]
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
    }
}
