// <copyright file="ICreateArticleCommand.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Application.Articles.Commands
{
    using MediatR;

    /// <summary>
    /// The ICreateArticleCommand interface.
    /// </summary>
    public interface ICreateArticleCommand : IRequest<Article>
    {
    }
}