// <copyright file="BaseController.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace <%= classify(name) %>.Api
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The base controller.
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private IMediator mediator;

        /// <summary>
        /// The mediator.
        /// </summary>
        protected IMediator Mediator => this.mediator ?? (this.mediator = this.HttpContext?.RequestServices.GetService<IMediator>());
    }
}
