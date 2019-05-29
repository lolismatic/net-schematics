// <copyright file="I<%= command.response %>.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>.Responses
{
    using MediatR;

    using <%= classify(name) %>.Domain;

    /// <summary>
    /// The I<%= command.name %>Command interface.
    /// </summary>
    public interface I<%= classify(command.response) %>
    {
    }
}