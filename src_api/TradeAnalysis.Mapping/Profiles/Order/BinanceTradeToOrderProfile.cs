using AutoMapper;
using Binance.Net.Objects;

namespace TradeAnalysis.Mapping.Profiles.Order
{
    public class BinanceOrderToOrder: Profile
    {
        public BinanceOrderToOrder()
        {
            CreateMap<BinanceOrder, Models.Order>()
                .ForMember(dest => dest.ExchangeOrderId, mapper => mapper.MapFrom(source => source.OrderId))
                .ForMember(dest => dest.Id, mapper => mapper.Ignore())
                .ForMember(dest => dest.Trades, mapper => mapper.Ignore())
                ;
        }
    }
}