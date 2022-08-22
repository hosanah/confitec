using Confitec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Data.Mappings
{
    public class HistoricoEscolarMap : IEntityTypeConfiguration<HistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<HistoricoEscolar> builder)
        {
            // Tabela
            builder.ToTable("HistoricoEscolar");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

             // Propriedades
            builder.Property(x => x.Formato)
                .IsRequired()
                .HasColumnName("Formato")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

        }
    }
}