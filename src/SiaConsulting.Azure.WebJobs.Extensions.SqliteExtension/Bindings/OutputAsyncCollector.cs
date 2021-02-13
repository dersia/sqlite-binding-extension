using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Bindings
{
    public class OutputAsyncCollector : IAsyncCollector<Tag>, IDisposable
    {
        private readonly ILogger _logger;
        private readonly SqliteAttribute _config;
        private readonly List<Tag> _transaction = new List<Tag>();

        public OutputAsyncCollector(SqliteAttribute config, Microsoft.Extensions.Logging.ILogger logger)
        {
            _config = config;
            _logger = logger;
        }

        public Task AddAsync(Tag data, CancellationToken cancellationToken = default)
        {
            _transaction.Add(data);
            return Task.CompletedTask;
        }

        public async Task FlushAsync(CancellationToken cancellationToken = default)
        {
            var connection = new SQLiteAsyncConnection(_config.ConnectionString);
            await connection.CreateTableAsync<Tag>().ConfigureAwait(false);
            await connection.InsertAllAsync(_transaction, true).ConfigureAwait(false);
            await connection.CloseAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
        }
    }
}
