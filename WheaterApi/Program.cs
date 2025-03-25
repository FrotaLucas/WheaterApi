using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;
using WheaterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Redis Config
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";  // Se o Redis estiver rodando localmente
    options.InstanceName = "WheaterCache:";
});

// service to consume api  open-meteo
builder.Services.AddHttpClient<WheaterService>();

// add controllers
builder.Services.AddControllers();

//swaggerDokumentatio
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/", () => "API wirking!");
app.MapControllers();

app.Run();
