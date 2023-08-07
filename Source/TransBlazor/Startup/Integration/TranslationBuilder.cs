using TransBlazor.Languages;
using TransBlazor.Models;
using TransBlazor.Services;
using TransBlazor.Translations;

namespace TransBlazor.Startup.Integration;

public class TranslationBuilder<TLanguage, TGlobalState> : ITranslationBuilder<TLanguage, TGlobalState> where TLanguage : Language where TGlobalState : class
{
    private ILanguageProvider<TLanguage>? _languageProvider;
    private TGlobalState? _globalState;
    private string _prefix = "";
    private readonly List<ITranslationSource> _translationSources = new();

    public ITranslationBuilder<TLanguage, TGlobalState> AddTranslationStrings(Dictionary<string, string> translationStrings)
    {
        // For each language, create a TranslationSource and add it to _translationSources
        return this;
    }

    public ITranslationBuilder<TLanguage, TGlobalState> UseJson(string folderPath = "translate", string fileFormat = "{language}.json")
    {
        var translationSource = new JsonTranslationSource();
        _translationSources.Add();
        return this;
    }

    public ITranslationBuilder<TLanguage, TGlobalState> SetLanguages(IList<TLanguage> languages)
    {
        _languageProvider = new InMemoryLanguageProvider<TLanguage>(languages);
        return this;
    }

    public TransBlazorService<TLanguage, TGlobalState> Build()
    {
        if (_languageProvider == null)
        {
            throw new InvalidOperationException("LanguageProvider must be set");
        }
        if (_translationSources.Count == 0)
        {
            throw new InvalidOperationException("At least one translation source must be set");
        }

        return new TransBlazorService<TLanguage, TGlobalState>(_languageProvider, _translationSources, _prefix, _globalState);
    }

    public ITranslationBuilder<TLanguage, TGlobalState> UsePrefix(string prefix)
    {
        _prefix = prefix.Trim();
        return this;
    }

    public ITranslationBuilder<TLanguage, TGlobalState> SetGlobalState(TGlobalState globalState)
    {
        _globalState = globalState;
        return this;
    }
}
