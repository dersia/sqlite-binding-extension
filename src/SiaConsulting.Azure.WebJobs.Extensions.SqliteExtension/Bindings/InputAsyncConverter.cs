using Microsoft.Azure.WebJobs;
using SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Models;
using SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Bindings
{
    public class InputAsyncConverter : IAsyncConverter<SqliteAttribute, Tag>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public InputAsyncConverter(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;
        }

        public async Task<Tag> ConvertAsync(SqliteAttribute config, CancellationToken cancellationToken)
        {
            var connection = new SQLiteAsyncConnection(config.ConnectionString);
            await connection.CreateTableAsync<Tag>();
            var result =  await connection.GetAsync<Tag>(config.EntityId).ConfigureAwait(false);
            await connection.CloseAsync().ConfigureAwait(false);
            return result;
        }
    }
}
