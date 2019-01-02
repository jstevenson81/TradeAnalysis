using TradeAnalysis.Services.Services.Base.Interfaces;
using TradeAnalysis.Services.Services.Logging;

namespace TradeAnalysis.Services.DependencyInjection.Interfaces
{
    public interface IServiceFactory
    {
        TService Create<TService>(ILogger log) where TService : IService;
    }
}