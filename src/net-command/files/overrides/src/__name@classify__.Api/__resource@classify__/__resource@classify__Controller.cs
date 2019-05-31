<%= old.popUntil(csharp.class(classify(resource) + 'Controller').end) %>
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
<%= old.popAll() %>