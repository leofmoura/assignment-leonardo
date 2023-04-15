using Newtonsoft.Json;
using DomainCategory = CoinManager.Core.Models.Category;

namespace CoinManager.Infrastructure.Kucoin.Models
{
    internal class CategoryResponse
    {
        public int Code { get; set; }
        [JsonProperty("data")] public Category[]? Categories { get; set; }
    }
}