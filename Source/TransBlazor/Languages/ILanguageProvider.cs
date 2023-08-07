using TransBlazor.Models;

namespace TransBlazor.Languages;
public interface ILanguageProvider<TLanguage> where TLanguage : Language
{
    Task<IList<TLanguage>> GetLanguages();
}
