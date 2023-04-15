using CoinManager.Core.Models;

namespace CoinManager.Application.Providers;

public interface IGetCoinBySymbol
{
    Task<Coin?> GetCoinInformation(string symbol);
}