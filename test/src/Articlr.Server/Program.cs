// <copyright file="Program.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Server
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The program.
    /// </summary>
    public partial class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args"> The arguments. </param>
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            InitializeLogging(webHost.Services.GetService<IConfiguration>());

            webHost.Run();
        }

        /// <summary>
        /// Creates web host builder.
        /// </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> Instance of <see cref="IWebHostBuilder"/>. </returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseApplicationLogger();
    }
}