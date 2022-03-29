// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Fluent.Data;

public class ConnectionFactory<TConnection> : IConnectionFactory
    where TConnection : DbConnection, new()
{
    private readonly string _connectionString;

    public ConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Type DbConnectionType => throw new NotImplementedException();

    public IDbConnection CreateConnection() => new TConnection { ConnectionString = _connectionString };
}
