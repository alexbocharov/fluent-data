// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Fluent.Data;

/// <summary>
/// Represents a component capable of creating <see cref="IDbConnection"/> instances.
/// </summary>
public interface IConnectionFactory
{
    /// <summary>
    /// Creates a <see cref="IDbConnection"/> instance.
    /// </summary>
    /// <returns></returns>
    IDbConnection CreateConnection();

    /// <summary>
    /// Gets the type of the cdonnection is can create.
    /// </summary>
    Type DbConnectionType { get; }
}
