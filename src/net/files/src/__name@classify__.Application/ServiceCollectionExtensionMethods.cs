// <copyright file="ServiceCollectionExtensionMethods.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The service collection extension methods.
    /// </summary>
    public static class ServiceCollectionExtensionMethods
    {
        /// <summary>
        /// The add application.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <returns>
        /// The <see cref="IServiceCollection"/>.
        /// </returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation("Started configuring application services...");

            logger.LogInformation("Finished configuring application services...");

            return services;
        }
    }
}
