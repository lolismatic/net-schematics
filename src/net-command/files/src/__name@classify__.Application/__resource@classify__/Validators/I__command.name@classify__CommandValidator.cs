// <copyright file="<%= classify(resource) %>Validators.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Application.<%= classify(resource) %>.Validators
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using <%= classify(name) %>.Application.<%= classify(resource) %>.Commands;

    /// <summary>
    /// The I<%= command.name %>Command validator.
    /// </summary>
    public class <%= command.name %>CommandValidator : AbstractValidator<I<%= command.name %>Command>
    {
        public <%= command.name %>CommandValidator() {
        }
    }
}