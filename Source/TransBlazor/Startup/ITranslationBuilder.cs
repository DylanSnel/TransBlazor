using TransBlazor.Models;
using TransBlazor.Services;

namespace TransBlazor.Startup;

public interface ITranslationBuilder<TLanguage, TGlobalState> where TLanguage : Language where TGlobalState : class
{
    ITranslationBuilder<TLanguage, TGlobalState> SetGlobalState(TGlobalState globalState);
    ITranslationBuilder<TLanguage, TGlobalState> AddTranslationStrings(Dictionary<string, string> translationStrings);
    ITranslationBuilder<TLanguage, TGlobalState> SetLanguages(IList<TLanguage> languages);
    ITranslationBuilder<TLanguage, TGlobalState> UsePrefix(string prefix);
    TransBlazorService<TLanguage, TGlobalState> Build();
    ITranslationBuilder<TLanguage, TGlobalState> UseJson(string folderPath = "translate", string fileFormat = "{language}.json");
}
