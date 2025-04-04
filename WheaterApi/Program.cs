using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WheaterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Força a aplicação a rodar na porta 4000
builder.WebHost.ConfigureKestrel(options =>
{
    // HTTP
    //options.ListenAnyIP(4000); 
    // HTTPS see launchSettings
    options.ListenAnyIP(4001, listenOptions => listenOptions.UseHttps()); 
});

// Redis Config
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
});

// Service para consumir a API open-meteo
builder.Services.AddHttpClient<WheaterService>();

// Add controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // por padrão ele já usa /swagger como rota
}

app.MapControllers();

app.Run();
