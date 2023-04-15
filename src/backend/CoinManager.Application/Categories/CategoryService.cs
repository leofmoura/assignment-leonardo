using CoinManager.Core.Models;

namespace CoinManager.Application.Categories
{
	public class CategoryService: ICategoryService
	{
		private readonly ICategoryProvider _categoryProvider;

		public CategoryService(ICategoryProvider categoryProvider)
		{
			_categoryProvider = categoryProvider;
		}

        public async Task<IEnumerable<Category>> GetCategories()
        {
	        return await _categoryProvider.GetCategories();
        }
    }
}

