using CoinManager.Core.Models;

namespace CoinManager.Application.Providers
{
	public interface IPrimaryCoinProvider: IGetCoinBySymbol
	{
		Task<IEnumerable<Coin>> GetCoinsByCategory(string categoryId);
	}
}

