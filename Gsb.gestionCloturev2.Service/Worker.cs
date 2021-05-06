using Gsb.gestionCloturev2.logic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gsb.gestionCloturev2.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private const int uneJourne = 1000 * 60; //24*60*60*1000; // a modifier pour la durée d'execution

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ClotureLogic toto = new ClotureLogic();

                toto.clotureFicheFrais();
                toto.miseEnRemboursement();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(uneJourne, stoppingToken);

            }
        }
    }
}
