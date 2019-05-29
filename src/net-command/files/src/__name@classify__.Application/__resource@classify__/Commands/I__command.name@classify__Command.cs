// <copyright file="<%= classify(resource) %>Commands.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>.Commands
{
    using MediatR;

    using <%= classify(name) %>.Application.<%= classify(resource) %>.Responses;

    /// <summary>
    /// The I<%= command.name %>Command interface.
    /// </summary>
    public interface I<%= classify(command.name) %>Command : IRequest<<%= classify(command.response) %>>
    {
    }
}