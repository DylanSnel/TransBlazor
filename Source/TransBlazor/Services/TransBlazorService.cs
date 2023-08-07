using TransBlazor.Languages;
using TransBlazor.Models;
using TransBlazor.Translations;

namespace TransBlazor.Services;

public class TransBlazorService<TLanguage, TGlobalState> where TLanguage : Language where TGlobalState : class
{
    private readonly ILanguageProvider<TLanguage> _languageProvider;
    private readonly List<ITranslationSource> _translationSources;
    private readonly string _prefix;
    private readonly TGlobalState? _globalState;

    private readonly TranslationSet _translations = new();

    public IList<TLanguage> Languages { get; private set; }

    public event Action? OnStateChanged;

    public TransBlazorService(ILanguageProvider<TLanguage> languageProvider, List<ITranslationSource> translationSources, string prefix, TGlobalState? globalState)
    {
        _languageProvider = languageProvider;
        _translationSources = translationSources;
        _prefix = prefix;
        _globalState = globalState;
    }

    public async Task Initialize()
    {
        Languages = await _languageProvider.GetLanguages();
        var defaultLanguage = Languages.First(l => l.IsDefault);

        foreach (var translationSource in _translationSources)
        {
            _translations.Apply(await translationSource.GetTransLations(defaultLanguage.Code));
        }

    }

    private void NotifyStateChanged() => OnStateChanged?.Invoke();
}
