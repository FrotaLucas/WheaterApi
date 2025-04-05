using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WheaterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Força a aplicação a rodar na porta 4000
//builder.WebHost.ConfigureKestrel(options =>
//{
//    // HTTP see launchSettings
//    //options.ListenAnyIP(4000);
//    //http://localhost:4000/swagger/index.html

//    // HTTPS see launchSettings. A imagem aspnet:8.0 nao tem certificado valido para rodar HTTPS
//    options.ListenAnyIP(4001, listenOptions => listenOptions.UseHttps());
//    //https://localhost:4001/swagger/index.html
//});

// Redis Config
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
});

// Service para consumir a API open-meteo
builder.Services.AddHttpClient<WheaterService>();

//NAO SEI SE PRECISA 
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IWheaterService, WheaterService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // por padrão ele já usa /swagger como rota
}



//TUDO PARA BLAZOR 
app.UseHttpsRedirection();
//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();


app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

//JA ESTA EM CIMA CONFIGURADO
//app.MapControllers();

app.Run();
