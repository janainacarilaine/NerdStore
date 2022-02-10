using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;
using System;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.Dimensoes, d =>
            {
                d.Property(c => c.Altura)
                    .HasColumnName("Altura")
                    .HasColumnType("int");

                d.Property(c => c.Largura)
                    .HasColumnName("Largura")
                    .HasColumnType("int");

                d.Property(c => c.Profundidade)
                    .HasColumnName("Profundidade")
                    .HasColumnType("int");
            });

            builder.ToTable("Produtos");
        }
    }
}
