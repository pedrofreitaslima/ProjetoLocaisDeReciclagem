using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLocaisDeReciclagem.Models;

namespace ProjetoLocaisDeReciclagem.Data.Maps
{
    public class LocaisReciclagemMap : IEntityTypeConfiguration<LocaisReciclagem>
    {
        public void Configure(EntityTypeBuilder<LocaisReciclagem> builder)
        {
            builder.ToTable("LocaisReciclagem");
            builder.HasKey(x => x.LocalReciclagemId);
            builder.Property(x => x.DataRegistro).IsRequired();
            builder.Property(x => x.Identificacao).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.CEP).HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.DataUltimaAlteracao).IsRequired();
            builder.Property(x => x.Capacidade).IsRequired().HasColumnType("float");
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(2).HasColumnType("varchar(2)");
            builder.Property(x => x.NumeroEndereco).HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.Complemento).HasMaxLength(30).HasColumnType("varchar(30)");
            builder.Property(x => x.Logradouro).HasMaxLength(100).HasColumnType("varchar(100)");
        }
    }
}