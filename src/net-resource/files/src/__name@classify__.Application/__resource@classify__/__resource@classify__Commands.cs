// <copyright file="<%= classify(resource) %>Commands.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>
{
    using MediatR;
<% for(let commandReference of commandReferences) { %>
    using <%= commandReference %>;
<% } %>

<% for(let command of commands) { %>
    /// <summary>
    /// The I<%= command.name %>Command interface.
    /// </summary>
    public interface I<%= command.name %>Command : IRequest<<%= command.response %>>
    {
    }
<% } %>
}