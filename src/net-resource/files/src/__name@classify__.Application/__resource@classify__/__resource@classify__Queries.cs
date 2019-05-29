// <copyright file="<%= classify(resource) %>Queries.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>
{
    using MediatR;
<% for(let queryReference of queryReferences) { %>
    using <%= queryReference %>;
<% } %>

<% for(let query of queries) { %>
    /// <summary>
    /// The I<%= query.name %>Query interface.
    /// </summary>
    public interface I<%= query.name %>Query : IRequest<<%= query.response %>>
    {
    }
<% } %>
}