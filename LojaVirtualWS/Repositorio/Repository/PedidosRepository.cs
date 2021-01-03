using Dominio.Contratos;
using Dominio.Entidades;
using Repositorio.Contexto;

namespace Repositorio.Repository
{
    public class PedidosRepository : BaseRepository<Pedidos>, IPedidosRepository
    {
        public PedidosRepository(LojaVirtualDbContext contexto) : base(contexto)
        {
        }
    }
}
