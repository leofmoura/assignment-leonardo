namespace CoinManager.Core.Models;

public class AggregateCoin
{
    public AggregateCoin(string principalSymbolCode, string symbolDisplay, string name, string? urlImage, decimal principalPrice,
        decimal principalPriceChange)
    {
        PrincipalSymbolCode = principalSymbolCode ?? throw new ArgumentNullException(nameof(principalSymbolCode));
        SymbolDisplay = symbolDisplay;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        UrlImage = urlImage;
        PrincipalPrice = principalPrice;
        PrincipalPriceChange = principalPriceChange;
    }

    public string SymbolDisplay { get; set; }
    public string Name { get; set; }
    public string? UrlImage { get; set; }
    public string PrincipalSymbolCode { get; set; }
    public decimal PrincipalPrice { get; set; }
    public decimal PrincipalPriceChange { get; set; }
    public string SecondarySymbolCode { get; set; }
    public decimal? SecondaryPrice { get; set; }
    public decimal? SecondaryPriceChange { get; set; }
}