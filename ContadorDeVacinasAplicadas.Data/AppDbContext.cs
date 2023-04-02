using ContadorDeVacinasAplicadas.Data.Configuration;
using ContadorDeVacinasAplicadas.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ContadorDeVacinasAplicadas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
