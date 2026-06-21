using App_Biblioteca.Domain.Entities;

namespace App_Biblioteca.Infrastructure.Data;

public static class DbInitializer
{
    public static void Seed(BibliotecaDbContext context)
    {
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Rol { Nombre = "Administrador" },
                new Rol { Nombre = "Bibliotecario" }
            );
            context.SaveChanges();
        }
    }
}
