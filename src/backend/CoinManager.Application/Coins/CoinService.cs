
using CoinManager.Application.Providers;
using CoinManager.Core.Models;

namespace CoinManager.Application.Coins
{
	public class CoinService: ICoinService
	{
		private readonly IPrimaryCoinProvider _primaryCoinProvider;
		private readonly ISecondaryCoinProvider _secondaryCoinProvider;

		public CoinService(IPrimaryCoinProvider primaryCoinProvider, ISecondaryCoinProvider secondaryCoinProvider)
		{
			_primaryCoinProvider = primaryCoinProvider;
			_secondaryCoinProvider = secondaryCoinProvider;
		}
		
		public async Task<IEnumerable<AggregateCoin>> GetAggregateCoinsByCategory(string categoryId)
		{
			var aggregateCoinList = new List<AggregateCoin>();
			var mainCoins = await _primaryCoinProvider.GetCoinsByCategory(categoryId);
			foreach (var mainCoin in mainCoins)
			{
				var aggregateCoin = new AggregateCoin(mainCoin.SymbolCode, mainCoin.SymbolDisplay, mainCoin.Name, mainCoin.UrlImage, 
					mainCoin.Price, mainCoin.PriceChange);

				try
				{
					var secondaryCoin = await _secondaryCoinProvider.GetCoinInformation(mainCoin.AlternateSymbolCode);
					if (secondaryCoin is not null)
					{
						aggregateCoin.SecondarySymbolCode = mainCoin.AlternateSymbolCode;
						aggregateCoin.SecondaryPrice = secondaryCoin.Price;
						aggregateCoin.SecondaryPriceChange = secondaryCoin.PriceChange;
					}
				}
				catch (Exception)
				{
					// _logger.LogError("Error on getting details for secondary provider", e);
					// We should not stop execution if secondary is down or in failed state
					// I expect the team monitors the application errors with automated ticket creators
					// Ex: PagerDuty runs periodically AzureMonitor queries that looks for issues on last 1 hour and
					//     creates a ticket assigned to on-call developer.
				}
				
				aggregateCoinList.Add(aggregateCoin);
			}

			return aggregateCoinList;
		}

		public async Task<Coin?> GetCoinBySymbol(string symbol, string provider)
		{
			return provider == APIProviders.Primary
				? await _primaryCoinProvider.GetCoinInformation(symbol)
				: await _secondaryCoinProvider.GetCoinInformation(symbol);
		}
	}
}

