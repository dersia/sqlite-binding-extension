using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Converter
{
    public class ToOpenTypeConverter<T> : IConverter<T, Tag>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public ToOpenTypeConverter(Microsoft.Extensions.Logging.ILogger logger) 
            => _logger = logger;

        public Tag Convert(T input) 
            => new Tag { TagString = JsonConvert.SerializeObject(input) };
    }

    public class ToOpenTypeListConverter<T> : IConverter<IList<T>, IList<Tag>>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public ToOpenTypeListConverter(Microsoft.Extensions.Logging.ILogger logger) 
            => _logger = logger;

        public IList<Tag> Convert(IList<T> input)
            => input.Select(i => new Tag { TagString = JsonConvert.SerializeObject(input) }).ToList();
    }
}
