using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Kucoin.Models;

public class CoinInfoDetails
{
    public string? SymbolCode { get; set; }
    [JsonProperty("item")] 
    public string? SymbolDisplay { get; set; }
    public string? FullName { get; set; }
    public decimal Price { get; set; }
    public decimal PriceChangeRate24h { get; set; }
    public decimal PriceChange24h { get; set; }

    public CoinManager.Core.Models.Coin ToDomainModel()
    {
        return new Core.Models.Coin(SymbolCode, SymbolCode, SymbolDisplay, FullName, Price, PriceChangeRate24h, PriceChange24h, null);
    }
}