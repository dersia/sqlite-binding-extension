using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SiaConsulting.Azure.WebJobs.Extensions.GitExtension.Config
{
    public static class WebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddGitExtension(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}
