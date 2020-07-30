using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entidades
{
    [Table("Pessoas")]
    public class Pessoas : Entidade
    {
        //public Pessoa()
        //{
        //    Pedidos = new HashSet<Pedido>();
        //}

        [Key]
        public int ChavePessoa { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Senha { get; set; }
        public string CpnjCpf { get; set; }
        public string Telefone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }
        [StringLength(300)]
        public string Endereco { get; set; }
        [StringLength(1000)]
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Pedidos> Pedido { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
