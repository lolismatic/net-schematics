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
        /// <summary>
        /// The <%= classify(command.name) %> command mapping.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns><% if(command.route) { %>
        [Http<%= command.method %>("<%= command.route %>")]<% } else { %>
        [Http<%= command.method %>]<% } %>
        public async Task<IActionResult> <%= classify(command.name) %>(I<%= classify(command.name) %>Command command)
        {
            return await this.Mediator.Send(command).Switch(
          response => this.Ok(response),
     (Exception _) => this.StatusCode(500));
        }
    }
}