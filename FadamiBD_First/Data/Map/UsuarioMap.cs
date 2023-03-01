using FadamiBD_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FadamiBD_First.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(x => x.Codigo);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}