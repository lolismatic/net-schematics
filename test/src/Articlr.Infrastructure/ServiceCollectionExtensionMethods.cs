// <copyright file="ServiceCollectionExtensionMethods.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Infrastructure
{
    using System;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using MongoDB.Driver;

    using Articlr.Application.Persistence;
    using Articlr.Infrastructure.Persistence;

    /// <summary>
    /// The service collection extension methods.
    /// </summary>
    public static class ServiceCollectionExtensionMethods
    {
        /// <summary>
        /// The default configuration.
        /// </summary>
        private static readonly Action<InfrastructureConfiguration> DefaultConfiguration = configuration =>
            {

            };

        /// <summary>
        /// The add infrastructure.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <returns>
        /// The <see cref="IServiceCollection"/>.
        /// </returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ILogger logger, Action<InfrastructureConfiguration> configuration = null)
        {
            logger.LogInformation("Started configuring infrastructure services...");

            configuration = configuration ?? DefaultConfiguration;

            services.Configure(configuration);

            services.AddScoped(MongoClientFactory);
            services.AddScoped<IMongoUtilities, MongoUtilities>();
            services.AddScoped<IRepository, MongoRepository>();

            logger.LogInformation("Finished configuring infrastructure services...");

            return services;
        }


        /// <summary>
        /// The mongo factory.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service Provider.
        /// </param>
        /// <returns>
        /// New Mongo Database instance.
        /// </returns>
        private static IMongoDatabase MongoClientFactory(IServiceProvider serviceProvider)
        {
            var mongoConfiguration = serviceProvider
                .GetRequiredService<IOptionsMonitor<InfrastructureConfiguration>>()
                .CurrentValue
                .Mongo;

            var connectionString = "mongodb://" + mongoConfiguration.Username + ":" + mongoConfiguration.Password + "@" + mongoConfiguration.Host + ":" + mongoConfiguration.Port;

            return new MongoClient(connectionString).GetDatabase(mongoConfiguration.DatabaseName);
        }
    }
}
