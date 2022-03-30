// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Npgsql;

namespace Fluent.Data.Postgres;

/// <summary>
/// Postgres specific extension methods for <see cref="IConnection"/>.
/// </summary>
public static class PostgresDbProviderOptionsExtensions
{
    /// <summary>
    /// Configures to connect to a Postgres database.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="connectionString">The connection string of the database to connect to.</param>
    /// <returns>The connection.</returns>
    public static IConnection UsePostgreSql(this IConnection connection, string connectionString)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection));
        }

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException(nameof(connectionString));
        }

        connection.ConnectionFactory = new ConnectionFactory<NpgsqlConnection>(connectionString);

        return connection;
    }
}
