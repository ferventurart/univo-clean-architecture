using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Config
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        protected void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Producto>()
                   .HasOne(c => c.Categoria)
                   .WithMany(c => c.Productos)
                   .HasForeignKey(c => c.CategoriaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CategoriaId)
                   .IsRequired()
                   .HasColumnType("integer");

            builder.Property(c => c.Nombre)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(c => c.PrecioCompra)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.PrecioVenta)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Utilidad)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Activo)
                   .IsRequired();

            builder.Property(c => c.CreatedDT)
                   .HasColumnType("timestamp without time zone");

            builder.Property(c => c.ModifiedDT)
                   .HasColumnType("timestamp without time zone");
        }
    }
}
