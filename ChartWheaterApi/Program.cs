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

builder.Services.AddHttpClient<IWheaterService, WheaterService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
});

builder.Services.AddOptions();

await builder.Build().RunAsync();
