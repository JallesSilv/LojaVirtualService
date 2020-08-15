using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades
{
    public abstract class Entidade
    {
        public List<string> _mensagensValidacao { get; set; }
        private List<string> MensagensValidacao 
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
        }

        public void LimparMensagensValidacao()
        {
            MensagensValidacao.Clear();
        }

        public void AdicionarCritica(string mensagens)
        {
            MensagensValidacao.Add(mensagens);
        }

        public string ObterMensagensValidacao()
        {
            return string.Join(". ", MensagensValidacao);
        }

        public abstract void Validate();
        protected bool EhValido
        {
            get { return !MensagensValidacao.Any(); }
        }
    }
}
