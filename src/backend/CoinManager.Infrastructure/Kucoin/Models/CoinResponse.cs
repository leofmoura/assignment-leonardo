using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Kucoin.Models;

class CoinResponse
{
    public int Code { get; set; }
    [JsonProperty("data")] 
    public CoinInfoDetails CoinDetails { get; set; }
}
