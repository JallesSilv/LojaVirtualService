using Dominio.Contratos;
using Dominio.Entidades;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class ProdutosRepository : BaseRepository<Produtos>, IProdutosRepository
    {
        public ProdutosRepository(LojaVirtualDbContext contexto) : base(contexto)
        {
        }
    }
}
