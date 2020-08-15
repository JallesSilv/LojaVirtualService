using Dominio.Entidades;
using Dominio.ObjetoDeValor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Contexto
{
    public class LojaVirtualDbContext : DbContext
    {
        public LojaVirtualDbContext(DbContextOptions<LojaVirtualDbContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<ItemPedidos> ItemPedidos { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<Versao_Migration> Versao_Migration { get; set; }

    }
}

