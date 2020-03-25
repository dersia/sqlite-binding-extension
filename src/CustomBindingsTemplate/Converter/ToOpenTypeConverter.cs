using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CustomBindingsTemplate.Converter
{
    public class ToOpenTypeConverter<T> : IConverter<T, MYDATATYPE>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public ToOpenTypeConverter(Microsoft.Extensions.Logging.ILogger logger) 
            => _logger = logger;

        public MYDATATYPE Convert(T input) 
            => JsonConvert.SerializeObject(input);
    }

    public class ToOpenTypeListConverter<T> : IConverter<IList<T>, IList<MYDATATYPE>>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public ToOpenTypeListConverter(Microsoft.Extensions.Logging.ILogger logger) 
            => _logger = logger;

        public IList<MYDATATYPE> Convert(IList<T> input)
            => input.Select(i => new MYDATATYPE(input)).ToList();
    }
}
