using AutoMapper;
using Binance.Net.Objects;

namespace TradeAnalysis.Mapping.Profiles.Trade
{
    public class BinanceTradeToTrade : Profile
    {
        public BinanceTradeToTrade()
        {
            CreateMap<BinanceTrade, Models.Trade>()
                .ForMember(dest => dest.ExchangeOrderId, mapper => mapper.MapFrom(source => source.OrderId))
                .ForMember(dest => dest.ExchangeTradeId, mapper => mapper.MapFrom(source => source.Id))
                .ForMember(dest => dest.Id, mapper => mapper.Ignore())
                .ForMember(dest => dest.OrderId, mapper => mapper.Ignore())
                ;
        }
    }
}
