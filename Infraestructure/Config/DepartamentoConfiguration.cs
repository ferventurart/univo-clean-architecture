using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        protected void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Departamento>()
                   .HasMany(c => c.Categorias)
                   .WithOne(c => c.Departamento)
                   .HasForeignKey(c => c.DepartamentoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(c => c.Id);

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
