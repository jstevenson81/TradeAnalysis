using Microsoft.Extensions.DependencyInjection;

namespace TradeAnalysis.Services.DependencyInjection.Interfaces
{
    public interface IModule
    {
        void Load(IServiceCollection services);
    }
}