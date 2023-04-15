using System;
using CoinManager.Core.Models;

namespace CoinManager.Application.Coins
{
	public interface ICoinService
	{
		Task<IEnumerable<AggregateCoin>> GetAggregateCoinsByCategory(string categoryId);
		Task<Coin?> GetCoinBySymbol(string symbol, string provider);
		
	}
}

