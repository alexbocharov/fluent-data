// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Oracle.ManagedDataAccess.Client;

namespace Fluent.Data.Oracle;

/// <summary>
/// Oracle specific extension methods for <see cref="IConnection"/>.
/// </summary>
public static class OracleDbProviderOptionsExtensions
{
    /// <summary>
    /// Configures to connect to an Oracle database.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="connectionString">The connection string of the database to connect to.</param>
    /// <returns>The connection.</returns>
    public static IConnection UseOracle(this IConnection connection, string connectionString)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection));
        }

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException(null, nameof(connectionString));
        }

        connection.ConnectionFactory = new ConnectionFactory<OracleConnection>(connectionString);

        return connection;
    }
}
