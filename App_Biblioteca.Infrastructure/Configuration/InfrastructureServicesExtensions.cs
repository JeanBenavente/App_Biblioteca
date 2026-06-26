using App_Biblioteca.Domain.Ports.IRepositories;
using App_Biblioteca.Domain.Ports.IServices;
using App_Biblioteca.Infrastructure.Adapters.Repositories;
using App_Biblioteca.Infrastructure.Adapters.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App_Biblioteca.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IEditorialRepository, EditorialRepository>();
        services.AddScoped<ILibroRepository, LibroRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPrestamoRepository, PrestamoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
