// <copyright file="ICreateArticleCommandValidator.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Application.Article.Validators
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The ICreateArticleCommand validator.
    /// </summary>
    public class CreateArticleCommandValidator : AbstractValidator<ICreateArticleCommand>
    {
        public CreateArticleCommandValidator() {
        }
    }
}