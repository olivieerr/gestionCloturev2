using Gsb.gestionCloturev2.logic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gsb.gestionCloturev2.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private const int JOURNEE = 1000 * 60; //24*60*60*1000 correspond à 24h; // a modifier pour la durée d'execution

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ClotureLogic service = new ClotureLogic();

                service.clotureFicheFrais();
                service.miseEnRemboursement();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(JOURNEE, stoppingToken);

            }
        }
    }
}
