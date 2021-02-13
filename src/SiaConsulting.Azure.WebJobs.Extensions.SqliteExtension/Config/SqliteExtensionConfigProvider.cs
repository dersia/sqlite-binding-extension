using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using System;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Bindings;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Converter;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Collections.Generic;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Models;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Config
{
    [Extension("Sqlite")]
    public class SqliteExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public SqliteExtensionConfigProvider(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("Sqlite");
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var MYBINDINGRULE = context.AddBindingRule<SqliteAttribute>();
            MYBINDINGRULE.BindToInput<Tag>(new InputAsyncConverter(_logger));
            MYBINDINGRULE.BindToCollector<Tag>(config => new OutputAsyncCollector(config, _logger));
            context.AddAll_MYDATATYPE_Converters(_logger);
            context.AddOpenConverter<Tag, OpenType>(typeof(FromOpenTypeConverter<>), _logger);
            context.AddOpenConverter<IList<Tag>, IList<OpenType>>(typeof(FromOpenTypeListConverter<>), _logger);
            context.AddOpenConverter<OpenType, Tag>(typeof(ToOpenTypeConverter<>), _logger);
            context.AddOpenConverter< IList<OpenType>, IList<Tag>>(typeof(ToOpenTypeListConverter<>), _logger);
        }
    }
}
