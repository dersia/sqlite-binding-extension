using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Models
{
    public class Tag
    {
        public Tag() { }

        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string? TagString { get; set; }
    }
}
