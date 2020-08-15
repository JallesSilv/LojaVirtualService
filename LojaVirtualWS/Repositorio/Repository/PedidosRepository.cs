using Dominio.Contratos;
using Dominio.Entidades;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class PedidosRepository : BaseRepository<Pedidos>, IPedidosRepository
    {
        public PedidosRepository(LojaVirtualDbContext contexto) : base(contexto)
        {
        }
    }
}
