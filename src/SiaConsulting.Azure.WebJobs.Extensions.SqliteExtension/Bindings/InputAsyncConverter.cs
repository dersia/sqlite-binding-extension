using Microsoft.Azure.WebJobs;
using System.Threading;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.SqliteExtension.Bindings
{
    public class InputAsyncConverter : IAsyncConverter<SqliteAttribute, RESULTINGTYPE>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public InputAsyncConverter(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;
        }

        public Task<RESULTINGTYPE> ConvertAsync(SqliteAttribute config, CancellationToken cancellationToken)
        {
            return Task.FromResult<RESULTINGTYPE>(null);
        }
    }
}
