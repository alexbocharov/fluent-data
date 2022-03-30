// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Fluent.Data;

/// <summary>
/// This class provides methods to create <see cref="DbConnection"/> instance of a concrete type.
/// </summary>
/// <typeparam name="TConnection">The concrete <see cref="DbConnection"/> implementation to instance.</typeparam>
public class ConnectionFactory<TConnection> : IConnectionFactory
    where TConnection : DbConnection, new()
{
    private readonly string _connectionString;

    /// <summary>
    /// Initializes a new instance of <see cref="ConnectionFactory{TConnection}"/>.
    /// </summary>
    /// <param name="connectionString">The connection string of the database to connect to.</param>
    public ConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <inheritdoc/>
    public Type DbConnectionType => throw new NotImplementedException();

    /// <inheritdoc/>
    public IDbConnection CreateConnection() => new TConnection { ConnectionString = _connectionString };
}
