// <copyright file="<%= classify(resource) %>Validators.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
<% for(let command of commands) { %>
    /// <summary>
    /// The I<%= command.name %>Command validator.
    /// </summary>
    public class <%= command.name %>CommandValidator : AbstractValidator<I<%= command.name %>Command>
    {
        public <%= command.name %>CommandValidator() {
        }
    }
<% } for(let query of queries) { %>
    /// <summary>
    /// The I<%= query.name %>Query interface.
    /// </summary>
    public class <%= query.name %>QueryValidator: AbstractValidator<I<%= query.name %>Query>
    {
        public <%= query.name %>QueryValidator() {
        }
    }
<% } %>
}