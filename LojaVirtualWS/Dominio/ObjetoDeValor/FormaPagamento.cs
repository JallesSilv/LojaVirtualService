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
        public int TipoFormaPagamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool EhBoleto
        {
            get
            {
                return TipoFormaPagamento == (int)TipoFormaPagamentoEnum.Boleto;
            }
        }
        public bool EhCartaoCredito
        {
            get
            {
                return TipoFormaPagamento == (int)TipoFormaPagamentoEnum.CartaoCredito;
            }
        }
        
        public bool EhPromissora
        {
            get
            {
                return TipoFormaPagamento == (int)TipoFormaPagamentoEnum.Promissora;
            }
        }
        
        public bool EhNaoDefinido
        {
            get
            {
                return TipoFormaPagamento == (int)TipoFormaPagamentoEnum.NaoDefinido;
            }
        }
    }
}
