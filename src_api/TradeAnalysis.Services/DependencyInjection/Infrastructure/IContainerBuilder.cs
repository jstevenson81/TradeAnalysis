using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace TradeAnalysis.Services.DependencyInjection.Infrastructure
{
    public interface IContainerBuilder
    {
        IContainerBuilder RegisterModule(IModule module = null);

        IServiceProvider Build();
    }

    public class ContainerBuilder : IContainerBuilder
    {
        private readonly IServiceCollection _services;

        public ContainerBuilder()
        {
            this._services = new ServiceCollection();
        }

        public IContainerBuilder RegisterModule(IModule module = null)
        {
            if (module == null)
            {
                module = new Module();
            }

            module.Load(this._services);

            return this;
        }

        public IServiceProvider Build()
        {
            var provider = this._services.BuildServiceProvider();

            return provider;
        }
    }

    public interface IModule
    {
        void Load(IServiceCollection services);
    }

    public class Module : IModule
    {
        public virtual void Load(IServiceCollection services)
        {
            return;
        }
    }

    public class CoreAppModule : Module
    {
        public override void Load(IServiceCollection services)
        {
        }
    }
}
