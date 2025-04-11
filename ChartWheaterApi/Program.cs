using ChartWheaterApi;
using ChartWheaterApi.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
    "MzgwNzMyMkAzMjM5MmUzMDJlMzAzYjMyMzkzYmNiRFkvMnd4Yjh1T2hHWkZtcHR2UldyY1R4cDh5WkFKNStOdEtwS2hmT1U9"
);

//investigar pq essa 1 opcao nao eh valida. Esta igual projeto Ecommerce
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped<ITemperatureService, TemperatureService>();

builder.Services.AddHttpClient<IWheaterService, WheaterService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
});

builder.Services.AddOptions();

await builder.Build().RunAsync();
