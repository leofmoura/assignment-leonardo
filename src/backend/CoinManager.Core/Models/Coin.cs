using System;

namespace CoinManager.Core.Models
{
    public class Coin
    {
        public Coin(string symbolCode, string alternateSymbolCode, string? symbolDisplay, string name, decimal price, decimal priceChange, decimal priceDiff, string? urlImage, decimal marketCap)
        {
            SymbolCode = symbolCode ?? throw new ArgumentNullException(nameof(symbolCode));
            AlternateSymbolCode = alternateSymbolCode ?? throw new ArgumentNullException(nameof(alternateSymbolCode));
            SymbolDisplay = symbolDisplay ?? symbolCode;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            PriceChange = priceChange;
            PriceDiff = priceDiff;
            UrlImage = urlImage;
            MarketCap = marketCap;
        }

        public string SymbolCode { get; set; }
        public string AlternateSymbolCode { get; set; }
        public string SymbolDisplay { get; set; }
        public string Name { get; set; }
        public string? UrlImage { get; set; }
        public decimal Price { get; set; }
        public decimal PriceChange { get; set; }
        public decimal PriceDiff { get; set; }
        public decimal MarketCap { get; set; }
        
    }
}