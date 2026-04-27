using ReservationsSystem.Application.Features.Auth;

namespace ReservationsSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication (this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        services.AddScoped<RegisterRequestValidator>();
        services.AddScoped<LoginRequestValidator>();
        return services;
    }
}

