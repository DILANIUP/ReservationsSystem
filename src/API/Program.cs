using Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Application;
using ReservationsSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();



app.UseHttpsRedirection();
app.MapControllers();
app.Run();