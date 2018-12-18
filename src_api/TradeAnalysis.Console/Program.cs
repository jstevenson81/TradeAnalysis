using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Binance.Net.Objects;
using CryptoExchange.Net.Authentication;
using Newtonsoft.Json;
using TradeAnalysis.Mapping.Extensions;
using TradeAnalysis.Mapping.Profiles;
using TradeAnalysis.Models;

namespace TradeAnalysis.Console.App
{
    class Program
    {


        static async Task Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfiles(typeof(BinanceApiToDomainProfiles)));
            Mapper.AssertConfigurationIsValid();
            var apiConfig = new ApiConfig
            {
                Key = "ugtxwhvBupdGSB8TTRZHycrueFEeXoDKiErrn0ayrxRpBs7xpOEyfUInKIzK2U6W",
                Secret = "1zxsoSHKaOKDTNvIdle5UYOhy2l09D4gF4CLuxM7sD9q2JY8gHvSmJv9tB5GqdP7"
            };

            var client = new Binance.Net.BinanceClient(
                new BinanceClientOptions {ApiCredentials = new ApiCredentials(apiConfig.Key, apiConfig.Secret)});

            var trades = await client.GetMyTradesAsync("BCHSVUSDT");
            var orders = await client.GetAllOrdersAsync("BCHSVUSDT", 7617563);

            var myOrders = Mapper.Map<List<Order>>(orders.Data);
            var myTrades = Mapper.Map<List<Trade>>(trades.Data);

            foreach (var myTrade in myTrades.OrderBy(x => x.ExchangeOrderId))
            {
                var order = myOrders.FirstOrDefault(x => x.ExchangeOrderId.Equals(myTrade.ExchangeOrderId));
                if (order != null && !order.Trades.Any(x => x.ExchangeTradeId.Equals(myTrade.ExchangeTradeId)))
                {
                    order.Trades.Add(myTrade);
                }
            }

            System.Console.WriteLine(myOrders.Serialize(Formatting.Indented));


        }
    }
}
