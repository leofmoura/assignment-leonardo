using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Kucoin.Models;

class CoinsResponse
{
    public int Code { get; set; }
    [JsonProperty("data")] 
    public CoinsResponseData CoinsWrapper { get; set; }
}

class CoinsResponseData
{
    [JsonProperty("items")] 
    public Coin[] Coins { get; set; }
}