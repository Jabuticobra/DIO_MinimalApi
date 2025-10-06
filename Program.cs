using minimalapi_api.infraestrutura.Db;
using minimalapi_api.Dominio.DTOs;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (minimalapi_api.Dominio.DTOs.LoginDTO LoginDTO) => {
    if (LoginDTO.Email == "adm@teste.com" && LoginDTO.Senha == "123456")
        return (Task)Results.Ok("login com sucesso");
    else
        return (Task)Results.Unauthorized();
});

app.Run();
