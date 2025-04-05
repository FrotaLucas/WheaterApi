using ChartWheaterApi.Components;
using ChartWheaterApi.Components.Services;


using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

//var builder = WebApplication.CreateBuilder(args);
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add services to the container.
//builder.Services.AddRazorComponents()
//    .AddInteractiveServerComponents();


//services Interface && Class
builder.Services.AddScoped<ITemperatureService, TemperatureService>();


//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error", createScopeForErrors: true);
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


//app.UseHttpsRedirection();


//app.UseAntiforgery();

//app.MapStaticAssets();
//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode();

//app.Run();

builder.Services.AddOptions();


await builder.Build().RunAsync();
