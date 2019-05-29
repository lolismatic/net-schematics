// <copyright file="I<%= classify(commandName) %>CommandValidator.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>.Validators
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The I<%= classify(commandName) %>Command validator.
    /// </summary>
    public class <%= classify(commandName) %>CommandValidator : AbstractValidator<I<%= classify(commandName) %>Command>
    {
        public <%= classify(commandName) %>CommandValidator() {
        }
    }
}