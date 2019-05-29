// <copyright file="ArticlesController.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Api.Controllers.Articles
{
    using System;
    using System.Threading.Tasks;

    using Articlr.Application.Articles;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The ArticlesController.
    /// </summary>
    [Route("api/[controller]")]
    public class ArticlesController : BaseController
    {
        /// <summary>
        /// The CreateArticle command mapping.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateArticle(ICreateArticleCommand command)
        {
            return await this.Mediator.Send(command).Switch(
          response => this.Ok(response),
     (Exception _) => this.StatusCode(500));
        }
    }
}