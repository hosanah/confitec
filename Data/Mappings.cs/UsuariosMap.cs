using Confitec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Data.Mappings
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Tabela
            builder.ToTable("Usuarios");

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
            builder.Property(x => x.Sobrenome)
                .IsRequired()
                .HasColumnName("Sobrenome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

             // Propriedades
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

             // Propriedades
            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnName("Birthday")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60);

            // Relacionamentos
            builder
                .HasOne(x => x.Escolaridade)
                .WithMany(x => x.Usuarios)
                .HasConstraintName("FK_Escolaridade_Usuario");

             // Relacionamentos
            builder
                .HasOne(x => x.HistoricoEscolar)
                .WithMany(x => x.Usuarios)
                .HasConstraintName("FK_HistEscolar_Usuario");

        }
    }
}