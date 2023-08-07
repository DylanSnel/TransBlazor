namespace TransBlazor.Translations;
public interface ITranslationSource
{
    Task<TranslationSet> GetTransLations(string languageCode);
    Task<Dictionary<string, string>> SetTranslations(string languageCode);
}
