using System;
using System.Threading;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HospitalAPI.HostedServices
{
    public class HostedService : BackgroundService
    {
        private readonly ILogger<HostedService> _logger;
        public IServiceProvider Services { get; }
        
        public HostedService(IServiceProvider services, ILogger<HostedService> logger)
        {
            Services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted Service running.");

            await DoWork(cancellationToken);
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<ITransferCheckerService>();

                await scopedProcessingService.DoWork(cancellationToken);
            }

        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted Service is stopping.");

            await base.StopAsync(cancellationToken);
        }

    }
}
