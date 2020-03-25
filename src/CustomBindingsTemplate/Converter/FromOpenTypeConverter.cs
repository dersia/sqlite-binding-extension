using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace CustomBindingsTemplate.Converter
{
    public class FromOpenTypeConverter<T> : IConverter<MYDATATYPE, T>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public FromOpenTypeConverter(Microsoft.Extensions.Logging.ILogger logger) 
            => _logger = logger;

        public T Convert(MYDATATYPE input)
            => JsonConvert.DeserializeObject<T>(input.Value);
    }

    public class FromOpenTypeListConverter<T> : IConverter<IList<MYDATATYPE>, IList<T>>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public FromOpenTypeListConverter(Microsoft.Extensions.Logging.ILogger logger)
            => _logger = logger;

        public IList<T> Convert(IList<MYDATATYPE> input)
            => input.Select(i => input.T).ToList();
    }
}
