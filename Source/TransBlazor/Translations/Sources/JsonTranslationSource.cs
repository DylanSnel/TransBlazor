namespace TransBlazor.Translations;
internal class JsonTranslationSource : ITranslationSource
{
    private readonly HttpClient _httpClient;

    public string FolderPath { get; private set; } = "";
    public string FileFormat { get; private set; } = "{language}.json";

    public JsonTranslationSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void SetFolderPath(string folderPath)
    {
        FolderPath = folderPath;
    }

    public void SetFileFormat(string fileFormat)
    {
        FileFormat = fileFormat;
    }



    public async Task<TranslationSet> GetTransLations(string languageCode)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, string>> SetTranslations(string languageCode)
    {
        throw new NotImplementedException();
    }
}
