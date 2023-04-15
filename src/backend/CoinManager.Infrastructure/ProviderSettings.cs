namespace CoinManager.Infrastructure;

public static class APIProviders
{
    public static readonly string Primary = "primary";
    public static readonly string Secondary = "secondary";
}
public class ProviderSettings
{
    public string Name { get; set; }
    public string UrlBase { get; set; }
}