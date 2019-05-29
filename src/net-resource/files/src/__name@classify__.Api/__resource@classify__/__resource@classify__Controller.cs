// <copyright file="<%= classify(resource) %>Controller.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Api.Controllers.<%= classify(resource) %>
{
    using System;
    using System.Threading.Tasks;

    using <%= classify(name) %>.Application.<%= classify(resource) %>;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The <%= classify(resource) %>Controller.
    /// </summary>
    [Route("api/[controller]")]
    public class <%= classify(resource) %>Controller : BaseController
    {
<% for(let command of commands) { %>
        /// <summary>
        /// The <%= command.name %> command mapping.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns><% if(command.route) { %>
        [Http<%= command.method %>("<%= command.route %>")]<% } else { %>
        [Http<%= command.method %>]<% } %>
        public async Task<IActionResult> <%= command.name %>(I<%= command.name %>Command command)
        {
            return await this.Mediator.Send(command).Switch(
          response => this.Ok(response),
     (Exception _) => this.StatusCode(500));
        }
<% } %>
<% for(let query of queries) { %>
        /// <summary>
        /// The <%= query.name %> query mapping.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns><% if(query.route) { %>
        [Http<%= query.method %>("<%= query.route %>")]<% } else { %>
        [Http<%= query.method %>]<% } %>
        public async Task<IActionResult> <%= query.name %>(I<%= query.name %>Query query)
        {
            return await this.Mediator.Send(query).Switch(
          response => this.Ok(response),
     (Exception _) => this.StatusCode(500));
        }
<% } %>
    }
}