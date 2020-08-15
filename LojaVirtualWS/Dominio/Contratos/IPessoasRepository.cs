using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
    public interface IPessoasRepository : IBaseRepository<Pessoas>
    {
         Pessoas Login(string pEmail, string pSenha);
        Pessoas Login(string login);
    }
}
