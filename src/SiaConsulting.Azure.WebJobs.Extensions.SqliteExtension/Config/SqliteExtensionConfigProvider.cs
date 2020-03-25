using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using System;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Bindings;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Converter;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Collections.Generic;

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
            MYBINDINGRULE.BindToInput<RESULTINGTYPE>(new InputAsyncConverter(_logger));
            MYBINDINGRULE.BindToCollector<MYDATATYPE>(config => new OutputAsyncCollector(config, _logger));
            context.AddAll_MYDATATYPE_Converters(_logger);
            context.AddOpenConverter<MYDATATYPE, OpenType>(typeof(FromOpenTypeConverter<>), _logger);
            context.AddOpenConverter<IList<MYDATATYPE>, IList<OpenType>>(typeof(FromOpenTypeListConverter<>), _logger);
            context.AddOpenConverter<OpenType, MYDATATYPE>(typeof(ToOpenTypeConverter<>), _logger);
            context.AddOpenConverter< IList<OpenType>, IList<MYDATATYPE>>(typeof(ToOpenTypeListConverter<>), _logger);
        }
    }
}
