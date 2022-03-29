// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Npgsql;

namespace Fluent.Data.Postgres;

public static class PostgresDbProviderOptionsExtensions
{
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
