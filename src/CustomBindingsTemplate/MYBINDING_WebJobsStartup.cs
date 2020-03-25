using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs;
using CustomBindingsTemplate;
using CustomBindingsTemplate.Config;

[assembly: WebJobsStartup(typeof(MYBINDING_WebJobsStartup))]
namespace CustomBindingsTemplate
{
    public class MYBINDING_WebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) 
            => builder.Add_MYBINDING_NAME();
    }
}
