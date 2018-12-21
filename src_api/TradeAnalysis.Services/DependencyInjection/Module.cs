using Microsoft.Extensions.DependencyInjection;
using TradeAnalysis.Services.DependencyInjection.Interfaces;

namespace TradeAnalysis.Services.DependencyInjection
{
    public class Module : IModule
    {
        public virtual void Load(IServiceCollection services)
        {
        }
    }
}