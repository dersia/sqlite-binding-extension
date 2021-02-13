using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Models;
using System.Dynamic;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Converter
{
    public static class CommonConverter
    {
        public static ExtensionConfigContext AddAll_MYDATATYPE_Converters(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger) 
            => context
                .AddStringTo_MYDATATYPE_Converter(logger)
                .AddJObjectTo_MYDATATYPE_Converter(logger)
                .AddExpandoObjectTo_MYDATATYPE_Converter(logger)
                .Add_MYDATATYPE_ToJObjectConverter(logger)
                .Add_MYDATATYPE_ToStringConverter(logger)
                .AddJObecjtToStringConverter(logger)
                .AddStringToJObjectConverter(logger);

        private static ExtensionConfigContext AddStringTo_MYDATATYPE_Converter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<string, Tag>((value, attr) => new Tag { TagString = value });

        public static ExtensionConfigContext AddJObjectTo_MYDATATYPE_Converter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<JObject?, Tag?>(payload => JsonConvert.DeserializeObject<Tag>(payload?.ToString()));

        public static ExtensionConfigContext AddExpandoObjectTo_MYDATATYPE_Converter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<ExpandoObject?, Tag?>(payload => JsonConvert.DeserializeObject<Tag>((JsonConvert.SerializeObject(payload))));

        public static ExtensionConfigContext Add_MYDATATYPE_ToJObjectConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<Tag?, JObject?>(JObject.FromObject);

        private static ExtensionConfigContext Add_MYDATATYPE_ToStringConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<Tag?, string?>(value => value?.TagString);

        public static ExtensionConfigContext AddJObecjtToStringConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<JObject?, string?>(v => v?.ToString());

        public static ExtensionConfigContext AddStringToJObjectConverter(this ExtensionConfigContext context, Microsoft.Extensions.Logging.ILogger logger)
            => context.AddConverter<string?, JObject?>(JObject.Parse);


    }
}
