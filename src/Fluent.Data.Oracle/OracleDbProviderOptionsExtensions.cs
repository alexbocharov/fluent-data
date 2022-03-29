// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Oracle.ManagedDataAccess.Client;

namespace Fluent.Data.Oracle;

public static class OracleDbProviderOptionsExtensions
{
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
