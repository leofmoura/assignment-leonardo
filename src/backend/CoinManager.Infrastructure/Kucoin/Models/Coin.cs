using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Kucoin.Models;

public class Coin
{
    public string SymbolCode { get; set; }
    [JsonProperty("item")]
    public string AlternateSymbolCode { get; set; }
    public string? FullName { get; set; }
    public string? IconUrl { get; set; }
    public decimal Price { get; set; }
    public decimal ChangeRate { get; set; }
    
    public CoinManager.Core.Models.Coin ToDomainModel()
    {
        return new Core.Models.Coin(SymbolCode, AlternateSymbolCode, AlternateSymbolCode, FullName, Price, ChangeRate, Price * ChangeRate, IconUrl);
    }
}