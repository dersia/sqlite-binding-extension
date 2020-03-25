using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs;
using SiaConsulting.Azure.WebJobs.Extensions.GitExtension;
using SiaConsulting.Azure.WebJobs.Extensions.GitExtension.Config;

[assembly: WebJobsStartup(typeof(GitExtensionWebJobsStartup))]
namespace SiaConsulting.Azure.WebJobs.Extensions.GitExtension
{
    public class GitExtensionWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) 
            => builder.AddGitExtension();
    }
}
