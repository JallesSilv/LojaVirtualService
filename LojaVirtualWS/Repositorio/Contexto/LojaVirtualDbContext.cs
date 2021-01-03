using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Contexto
{
    public class LojaVirtualDbContext : DbContext
    {
        public LojaVirtualDbContext(DbContextOptions<LojaVirtualDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<PedidosItens> PedidosItens { get; set; }
        public DbSet<ControleAcesso> ControleAcesso { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Banco> Banco { get; set; } 
        public DbSet<CaixaMovimentacao> CaixaMovimentacao { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<Versao_Migration> Versao_Migration { get; set; }
        public DbSet<FileToUpload> FileToUpload { get; set; }

    }
}

