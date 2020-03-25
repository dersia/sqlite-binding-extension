using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace CustomBindingsTemplate.Converter
{
    public static class CommonConverter
    {
        public static ExtensionConfigContext AddAll_MYDATATYPE_Converters(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger) 
            => context
                .AddStringTo_MYDATATYPE_Converter(logger)
                .AddJObjectTo_MYDATATYPE_Converter(logger)
                .AddDynamicTo_MYDATATYPE_Converter(logger)
                .AddExpandoObjectTo_MYDATATYPE_Converter(logger)
                .Add_MYDATATYPE_ToJObjectConverter(logger)
                .Add_MYDATATYPE_ToStringConverter(logger)
                .AddJObecjtToStringConverter(logger)
                .AddStringToJObjectConverter(logger);

        private static ExtensionConfigContext AddStringTo_MYDATATYPE_Converter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<string, MYDATATYPE>((value, attr) => new MYDATATYPE());

        public static ExtensionConfigContext AddJObjectTo_MYDATATYPE_Converter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<JObject?, MYDATATYPE?>(payload => JsonConvert.DeserializeObject<MYDATATYPE>(payload?.ToString()));

        public static ExtensionConfigContext AddDynamicTo_MYDATATYPE_Converter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<dynamic?, MYDATATYPE?>(payload => JsonConvert.DeserializeObject<MYDATATYPE>((JsonConvert.SerializeObject(payload))));

        public static ExtensionConfigContext AddExpandoObjectTo_MYDATATYPE_Converter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<ExpandoObject?, MYDATATYPE?>(payload => JsonConvert.DeserializeObject<MYDATATYPE>((JsonConvert.SerializeObject(payload))));

        public static ExtensionConfigContext Add_MYDATATYPE_ToJObjectConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<MYDATATYPE?, JObject?>(JObject.FromObject);

        private static ExtensionConfigContext Add_MYDATATYPE_ToStringConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<MYDATATYPE?, string?>(value => value?.Value);

        public static ExtensionConfigContext AddJObecjtToStringConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<JObject?, string?>(v => v?.ToString());

        public static ExtensionConfigContext AddStringToJObjectConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<string?, JObject?>(JObject.Parse);


    }
}
