using Dominio.Contratos;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Config;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Repository
{
    public class FinanceiroRepository : BaseRepository<CaixaMovimentacao>, IFinanceiroRepository
    {
        private LojaVirtualDbContext _context;
        public FinanceiroRepository(LojaVirtualDbContext contexto) : base(contexto)
        {
            _context = contexto;
        }

        public void ObterTodosPelaData(DateTime? pDataInicio, DateTime? pDataFim)
        {
            
        }

        List<CaixaMovimentacao> IFinanceiroRepository.ObterTodosPelaData(DateTime? pDataInicio, DateTime? pDataFim)
        {
            if (pDataInicio == null)
                pDataInicio = null;
            if (pDataFim == null)
                pDataFim = DateTime.Now.Date;
            //var teste1 = _context.Banco.ToList();
            //var teste2 = _context.Caixa.Include(p=>p.Banco).ToList();
            //var teste3 = _context.FormaPagamentos.ToList();
            
            //var teste4 = _context.Pedidos.Include(p=>p.Pessoas).Include(p=>p.FormaPagamento).ToList();

            //var teste = _context.CaixaMovimentacao.Include(p=>p.Caixa).ThenInclude(p=>p.Banco)
            //                                        .Include(p=>p.Pessoas)
            //                                        .Include(p=>p.Pedidos)
            //                                        .Include(p=>p.FileToUpload)
            //                                        .Where(pX =>
            //                                                    pX.DataCadastro >= pDataInicio &&
            //                                                    pX.DataCadastro <= pDataFim)
            //                                                    .OrderBy(pX => pX.DataCadastro)
            //                                        .ToList();

            var listaMovimentacao = _context.CaixaMovimentacao.Include(p => p.Caixa).ThenInclude(p => p.Banco)
                                                    .Include(p => p.Pessoas)
                                                    .Include(p=>p.Pedidos).ThenInclude(pX => pX.Pessoas)
                                                    .Include(p => p.Pedidos).ThenInclude(pX => pX.FormaPagamento)
                                                    .Include(pX=> pX.FormaPagamento)
                                                    .Include(p => p.FileToUpload)
                                                    .Where(pX =>
                                                                pX.DataCadastro >= pDataInicio &&
                                                                pX.DataCadastro <= pDataFim)
                                                                .OrderBy(pX => pX.DataCadastro)
                                                    .ToList();

            listaMovimentacao.ForEach(pX => new CaixaMovimentacao()
            {
                ChaveCaixaMovimentacao = pX.ChaveCaixaMovimentacao,
                ChaveCaixa = pX.ChaveCaixa,
                ChavePedido = pX.ChavePedido,
                ChavePessoa = pX.ChavePessoa,
                ChaveFormaPagamento = pX.ChaveFormaPagamento,
                ChaveFile = pX.ChaveFile,
                Valor = pX.Valor,
                DataCadastro = pX.DataCadastro,
                DataEstorno = pX.DataEstorno,
                DataPago = pX.DataPago,
                Descricao = pX.Descricao,
                Ativo = pX.Ativo,
                FecharCaixaAutomatico = pX.FecharCaixaAutomatico,
                TipoLancamento = pX.TipoLancamento,
                ValorAntecipado = pX.ValorAntecipado,

            });
            
            return listaMovimentacao;
        }
    }
}