using Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.ObjetoDeValor
{
    [Table("FormaPagamento")]
    public class FormaPagamento
    {
        [Key]
        public int ChaveFormaPagamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool EhBoleto
        {
            get
            {
                return ChaveFormaPagamento == (int)TipoFormaPagamentoEnum.Boleto;
            }
        }
        public bool EhCartaoCredito
        {
            get
            {
                return ChaveFormaPagamento == (int)TipoFormaPagamentoEnum.CartaoCredito;
            }
        }
        
        public bool EhPromissora
        {
            get
            {
                return ChaveFormaPagamento == (int)TipoFormaPagamentoEnum.Promissora;
            }
        }
        
        public bool EhNaoDefinido
        {
            get
            {
                return ChaveFormaPagamento == (int)TipoFormaPagamentoEnum.NaoDefinido;
            }
        }
    }
}
