﻿using Dominio.Contratos;
using Dominio.Entidades;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Repository
{
    public class PessoasRepository : BaseRepository<Pessoas>, IPessoasRepository
    {
        private readonly LojaVirtualDbContext _contexto;
        public PessoasRepository(LojaVirtualDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Pessoas Login(string pEmail, string pSenha)
        {
            try
            {
                return _contexto.Pessoas.FirstOrDefault(pX=> pX.Email == pEmail && pX.Senha == pSenha);
            }
            catch (Exception error)
            {

                throw new Exception($@"{error.Message}");
            }
        }
        
        public Pessoas Login(string pEmail)
        {
            return _contexto.Pessoas.FirstOrDefault(pX=>pX.Email == pEmail);
        }

    }
}
