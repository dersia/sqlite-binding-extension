using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using System;
using CustomBindingsTemplate.Bindings;
using CustomBindingsTemplate.Converter;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Collections.Generic;

namespace CustomBindingsTemplate.Config
{
    [Extension(nameof(MYBINDING))]
    public class CustomBindingsTemplate_ConfigProvider : IExtensionConfigProvider
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public CustomBindingsTemplate_ConfigProvider(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(MYBINDING));
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var MYBINDINGRULE = context.AddBindingRule<MYATTRIBUTE>();
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
