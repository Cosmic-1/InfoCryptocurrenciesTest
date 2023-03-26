using CoincapLibrary;


var assets = new AssetsPrice();
var assetsData = await assets.GetCryptocurrenciesAsync(limit:100, offset:0);
var assetsData1 = await assets.GetCryptocurrencyAsync("bitcoin");
var assetsData2 = await assets.GetCryptocurrencyMarketsAsync("bitcoin");
var assetsData3 = await assets.GetCryptocurrencyHistoryAsync("bitcoin", TimeInterval.OneDay);

var cryptocurrencyExchanges = new CryptocurrencyExchanges();
var cryptocurrencyExchangesData = await cryptocurrencyExchanges.GetExchangesAsync();
var cryptocurrencyExchangesData1 = await cryptocurrencyExchanges.GetSingleExchangeAsync("binance");

var filterMarket = new FilterMarkets();
var filterMarketData = await filterMarket.GetMarketsAsync(
    exchangeId: "binance",
    assetSymbol: "BTC",
    assetId: "bitcoin",
    limit: 1000,
    offset: 0);

var moneyRates = new MoneyRates();
var moneyRatesData = await moneyRates.GetMoneyAsync();
var moneyRatesData1 = await moneyRates.GetSingleMoneyAsync("turkmenistani-manat");

Console.WriteLine();