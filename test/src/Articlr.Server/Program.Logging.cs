// <copyright file="Program.Logging.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Server
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    using Microsoft.Extensions.Logging;


    /// <summary>
    /// The program.
    /// </summary>
    public static partial class Program
    {
        /// <summary>
        /// The initialize logger.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private static void InitializeLogging(IConfiguration config)
        {

        }

        /// <summary>
        /// The add program logger.
        /// </summary>
        /// <param name="hostBuilder">
        /// The host builder.
        /// </param>
        /// <returns>
        /// The <see cref="IWebHostBuilder"/>.
        /// </returns>
        private static IWebHostBuilder UseApplicationLogger(this IWebHostBuilder hostBuilder)
        {
            return hostBuilder

                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddLog4Net();
                    logging.SetMinimumLevel(LogLevel.Debug);
                });

        }
    }
}
