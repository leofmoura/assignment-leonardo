using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Kucoin.Models;

public class CoinInfoDetails
{
    [JsonProperty("currency")] 
    public string? SymbolCode { get; set; }
    public decimal Price { get; set; }
    public decimal PriceChangeRate24h { get; set; }
    public decimal PriceChange24h { get; set; }
    public decimal MarketCap { get; set; }

    public CoinManager.Core.Models.Coin ToDomainModel()
    {
        return new Core.Models.Coin(SymbolCode, SymbolCode, SymbolCode, SymbolCode, Price, PriceChangeRate24h * 100,
            PriceChange24h, null, MarketCap);
    }
}