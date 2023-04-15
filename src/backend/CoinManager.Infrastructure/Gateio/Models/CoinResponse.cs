using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Gateio.Models;

class CoinResponse
{
    [JsonProperty("datas")] public CoinResponseData CoinsWrapper { get; set; }
}

class CoinResponseData
{
    [JsonProperty("coininfo")] public Coin Coin { get; set; }
}