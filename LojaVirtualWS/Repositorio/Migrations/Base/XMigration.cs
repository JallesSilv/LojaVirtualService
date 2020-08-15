using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Migrations.Base
{
    public abstract class XMigration
    {
        protected LojaVirtualDbContext _contexto;
        public XMigration(LojaVirtualDbContext contexto)
        {
            _contexto = contexto;
        }

        public abstract void Executar();

    }
}
