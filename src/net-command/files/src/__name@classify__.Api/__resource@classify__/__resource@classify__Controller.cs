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
        /// The <%= classify(commandName) %> command mapping.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns><% if(commandRoute) { %>
        [Http<%= commandMethod %>("<%= commandRoute %>")]<% } else { %>
        [Http<%= commandMethod %>]<% } %>
        public async Task<IActionResult> <%= classify(commandName) %>(I<%= classify(commandName) %>Command command)
        {
            return await this.Mediator.Send(command).Switch(
          response => this.Ok(response),
     (Exception _) => this.StatusCode(500));
        }
    }
}