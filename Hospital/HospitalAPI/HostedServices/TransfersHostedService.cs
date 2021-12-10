using System;
using System.Threading;
using System.Threading.Tasks;
using HospitalClassLibrary.RoomEquipment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HospitalAPI.HostedServices
{
    public class TransfersHostedService : BackgroundService
    {
        private readonly ILogger<TransfersHostedService> _logger;
        public IServiceProvider Services { get; }
        
        public TransfersHostedService(IServiceProvider services, ILogger<TransfersHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service for transfers running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service for transfers is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<ITransferCheckerService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }

        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service for transfers is stopping.");

            await base.StopAsync(stoppingToken);
        }

    }
}
