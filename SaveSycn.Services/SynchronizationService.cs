using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SaveSycn.Services
{
    public class SynchronizationService : IHostedService
    {
        private readonly ILogger<SynchronizationService> logger;

        public SynchronizationService(
            IOptions<SynchronizationServiceOptions> options, 
            ILogger<SynchronizationService> logger)
        {
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
