using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomBindingsTemplate.Config
{
    public static class WebJobsBuilderExtensions
    {
        public static IWebJobsBuilder Add_MYBINDING_NAME(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}
