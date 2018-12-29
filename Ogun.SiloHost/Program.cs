using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ogun.GrainImplementations;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace Ogun.SiloHost
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            return await RunMainAsync();
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                var host = await StartSilo();
                Console.WriteLine("Hit enter to terminate...");
                Console.ReadLine();

                await host.StopAsync();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }

        private static async Task<ISiloHost> StartSilo()
        {
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "Ogun";
                })
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(CustomerActor).Assembly).WithReferences();
                })
                .AddAzureTableGrainStorage("GloballySharedAzureAccount", options=> options.ConnectionString="UseDevelopmentStorage=true")
                .ConfigureLogging(logging => logging.AddConsole());

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
}