using Newtonsoft.Json;
using DomainCategory = CoinManager.Core.Models.Category;

namespace CoinManager.Infrastructure.Kucoin.Models
{
    internal class Category
    {
        public string TagId { get; set; }
        public string Title { get; set; }
        
        public CoinManager.Core.Models.Category ToDomainModel()
        {
            return new DomainCategory(TagId, Title);
        }
    }
}