using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unibet.InterfaceLibrary;

namespace GetRatesWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConfiguration config;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            config = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var getRatesWorker = Program.container.Resolve<IGetRatesWorker>();
                string baseUri = config["ApiBaseUrl"];
                string apiKey = config["ApiKey"];
                getRatesWorker.RefreshRatesFromApiAsync(baseUri, apiKey);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
