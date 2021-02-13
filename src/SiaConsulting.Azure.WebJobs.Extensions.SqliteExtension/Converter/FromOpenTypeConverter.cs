using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Converter
{
    public class FromOpenTypeConverter<T> : IConverter<Tag, T>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public FromOpenTypeConverter(Microsoft.Extensions.Logging.ILogger logger) 
            => _logger = logger;

        public T Convert(Tag input)
            => JsonConvert.DeserializeObject<T>(input.TagString);
    }

    public class FromOpenTypeListConverter<T> : IConverter<IList<Tag>, IList<T>>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public FromOpenTypeListConverter(Microsoft.Extensions.Logging.ILogger logger)
            => _logger = logger;

        public IList<T> Convert(IList<Tag> input)
            => input.Select(i => JsonConvert.DeserializeObject<T>(i.TagString)).ToList();
    }
}
