using Microsoft.Azure.WebJobs.Description;
using System;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class SqliteAttribute : Attribute
    {
        public SqliteAttribute() { }

        [AppSetting]
        public string ConnectionString { get; set; }
        public string EntityId { get; set; }
    }
}
