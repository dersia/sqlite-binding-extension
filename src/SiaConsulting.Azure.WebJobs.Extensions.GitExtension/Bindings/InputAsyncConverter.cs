using Microsoft.Azure.WebJobs;
using System.Threading;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.GitExtension.Bindings
{
    public class InputAsyncConverter : IAsyncConverter<GitAttribute, RESULTINGTYPE>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public InputAsyncConverter(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;
        }

        public Task<RESULTINGTYPE> ConvertAsync(GitAttribute config, CancellationToken cancellationToken)
        {
            return Task.FromResult<RESULTINGTYPE>(null);
        }
    }
}
