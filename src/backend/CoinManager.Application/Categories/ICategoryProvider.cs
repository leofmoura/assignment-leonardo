using System;
using CoinManager.Core.Models;

namespace CoinManager.Application.Categories
{
	public interface ICategoryProvider
	{
		Task<IEnumerable<Category>> GetCategories();
	}
}

