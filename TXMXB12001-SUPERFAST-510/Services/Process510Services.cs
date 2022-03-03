using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TXMXB12001_SUPERFAST_510.Business;

namespace TXMXB12001_SUPERFAST_510.Services
{
    public class Process510Services : IHostedService, IDisposable
    {
        Process procesos = new Process();
        File510Process Process = new File510Process();
        
        private System.Threading.Timer timer;

        public Task StartAsync(CancellationToken stoppingToken)
        {
            //AppSettings_Internal.Init();
            TXMXB12001_SUPERFAST_510.Helpers.AppSettings.AppSettings.Init();
            timer = new System.Threading.Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(Convert.ToInt32(TXMXB12001_SUPERFAST_510.Helpers.AppSettings.AppSettings.CorreProceso())));

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken stoppingToken)
        {

            return Task.CompletedTask;
        }
        public void Dispose()
        {
        }
        private void DoWork(object state)
        {
            Process.Execute();
            //procesos.Hola();
        }
    }
}
