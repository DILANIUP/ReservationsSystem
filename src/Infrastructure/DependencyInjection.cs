using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Infrastructure.Data;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        return services;
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));                                  //*important: Cada capa de la infraestructura es un proyecto, el ensamblado es de todos los proyectos es decir la sln, entonces busca en el ensamblado
            // optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));    //*important: Es como pedir la informacion de las migraciones cuando estan en otros proyectos
    }
}