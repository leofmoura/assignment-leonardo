using System.Net.Http.Json;
using CoinManager.Application.Providers;
using CoinManager.Infrastructure.Gateio.Models;
using CoinDomain = CoinManager.Core.Models.Coin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoinManager.Infrastructure.Gateio
{
    public class GateioAPIProvider : ISecondaryCoinProvider
    {
        private readonly ILogger<GateioAPIProvider> _logger;
        private readonly ProviderSettings _providerSettings;

        public GateioAPIProvider(ILogger<GateioAPIProvider> logger, IConfiguration configuration)
        {
            _logger = logger;
            var primarySettings = configuration.GetSection("ApiProviders");
            _providerSettings = new ProviderSettings()
            {
                Name = primarySettings.GetSection(APIProviders.Secondary)["name"],
                UrlBase = primarySettings.GetSection(APIProviders.Secondary)["urlBase"]
            };
        }

        public async Task<CoinDomain?> GetCoinInformation(string symbol)
        {
            _logger.LogTrace($"Getting coins from external API");
            using var httpClient = new HttpClient();
            var url = $"{_providerSettings.UrlBase}/apiwap/getCoinInfo";
            var formContentParams = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("curr_type", symbol),
            });
            using var response = await httpClient.PostAsync(url, formContentParams);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("Gateio provider returned unsuccessful code");
            }

            var apiResponse = await response.Content.ReadAsStringAsync();
            var coinsResponse = JsonConvert.DeserializeObject<CoinResponse>(apiResponse);
            return coinsResponse?.CoinsWrapper?.Coin?.ToDomainModel();
        }
    }
}