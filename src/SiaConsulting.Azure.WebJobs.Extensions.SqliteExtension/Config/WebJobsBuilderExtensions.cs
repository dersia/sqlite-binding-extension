using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Config
{
    public static class WebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddSqliteExtension(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            builder.AddExtension<SqliteExtensionConfigProvider>();
            return builder;
        }
    }
}
