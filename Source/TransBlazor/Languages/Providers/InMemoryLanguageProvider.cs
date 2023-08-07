using TransBlazor.Models;

namespace TransBlazor.Languages;
internal class InMemoryLanguageProvider<TLanguage> : ILanguageProvider<TLanguage> where TLanguage : Language
{
    private readonly IList<TLanguage> _languages;
    public InMemoryLanguageProvider(IList<TLanguage> languages)
    {
        if (languages.Count == 0)
        {
            throw new ArgumentException("At least one language must be provided");
        }
        if (languages.Where(l => l.IsDefault).Count() != 1)
        {
            throw new ArgumentException("Exactly one language must be marked as default");
        }
        _languages = languages;
    }

    public Task<IList<TLanguage>> GetLanguages() => Task.FromResult(_languages);
}
