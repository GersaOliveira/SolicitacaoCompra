using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoAgg.Produto>
    {
        public void Configure(EntityTypeBuilder<ProdutoAgg.Produto> builder)
        {
            builder.ToTable("Produto");

            //builder.OwnsOne(p => p.Preco, preco =>
            //{
            //    preco.Property<decimal>("Value")
            //        .HasColumnName("Preco")
            //        .HasColumnType("decimal(18,2)"); 
            //});
        }
    }
}
