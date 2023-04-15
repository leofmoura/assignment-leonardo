using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Gateio.Models;

public class Coin
{
    public string? Symbol { get; set; }
    public string? Name { get; set; }
    [JsonProperty("ticker_last")]
    public decimal LastPrice { get; set; }
    [JsonProperty("change")]
    public decimal ChangeRate { get; set; }
    
    public CoinManager.Core.Models.Coin ToDomainModel()
    {
        return new Core.Models.Coin(Symbol, Symbol, Symbol, Name, LastPrice, ChangeRate, LastPrice * ChangeRate, null);
    }
}