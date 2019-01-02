using System;
using Microsoft.Extensions.DependencyInjection;
using TradeAnalysis.Services.DependencyInjection.Interfaces;
using TradeAnalysis.Services.Services.Base.Interfaces;
using TradeAnalysis.Services.Services.Logging;

namespace TradeAnalysis.Services.DependencyInjection
{
    public class CoreServiceFactory: IServiceFactory
    {
        private readonly IServiceProvider _container;

        public CoreServiceFactory(IModule module = null)
        {
            _container = new ContainerBuilder().RegisterModule(module).Build();
        }


        public TService Create<TService>(ILogger log) where TService : IService
        {
            var service = _container.GetService<TService>();
            service.Log = log;
            return service;
        }
    }
}
