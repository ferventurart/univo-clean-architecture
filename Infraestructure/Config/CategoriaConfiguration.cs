using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        protected void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categoria>()
                   .HasOne(c => c.Departamento)
                   .WithMany(c => c.Categorias)
                   .HasForeignKey(c => c.DepartamentoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Categoria>()
                   .HasMany(c => c.Productos)
                   .WithOne(c => c.Categoria)
                   .HasForeignKey(c => c.CategoriaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.DepartamentoId)
                   .IsRequired()
                   .HasColumnType("integer");

            builder.Property(c => c.Nombre)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(c => c.Activo)
                   .IsRequired();

            builder.Property(c => c.CreatedDT)
                   .HasColumnType("timestamp without time zone");

            builder.Property(c => c.ModifiedDT)
                   .HasColumnType("timestamp without time zone");
        }
    }
}
