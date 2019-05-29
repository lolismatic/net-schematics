// <copyright file="Startup.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using <%= classify(name) %>.Api;
    using <%= classify(name) %>.Application;
    using <%= classify(name) %>.Infrastructure;

    /// <summary>
    /// The startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<Startup> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public Startup(ILogger<Startup> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// The configure services
        /// </summary>
        /// <param name="services"> The services. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            this.logger.LogInformation("Started configuring services...");

            // The core of the application
            services.AddApplication(this.logger);

            // UI&Infrastructure Adapters
            services.AddApi(this.logger);
            services.AddInfrastructure(this.logger);

            // Mvc & third party
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            this.logger.LogInformation("Finished configuring services...");
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="app"> The application. </param>
        /// <param name="env"> the environment. </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
