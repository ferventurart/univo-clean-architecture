using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestructure
{
    public class SysVentasDbContext : DbContext
    {
        public SysVentasDbContext(DbContextOptions<SysVentasDbContext> options) : base(options){}

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
