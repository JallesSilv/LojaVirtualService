using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class ItemPedidos : Entidade
    {
        public int ChaveItemPedido { get; set; }
        public int ChaveProduto { get; set; }
        public int Quantidade { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
