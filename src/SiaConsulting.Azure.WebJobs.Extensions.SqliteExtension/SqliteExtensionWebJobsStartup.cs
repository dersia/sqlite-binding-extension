using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Config;

[assembly: WebJobsStartup(typeof(SqliteExtensionWebJobsStartup))]
namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension
{
    public class SqliteExtensionWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) 
            => builder.AddSqliteExtension();
    }
}
