﻿using System.Collections.Generic;
using System.Fabric;
using Microsoft.Extensions.Logging;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Ogun.GrainImplementations;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Hosting.ServiceFabric;

namespace Ogun.SfHost.Service
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class Service : StatelessService
    {
        public Service(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            var listener = OrleansServiceListener.CreateStateless((sfContext, builder) =>
                {
                    builder.Configure<ClusterOptions>(options =>
                    {
                        // The service id will be unique for the entire service's lifetime. It is used to identify persistent state for reminders and grain state.
                        options.ServiceId = sfContext.ServiceName.ToString();

                        // ClusterId identifies a deployed cluster. Used to Identify which silos belong to a particular cluster
                        options.ClusterId = "dev";
                    });


                    // Configure Azure storage as the clustering provider. Could use sql in the future.
                    builder.UseAzureStorageClustering(
                        options => options.ConnectionString = "UseDevelopmentStorage=true");

                    // configure logging
                    builder.ConfigureLogging(logging =>
                    {
                        logging.AddDebug();
                    });

                    // As SF manages port allocation, use the ports defined.
                    var activation = sfContext.CodePackageActivationContext;
                    var endpoints = activation.GetEndpoints();

                    // These endpoint names correspond to TCP endpoints specified in the manifest.
                    var siloEndpoint = endpoints["OrleansSiloEndpoint"];
                    var gatewayEndpoint = endpoints["OrleansProxyEndpoint"];
                    var hostname = sfContext.NodeContext.IPAddressOrFQDN;
                    builder.ConfigureEndpoints(hostname, siloEndpoint.Port, gatewayEndpoint.Port);

                    // Add grain assemblies
                    builder.ConfigureApplicationParts(parts =>
                        {
                            parts.AddApplicationPart(typeof(CustomerActor).Assembly).WithReferences();

                            // Alternative: Add all loadable assemblies in the current base path.
                            // tldr:; Seem to need to do this if loading Initing OrleansDashboard. As it seems to break "AddApplicationPart" . 
                            parts.AddFromApplicationBaseDirectory();
                        });


                });

            return new[]{listener};
        }
    }
}
