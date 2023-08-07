using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TransBlazor;
using TransBlazor.Models;
using TransBlazor.Sample;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.AddTransBlazor<Language, GlobalScope>(config =>
{
    config.SetLanguages(new List<Language>()
    {
        new Language()
        {
            Name = "English",
            Code = "en"
        },
         new Language()
        {
            Name = "Nederlands",
            Code = "nl"
        }
    });
    config.UseJson("/Localization");
});

await builder.Build().RunAsync();
