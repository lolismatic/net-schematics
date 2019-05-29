// <copyright file="InfrastructureConfiguration.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Infrastructure
{
    using <%= classify(name) %>.Infrastructure.Persistence;

    /// <summary>
    /// The infrastructure configuration.
    /// </summary>
    public class InfrastructureConfiguration
    {
        /// <summary>
        /// Gets or sets the mongo configuration.
        /// </summary>
        public MongoConfiguration Mongo { get; set; }
    }
}
