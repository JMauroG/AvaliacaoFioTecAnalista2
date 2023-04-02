using ContadorDeVacinasAplicadas.API.Services;
using ContadorDeVacinasAplicadas.API.Services.Interfaces;
using ContadorDeVacinasAplicadas.Data;
using ContadorDeVacinasAplicadas.Data.Repositorios;
using ContadorDeVacinasAplicadas.Data.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ContadorDeVacinasAplicadas.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ContadorDeVacinasAplicadas",
                    Version = "v1",
                    Description = "Uma Web Api feita em .NET 7 para Prova da FioTec de Analista II"
                });

                c.IncludeXmlComments(string.Format(@"{0}\ContadorDeVacinasAplicadas.XML",
                 System.AppDomain.CurrentDomain.BaseDirectory));
            });
            return services;
        }

        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DB"));
            });
            return services;
        }

        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioService, RelatorioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IValidationService, ValidationService>();

            return services;
        }

        public static IServiceCollection AddAplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
