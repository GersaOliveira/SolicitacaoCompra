﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.Produto;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }
        public DbSet<SolicitacaoAgg.SolicitacaoCompra> solicitacaoCompras { get; set; }
        public DbSet<SolicitacaoAgg.Item> items { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoAgg.Produto>()
                .HasData(
                    new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira", 100)
                );

            //// Configurações para Item
            //modelBuilder.Entity<Item>()
            //    .HasKey(i => i.Id);

            //// Configurações para SolicitacaoCompra
            //modelBuilder.Entity<SolicitacaoAgg.SolicitacaoCompra>()
            //    .HasKey(sc => sc.Id);

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=SistemaCompraDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
