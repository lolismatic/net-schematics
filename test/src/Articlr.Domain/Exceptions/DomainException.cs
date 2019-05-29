// <copyright file="DomainException.cs" company="PitechPlus">
// Copyright (c) PitechPlus. All rights reserved.
// </copyright>

namespace Articlr.Domain {
    using System;

    public class DomainException : Exception {
        public DomainException(string message)
            : base(message)
        {

        }

        public DomainException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}