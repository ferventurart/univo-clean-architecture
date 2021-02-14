using ApplicationCore.Interfaces.Repositories;
using Infraestructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositorios
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(EfRepository<,>));
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            //Services
            return services;
        }
    }
}
