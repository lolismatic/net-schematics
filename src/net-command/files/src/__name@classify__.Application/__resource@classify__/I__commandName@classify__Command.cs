// <copyright file="I<%= classify(commandName) %>Command.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>.Commands
{
    using MediatR;

    /// <summary>
    /// The I<%= classify(commandName) %>Command interface.
    /// </summary>
    public interface I<%= classify(commandName) %>Command : IRequest<<%= classify(commandResponse) %>>
    {
    }
}