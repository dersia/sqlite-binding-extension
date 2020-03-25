using Microsoft.Azure.WebJobs;
using System.Threading;
using System.Threading.Tasks;

namespace CustomBindingsTemplate.Bindings
{
    public class InputAsyncConverter : IAsyncConverter<MYATTRIBUTE, RESULTINGTYPE>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public InputAsyncConverter(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;
        }

        public Task<RESULTINGTYPE> ConvertAsync(MYATTRIBUTE config, CancellationToken cancellationToken)
        {
            return Task.FromResult<RESULTINGTYPE>(null);
        }
    }
}
