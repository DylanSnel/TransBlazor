namespace TransBlazor.Models;
public class Language
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public bool IsDefault { get; set; } = false;
}
