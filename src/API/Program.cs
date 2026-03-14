using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
// EF Core + SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();



app.UseHttpsRedirection();
app.MapControllers();
app.Run();