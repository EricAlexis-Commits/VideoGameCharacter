using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameCharacter.Database;
using VideoGameCharacter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//Al programa le estamos diciendo que usara un servicio de base de datos referente a Sqlserver y esta conexion la obtenemos de la conexion
//Predeterminada
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Esto significa que se intenta inyectar la interfaz del personaje de videojuego interfaz, automaticamente
//tendra el servicio de implementacion del personaje de videojuego
builder.Services.AddScoped<IVideoGameCharacterServices,VideoGameCharacterServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
