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
        
        //public void AdicionarFile(FileToUpload theFile)
        //{
        //    try
        //    {
        //        Contexto.Dispose();
                
        //        var chaveMax = 1;
        //        //var chaveMax = Contexto.FileToUpload.Max(pX=>pX.ChaveFile);

        //        Contexto.FileToUpload.AddRange(new FileToUpload() 
        //        { 
        //            ChaveFile = chaveMax++,
        //            FileAsBase64 = theFile.FileAsBase64,
        //            FileAsByteArray = theFile.FileAsByteArray,
        //            FileName = theFile.FileName,
        //            FileSize = theFile.FileSize,
        //            FileType = theFile.FileType,
        //            LastModifiedDate = theFile.LastModifiedDate,
        //            LastModifiedTime = theFile.LastModifiedTime
        //        });

        //        Contexto.SaveChanges();
        //    }
        //    catch (Exception error)
        //    {

        //        throw new Exception($"Erro ao cadastra File: {error}");
        //    }
        //}

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
