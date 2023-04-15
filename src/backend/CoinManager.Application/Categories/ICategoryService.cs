using CoinManager.Core.Models;

namespace CoinManager.Application.Categories
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetCategories();
	}
}
