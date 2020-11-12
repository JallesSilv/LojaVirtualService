using Dominio.Contratos;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Repositorio.Config;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Repositorio.Repository
{
    public class ProdutosRepository : BaseRepository<Produtos>, IProdutosRepository
    {
        public ProdutosRepository(LojaVirtualDbContext contexto) : base(contexto)
        {
        }

        //public void AdicionarProdutosImagem()
        //{
        //    try
        //    {
        //        var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
        //        produtos.NomeImagem = BityImagem(produtos.NomeImagem);
        //        Contexto.Add(produtos);
        //        Contexto.SaveChanges();
        //    }
        //    catch (Exception error)
        //    {
        //        throw new Exception($@"{error.Message}");
        //    }
        //}

        //private byte BityImagem(byte nomeImagem)
        //{
        //    var imagem = Convert.ToByte(nomeImagem);
        //    return imagem;
        //}
    }
}
