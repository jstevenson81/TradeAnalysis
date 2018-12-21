using System.Threading.Tasks;
using TradeAnalysis.Services.Services.Logging;

namespace TradeAnalysis.Services.Services.Base.Interfaces
{
    public interface IService
    {
        ILogger Log { get; set; }
        Task<TOutput> InvokeAsync<TInput, TOutput>(TInput input);

        Task<TOutput> InvokeAsyncWithConfig<TInput, TOutput, TConfig>
            (TInput input, Microsoft.Azure.WebJobs.ExecutionContext context, string configFileName, string section) where TConfig : IServiceConfig;
    }
}