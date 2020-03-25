using Microsoft.Azure.WebJobs.Description;
using System;

namespace SiaConsulting.Azure.WebJobs.Extensions.GitExtension
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class GitAttribute : Attribute
    {
        public GitAttribute() { }

        [AppSetting]
        public string GitRemoteUrl { get; set; }
    }
}
