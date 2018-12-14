using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TradeAnalysis.Mapping.Extensions
{
    public static class JsonExtensions
    {
        public static string Serialize(this object obj, Formatting formatting)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = formatting,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
