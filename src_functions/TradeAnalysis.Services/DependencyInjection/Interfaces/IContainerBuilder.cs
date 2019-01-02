using System;

namespace TradeAnalysis.Services.DependencyInjection.Interfaces
{
    public interface IContainerBuilder
    {
        IContainerBuilder RegisterModule(IModule module = null);

        IServiceProvider Build();
    }
}
