using AutoMapper;
using Binance.Net.Objects;
using TradeAnalysis.Data;

namespace TradeAnalysis.Mapping.Profiles
{
    public class BinanceApiToDomainProfiles: Profile
    {
        public BinanceApiToDomainProfiles()
        {
            CreateMap<BinanceOrder, Order>()
                .ForMember(dest => dest.ExchangeOrderId, mapper => mapper.MapFrom(source => source.OrderId))
                .ForMember(dest => dest.Id, mapper => mapper.Ignore())
                .ForMember(dest => dest.Trades, mapper => mapper.Ignore())
                ;

            CreateMap<BinanceTrade, Trade>()
                .ForMember(dest => dest.ExchangeOrderId, mapper => mapper.MapFrom(source => source.OrderId))
                .ForMember(dest => dest.ExchangeTradeId, mapper => mapper.MapFrom(source => source.Id))
                .ForMember(dest => dest.Id, mapper => mapper.Ignore())
                .ForMember(dest => dest.OrderId, mapper => mapper.Ignore())
                ;

        }
    }
}
