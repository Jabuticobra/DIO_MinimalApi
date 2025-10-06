var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO) =>
{
    if (LoginDTO.Email == "adm@teste.com" && LoginDTO.Senha == "123456")
        return (Task)Results.Ok("login com sucesso");
    else
        return (Task)Results.Unauthorized();
});

app.Run();
