using System;
using System.Threading;
using System.Threading.Tasks;
using HospitalClassLibrary.Renovations.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HospitalAPI.HostedServices
{
    public class RenovationsHostedService : BackgroundService
    {
        private readonly ILogger<RenovationsHostedService> _logger;
        public IServiceProvider Services { get; }

        public RenovationsHostedService(IServiceProvider services, ILogger<RenovationsHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service for renovations running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service for renovations is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IRenovationCheckerService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }

        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Hosted Service for renovations is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
