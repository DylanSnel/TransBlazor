using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TransBlazor.Models;
using TransBlazor.Startup;
using TransBlazor.Startup.Integration;

namespace TransBlazor;
public static class DependencyInjection
{
    public static WebAssemblyHostBuilder AddTransBlazor<TLanguage>(this WebAssemblyHostBuilder builder, Action<ITranslationBuilder<TLanguage, EmptyScope>> config) where TLanguage : Language
    {
        return AddTransBlazor<TLanguage, EmptyScope>(builder, config);
    }

    public static WebAssemblyHostBuilder AddTransBlazor<TLanguage, TGlobalState>(this WebAssemblyHostBuilder builder, Action<ITranslationBuilder<TLanguage, TGlobalState>> config) where TLanguage : Language where TGlobalState : class
    {
        var translate = new TranslationBuilder<TLanguage, TGlobalState>();
        config(translate);
        builder.Services.AddSingleton(translate.Build());
        return builder;
    }
}
