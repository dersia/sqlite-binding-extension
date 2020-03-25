using Microsoft.Azure.WebJobs.Description;
using System;

namespace CustomBindingsTemplate
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class MYATTRIBUTE : Attribute
    {
        public MYATTRIBUTE() { }

        [AppSetting]
        public string MYSETTING { get; set; }
    }
}
