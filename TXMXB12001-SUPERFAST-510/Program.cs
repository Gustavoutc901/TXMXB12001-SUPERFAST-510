using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TXMXB12001_SUPERFAST_510.Services;

namespace TXMXB12001_SUPERFAST_510
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Process510Services>();
                })
                .Build())
            {
                await host.StartAsync();
                await host.WaitForShutdownAsync();

            }
        }
    }
}
