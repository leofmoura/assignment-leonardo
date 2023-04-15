using CoinManager.Application.Coins;
using CoinManager.Application.Providers;
using CoinManager.Core.Models;
using Moq;
using FluentAssertions;

namespace CoinManager.Application.Tests;

public class CoinServiceTests
{
    private Mock<IPrimaryCoinProvider> primaryProvider = new Mock<IPrimaryCoinProvider>();
    private Mock<ISecondaryCoinProvider> secondaryProvider = new Mock<ISecondaryCoinProvider>();

    [Fact]
    public async Task GetAggregateCoinsByCategory_When_SecondaryIsEmpty_ShouldSecondaryPropsBeNull()
    {
        IEnumerable<Coin> coins = new List<Coin>() { GetBTCCoinTest() };
        // Arrange
        var _sut = new CoinService(primaryProvider.Object, secondaryProvider.Object);
        primaryProvider
            .Setup(p => p.GetCoinsByCategory(It.IsAny<string>()))
            .ReturnsAsync(coins);

        // Act
        var aggregateCoins = await _sut.GetAggregateCoinsByCategory("anyCode");
        // Asset
        aggregateCoins.Should().NotBeNullOrEmpty();
        aggregateCoins.First().SecondaryPrice.Should().BeNull();
        aggregateCoins.First().SecondaryPriceChange.Should().BeNull();
    }
    
    [Fact]
    public async Task GetAggregateCoinsByCategory_When_SecondaryIsNotEmpty_ShouldSecondaryPropsNotBeNull()
    {
        var btcCoin = GetBTCCoinTest();
        IEnumerable<Coin> coins = new List<Coin>() { btcCoin };
        // Arrange
        var _sut = new CoinService(primaryProvider.Object, secondaryProvider.Object);
        primaryProvider
            .Setup(p => p.GetCoinsByCategory(It.IsAny<string>()))
            .ReturnsAsync(coins);
        
        secondaryProvider
            .Setup(p => p.GetCoinInformation(It.IsAny<string>()))
            .ReturnsAsync(GetBTCCoinTest);
        
        // Act
        var aggregateCoins = await _sut.GetAggregateCoinsByCategory("anyCode");
        // Asset
        aggregateCoins.Should().NotBeNullOrEmpty();
        aggregateCoins.First().SecondaryPrice.Should().Be(btcCoin.Price);
        aggregateCoins.First().SecondaryPriceChange.Should().Be(btcCoin.PriceChange);
    }

    private Coin GetBTCCoinTest()
    {
        return new Coin("BTC-USDT", "BTC", "BTC", "BitCoin", (decimal)20032.99,
            (decimal)29.99, (decimal)292.00, "", Decimal.Zero);
    }
}