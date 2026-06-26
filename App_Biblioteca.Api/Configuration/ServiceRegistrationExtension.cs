using System.Text;
using App_Biblioteca.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace App_Biblioteca.Api.Configuration;

public static class ServiceRegistrationExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BibliotecaDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        return services;
    }

    public static IServiceCollection AddSwaggerWithJwt(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "App Biblioteca API",
                Version = "v1",
                Description = "API para gestión de biblioteca con CQRS y Arquitectura Hexagonal\n\n## Ejemplos de uso:\n\n### Login\nPOST /api/auth/login\n```json\n{\n  \"correo\": \"admin@biblioteca.com\",\n  \"password\": \"123456\"\n}\n```\n\n### Crear Autor (Requiere token Administrador)\nPOST /api/autor\n```json\n{\n  \"nombre\": \"Gabriel García Márquez\",\n  \"nacionalidad\": \"Colombiana\",\n  \"fechaNacimiento\": \"1927-03-06\"\n}\n```\n\n### Crear Libro (Requiere token)\nPOST /api/libro\n```json\n{\n  \"titulo\": \"Cien Años de Soledad\",\n  \"isbn\": \"978-0307474728\",\n  \"anioPublicacion\": 1967,\n  \"stock\": 5,\n  \"autorId\": 1,\n  \"categoriaId\": 1,\n  \"editorialId\": 1\n}\n```\n\n### Registrar Préstamo (Requiere token Bibliotecario/Admin)\nPOST /api/prestamo\n```json\n{\n  \"usuarioId\": 1,\n  \"libroId\": 1\n}\n```\n\n### Devolver Libro\nPUT /api/prestamo/devolver/1"
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Ingrese el token JWT obtenido en /api/auth/login"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

    public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(Application.UseCases.Autores.Commands.CreateAutor.CreateAutorCommand).Assembly));

        return services;
    }
}
