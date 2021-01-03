using Dominio.Contratos;
using Dominio.Entidades;
using Dominio.Enumerados;
using Repositorio.Config;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Repositorio.Repository
{
    public class FileToUploadRepository : BaseRepository<FileToUpload>, IFileToUploadRepository
    {
        private readonly LojaVirtualDbContext _context;

        public FileToUploadRepository(LojaVirtualDbContext context) : base(context)
        {
            _context = context;
            chaveFormaPagamento = (byte)_context.FormaPagamentos.Max(pX => pX.ChaveFormaPagamento);
        }

        public Int64 chaveFormaPagamento;
         

        public void AdicionarFile(FileToUpload theFile)
        {
            try
            {
                //Int64 chaveCaixaMovimentacaoMax = 0;
                Int64 chaveFileUploadMax = (byte)_context.FileToUpload.Max(pX=>pX.ChaveFile);
                Int64 chaveCaixaMovimentacaoMax = (byte)_context.CaixaMovimentacao.Max(pX => pX.ChaveCaixaMovimentacao);
                //Int64 chaveMax = (byte)_context.FileToUpload.Max(pX => pX.ChaveFile);
                //Int64 chaveFormaPagamento = (byte)_context.Caixa.Max(pX => pX.ChaveCaixa);
                Int64 chaveCaixaAberto = (byte)_context.Caixa.Max(pX=>pX.ChaveCaixa);


                var baseFile = theFile.FileAsBase64.Split(",");
                //CadastrarFinanceiro(baseFile[1]);

                _context.FileToUpload.Add(new FileToUpload()
                {
                    ChaveFile = ++chaveFileUploadMax,
                    FileAsBase64 = baseFile[1],
                    FileName = theFile.FileName,
                    FileSize = theFile.FileSize,
                    FileType = theFile.FileType,
                    LastModifiedDate = theFile.LastModifiedDate
                });
                //_context.SaveChanges();
                byte[] teste = Convert.FromBase64String(baseFile[1]);
                string fileString = UTF8Encoding.UTF8.GetString(teste);

                var quebra = fileString.Split("\n");
                var reader = new CaixaMovimentacao();
                List<CaixaMovimentacao> lista = new List<CaixaMovimentacao>();
                
                foreach (var item in quebra)
                {
                    if (!item.Contains("date"))
                    {
                        var itemQuebra = item.Split(",");

                        reader = new CaixaMovimentacao()
                        {
                            ChaveCaixaMovimentacao = ++chaveCaixaMovimentacaoMax,
                            ChaveFormaPagamento = VerificarFormaPagamento(itemQuebra[1]),
                            ChaveFile = chaveFileUploadMax,
                            ChaveCaixa = chaveCaixaAberto,
                            FecharCaixaAutomatico = true,
                            ChavePedido = null,
                            ChavePessoa = null,
                            DataCadastro = itemQuebra[0].AsDateTime(),
                            DataPago = null,
                            DataEstorno = null,                            
                            TipoLancamento = (byte)TipoDeLancamento.Despesas,
                            Valor = itemQuebra[3].AsDecimal(),
                            ValorAntecipado = 0,
                            Ativo = true,                            
                            Descricao = itemQuebra[2],
                            
                        };

                        lista.Add(reader);
                    }
                }
                lista.ToList();
                _context.CaixaMovimentacao.AddRange(lista);
                _context.SaveChanges();
            }
            catch (Exception error)
            {

                throw new Exception($"Erro ao cadastra File: {error}");
            }
        }

        private Int64? VerificarFormaPagamento(string pValor)
        {
            try
            {

                if (pValor.EstaVazio()) return null;
                var chaveFormaDePagamento = _context.FormaPagamentos.Where(pX => pX.Categoria.ToLower().Trim() == pValor.ToLower().Trim()).FirstOrDefault()?.ChaveFormaPagamento;

                if (chaveFormaDePagamento == null)
                {

                    var incluirFormaPagamento = new FormaPagamento()
                    {
                        ChaveFormaPagamento = ++chaveFormaPagamento,
                        Categoria = pValor,
                        Tipo = "Cartão",
                        Descricao = "Nubank",
                        Ativo = true,
                    };
                    _context.FormaPagamentos.Add(incluirFormaPagamento);
                    _context.SaveChanges();

                    return incluirFormaPagamento.ChaveFormaPagamento;
                }
                return chaveFormaDePagamento;
            }
            catch (Exception error)
            {

                throw new Exception($"Erro ao cadastra File: {error}");
            }
}
    }
}
