using Confitec.Data.Mappings;
using Confitec.Models;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Data
{
    
    public class ConfitecDbContext : DbContext
    {

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Escolaridade> Escolaridade { get; set; }
        public DbSet<HistoricoEscolar> HistoricoEscolar { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=192.168.150.7,1433;Database=AbissalSystem;User ID=sa;Password=Dbamaster.");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new EscolaridadeMap());
            modelBuilder.ApplyConfiguration(new HistoricoEscolarMap());
        }
    }

}
