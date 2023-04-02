using ContadorDeVacinasAplicadas.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContadorDeVacinasAplicadas.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CPF)
                .HasMaxLength(14);

        }
    }
}
