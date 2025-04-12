using ChartWheaterApi;
using ChartWheaterApi.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var Mykey = builder.Configuration.GetConnectionString("MySyncfusionLisence");

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Mykey);

string baseApiUrl;

#if DEBUG
// Ambiente local (sem Docker)
baseApiUrl = "http://localhost:5000/";
#else
    // Ambiente com Docker, usando nginx como proxy. Redireciona para o nginx resollver a rota
    baseApiUrl = "http://nginx/";
#endif

builder.Services.AddHttpClient<IWheaterService, WheaterService>(client =>
{
    client.BaseAddress = new Uri(baseApiUrl);
});

builder.Services.AddOptions();

await builder.Build().RunAsync();
