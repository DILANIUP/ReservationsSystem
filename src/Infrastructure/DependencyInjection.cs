using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReservationsSystem.Domain.Interfaces;
using ReservationsSystem.Infrastructure.Authentication;
using ReservationsSystem.Infrastructure.Data;

namespace Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();
        services.AddAuth(configuration);
        return services;
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration
                    .GetConnectionString(
                        "Default"))); //*important: Cada capa de la infraestructura es un proyecto, el ensamblado es de todos los proyectos es decir la sln, entonces busca en el ensamblado
        // optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));    //*important: Es como pedir la informacion de las migraciones cuando estan en otros proyectos

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
    }

    private static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        // var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>(); El segundo get lee las configuraciones y crea el objeto del genérico
        var jwtSection = configuration.GetSection("JwtSettings");
        var secretKey = jwtSection["SecretKey"] ??
                        throw new InvalidOperationException("JWT SecretKey is not configured.");
        var issuer = jwtSection["Issuer"] ?? throw new InvalidOperationException("JWT Issuer is not configured.");
        var audience = jwtSection["Audience"] ?? throw new InvalidOperationException("JWT Audience is not configured.");


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //habilita el sistema  auth 
            .AddJwtBearer( //habilitar el middleware y se configura los parametros que dictan como se validará el token 
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                }
            );
        // services.AddAuthorization();
    }
}