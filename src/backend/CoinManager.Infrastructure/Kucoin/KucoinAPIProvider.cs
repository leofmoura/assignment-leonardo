using CoinManager.Application.Categories;
using CoinManager.Application.Providers;
using CategoryDomain = CoinManager.Core.Models.Category;
using CoinDomain = CoinManager.Core.Models.Coin;
using CoinManager.Infrastructure.Kucoin.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Kucoin
{
    public class KucoinAPIProvider : ICategoryProvider, IPrimaryCoinProvider, ISecondaryCoinProvider
    {
        private readonly ILogger<KucoinAPIProvider> _logger;
        private readonly ProviderSettings _providerSettings;

        public KucoinAPIProvider(ILogger<KucoinAPIProvider> logger, IConfiguration configuration)
        {
            _logger = logger;
            var primarySettings = configuration.GetSection("ApiProviders");
            _providerSettings = new ProviderSettings()
            {
                Name = primarySettings.GetSection(APIProviders.Primary)["name"],
                UrlBase = primarySettings.GetSection(APIProviders.Primary)["urlBase"]
            };
        }

        public async Task<IEnumerable<CategoryDomain>> GetCategories()
        {
            _logger.LogTrace($"Getting categories from external API");
            _logger.LogTrace(_providerSettings.ToString());
            using var httpClient = new HttpClient();
            using var response =
                await httpClient.GetAsync(
                    $"{_providerSettings.UrlBase}/discover-front/spl/list?lang=en_US&typeList=HOME_LIST,LIST");

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Leo - I could implement internal log here.
                throw new ApplicationException("Kucoin provider returned unsuccessful code");
            }

            var apiResponse = await response.Content.ReadAsStringAsync();
            var categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(apiResponse);
            var convertedCategories = categoryResponse?.Categories?.Select(category => category.ToDomainModel());

            _logger.LogTrace("Found {quantity} categories from external API", convertedCategories.Count());

            return convertedCategories;
        }

        public async Task<CoinDomain?> GetCoinInformation(string symbol)
        {
            _logger.LogTrace($"Getting coins from external API");
            using var httpClient = new HttpClient();
            var url = $"{_providerSettings.UrlBase}/quicksilver/universe-currency/symbols/stats/BNB-USDT?lang=en_US";

            using var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("Kucoin provider returned unsuccessful code");
            }

            var apiResponse = await response.Content.ReadAsStringAsync();
            var coinsResponse = JsonConvert.DeserializeObject<CoinResponse>(apiResponse);
            return coinsResponse?.CoinDetails?.ToDomainModel();
        }

        public async Task<IEnumerable<CoinDomain>> GetCoinsByCategory(string categoryId)
        {
            _logger.LogTrace($"Getting coins from external API");
            using var httpClient = new HttpClient();
            using var response =
                await httpClient.GetAsync(
                    $"{_providerSettings.UrlBase}/discover-front/spl?lang=en_US&tagId={categoryId}");

            if (!response.IsSuccessStatusCode)
            {
                // TODO: Leo - I could implement internal log here.
                throw new ApplicationException("Kucoin provider returned unsuccessful code");
            }

            var apiResponse = await response.Content.ReadAsStringAsync();
            var coinsResponse = JsonConvert.DeserializeObject<CoinsResponse>(apiResponse);
            var convertedCoins = coinsResponse?.CoinsWrapper?.Coins?.Select(coin => coin.ToDomainModel());
            _logger.LogTrace("Found {quantity} coins from external API", convertedCoins.Count());

            return convertedCoins;
        }
    }
}