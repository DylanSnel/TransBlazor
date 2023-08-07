namespace TransBlazor.Translations;
public class TranslationSet : Dictionary<string, string>
{
    public void Apply(TranslationSet translationSet)
    {
        foreach (var item in translationSet)
        {
            this[item.Key] = item.Value;
        }
    }
}
