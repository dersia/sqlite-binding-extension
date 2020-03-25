using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.GitExtension.Bindings
{
    public class OutputAsyncCollector : IAsyncCollector<MYDATATYPE>, IDisposable
    {
        private readonly ILogger _logger;
        private readonly GitAttribute _config;

        public OutputAsyncCollector(GitAttribute config, Microsoft.Extensions.Logging.ILogger logger)
        {
            _config = config;
            _logger = logger;
        }

        public Task AddAsync(MYDATATYPE data, CancellationToken cancellationToken = default)
        {
            
        }

        public async Task FlushAsync(CancellationToken cancellationToken = default)
        {
            
        }

        public void Dispose()
        {
        }
    }
}
