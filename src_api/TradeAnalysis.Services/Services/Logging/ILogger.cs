using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeAnalysis.Services.Services.Logging
{
    public interface ILogger
    {
        void Log(IServiceLog log);
        Task LogAsync(IServiceLog log);
    }

    public interface IServiceLog
    {
        Exception Exception { get; set; }
        Severity Severity { get; set; }
        string Message { get; set; }
        Dictionary<string, object> CustomData { get; set; }
        IList<string> Tags { get; set; }
    }

    public enum Severity
    {
        Info = 0,
        Debug = 1,
        Severe = 2,
        Critical = 3
    }
}
