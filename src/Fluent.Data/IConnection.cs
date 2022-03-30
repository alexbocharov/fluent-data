// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Fluent.Data;

/// <summary>
/// A class implementing this interface is associated to a connection to the database.
/// </summary>
public interface IConnection
{
    /// <summary>
    /// Gets or sets the <see cref="IConnectionFactory"/>.
    /// </summary>
    IConnectionFactory ConnectionFactory { get; set; }
}
